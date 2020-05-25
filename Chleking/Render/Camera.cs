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


        public Transform Transform { get; set; }
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


        public Render3D[] GetModelsInView()
        {
            Render3D.AllRenders.Sort((Render3D model1, Render3D model2) =>
            {
                if (DistanceSearch(model1, Transform) > DistanceSearch(model2, Transform)) return 1;
                else if (DistanceSearch(model1, Transform) < DistanceSearch(model2, Transform)) return -1;
                else return 0;
            });

            return null;
        }


        private void UpdateProjection()
        {
            Projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(Fov), ((float)ViewHeight) / ViewWidth, 0.1f, ViewRange);
        }


        private float DistanceSearch(Render3D model, Transform transform)
        {
            float distanceToObject = (float)Math.Sqrt(Math.Pow(model.Transform.location.X - transform.location.X, 2) +
                Math.Pow(model.Transform.location.Y - transform.location.Y, 2) +
                Math.Pow(model.Transform.location.Z - transform.location.Z, 2));

            return distanceToObject;
        }
    }
}
