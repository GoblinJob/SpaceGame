﻿using SpaceGame.Core;
using SpaceGame.Render.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public class Render3D
    {
        public static List<Render3D> AllRenders { get; private set; } = new List<Render3D>();

        public Render3D(string modelName, GameObject owner)
        {
            this.Owner = owner;
            this.model = ResurceManager.GetModel(modelName);
            AllRenders.Add(this);
        }
        public GameObject Owner { get; private set; }
        public Transform Transform => Owner.Transform;
        private Model model;


        public void Draw(Camera camera)
        {
            model.Draw(Transform, camera);
        }
    }
}
