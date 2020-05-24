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

        public Matrix4 ViewMatrix => Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(Fov), ViewHeight / ViewWidth, 0.1f, 100.0f);

        public Camera(float fov, float viewRange, int viewHeight, int viewWidthl)
        {
            this.Fov = fov;
            this.ViewRange = viewRange;
            this.ViewHeight = viewHeight;
            this.ViewWidth = viewWidthl;
            Transform = new Transform();
        }

        public Model[] GetModelsInView()
        {
            Model.models.Sort((Model model1, Model model2) =>
            {
                if (DistanceSearch(model1, Transform) > DistanceSearch(model2, Transform)) return 1;
                else if (DistanceSearch(model1, Transform) < DistanceSearch(model2, Transform)) return -1;
                else return 0;
            });

            return null;
        }
        private float DistanceSearch(Model model, Transform transform)
        {
            float distanceToObject = (float)Math.Sqrt(Math.Pow(model.Transform.coordination.X - transform.coordination.X, 2) +
                Math.Pow(model.Transform.coordination.Y - transform.coordination.Y, 2) +
                Math.Pow(model.Transform.coordination.Z - transform.coordination.Z, 2));

            return distanceToObject;
        }

        public void ShowAllInView()
        {
            var models = GetModelsInView();
            for (int i = 0; i < models.Length; i++)
            {
                models[i].Draw(this);
            }
        }
    }
}
