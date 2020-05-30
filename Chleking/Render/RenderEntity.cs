using Chleking.Render.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public sealed class RenderEntityState
    {
        /// <summary>
        /// Информация о том, загружен ли объект.
        /// </summary>
        public bool IsLoaded { get; private set; }
        /// <summary>
        /// Загружает в рендер объект.
        /// </summary>
        /// <param name="args">Аргументы для загрузки</param>
        public void Load()
        {
            if (IsLoaded) throw new EntityAlreadyLoadException();
            IsLoaded = true;
        }
        /// <summary>
        /// Выгружает из рендера объект.
        /// </summary>
        public void Unload()
        {
            if (!IsLoaded) throw new EntityNotLoadedException();
            IsLoaded = false;
        }
    }
}
