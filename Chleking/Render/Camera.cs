using OpenTK;
using SpaceGame.Core;
using SpaceGame.Render.OpenGL;
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
            Transform = new Transform();
            this.fov = fov;
            this.viewRange = viewRange;
            this.viewHeight = viewHeight;
            this.viewWidth = viewWidth;
            UpdateProjection();
        }


        public float viewRange;
        public int viewHeight;
        public int viewWidth;
        private float fov;

        double i = 0.0;
        public Transform Transform { get; set; }
        public Matrix4 View
        {
            get
            {
                i += 0.2;
                return Matrix4.LookAt(new Vector3((float)Math.Sin(i) * 10, (float)Math.Cos(i) * 10, 0),
                new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            }
        }
        public Matrix4 Projection { get; private set; }


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

        private void UpdateProjection()
        {
            Projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(Fov), ((float)ViewHeight) / ViewWidth, 0.1f, ViewRange);
        }
    }
}
