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
        public Transform Transform { get; set; }
        public float Fov { get; set; }
        public float ViewRange { get; set; }
        public int ViewHeight { get; set; }
        public int ViewWidth { get; set; }

        public Matrix4 ViewMatrix => Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(Fov), ((float)ViewHeight) / ViewWidth, 0.1f, 100.0f);

        public Camera(float fov, float viewRange, int viewHeight, int viewWidthl)
        {
            this.Fov = fov;
            this.ViewRange = viewRange;
            this.ViewHeight = viewHeight;
            this.ViewWidth = viewWidthl;
            Transform = new Transform();
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
        private float DistanceSearch(Render3D model, Transform transform)
        {
            float distanceToObject = (float)Math.Sqrt(Math.Pow(model.Transform.location.X - transform.location.X, 2) +
                Math.Pow(model.Transform.location.Y - transform.location.Y, 2) +
                Math.Pow(model.Transform.location.Z - transform.location.Z, 2));

            return distanceToObject;
        }

        public void ShowAllInView()
        {
            var models = Render3D.AllRenders;
            for (int i = 0; i < models.Count; i++)
            {
                models[i].Draw(this);
            }
        }
    }
}
