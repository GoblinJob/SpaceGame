﻿using Chleking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.ECS
{
    public class EntityManager
    {
        private Entity[] storage;

        public EntityManager(int maxElementCount) 
        {
            storage = new Entity[maxElementCount];
        }

        public int CreateEnitiy()
        {
            int i = 0;
            while(storage[i] != null)
            {
                i++;
            }

            storage[i] = new Entity();

            return i;
        }

        public Entity GetEnity(int i)
        {
            return storage[i];
        }

        public void DstroyEnity(int i)
        {
            storage[i] = null;
        }
    }
}
