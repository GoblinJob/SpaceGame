using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public class Camera
    {
        public Camera(float fov, float viewRange, int viewHeight, int viewWidth)
        {
            this.fov = fov;
            this.viewRange = viewRange;
            this.viewHeight = viewHeight;
            this.viewWidth = viewWidth;
            UpdateProjection();
        }

        public Camera(float fov, float viewRange, int viewHeight, int viewWidth, Vector3 startPosition) 
            : this(fov, viewRange, viewHeight, viewWidth)
        {
            Transform.position = startPosition;
        }

        public Camera(float fov, float viewRange, int viewHeight, int viewWidth, Transform transform)
    : this(fov, viewRange, viewHeight, viewWidth)
        {
            Transform = transform;
        }

        private float viewRange;
        private int viewHeight;
        private int viewWidth;
        private float fov;

        public Transform Transform { get; set; } = new Transform();
        public Matrix4 View => Matrix4.LookAt(Transform.position, Transform.position + Front, Up);
        public Matrix4 Projection { get; private set; }
        public Vector3 Front { get; set; } = new Vector3(0, 0, -1);
        public Vector3 Up { get; private set; } = new Vector3(0, 1, 0);

        public float Fov
        {
            get => fov;
            set
            {
                fov = value;
                UpdateProjection();
            }
        }

        public float ViewRange
        {
            get => viewRange;
            set
            {
                viewRange = value;
                UpdateProjection();
            }
        }

        public int ViewHeight
        {
            get => viewHeight;
            set
            {
                viewRange = value;
                UpdateProjection();
            }
        }

        public int ViewWidth
        {
            get => viewWidth;
            set
            {
                viewRange = value;
                UpdateProjection();
            }
        }



        public void ShowAllInView()
        {
            var models = Render3D.AllRenders;
            for (int i = 0; i < models.Count; i++)
            {
                models[i].Draw(this);
            }
        }

        private Matrix4 CreateViewMatrix(Vector3 position, Vector3 target, Vector3 xDirection)
        {
            var vectorX = xDirection;
            var vectorY = Vector3.Cross(xDirection, Vector3.UnitX);
            var vectorZ = Vector3.Cross(xDirection, Vector3.UnitX);
            return Matrix4.Identity;
        }

        private void UpdateProjection()
        {
            Projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(Fov), ((float)ViewHeight) / ViewWidth, 0.1f, ViewRange);
        }
    }
}
