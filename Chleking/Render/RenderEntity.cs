using Chleking.Render.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public abstract class RenderEntity
    {
        /// <summary>
        /// Id объекта в рендере.
        /// </summary>
        public int Id { get; protected set; }
        /// <summary>
        /// Информация о том, загружен ли объект.
        /// </summary>
        public bool IsLoaded { get; private set; }
        /// <summary>
        /// Загружает в рендер объект.
        /// </summary>
        /// <param name="args">Аргументы для загрузки</param>
        protected void SetLoaded()
        {
            if (IsLoaded) throw new EntityAlreadyLoadException();
            IsLoaded = true;
        }
        /// <summary>
        /// Выгружает из рендера объект.
        /// </summary>
        protected void SetUnloaded()
        {
            if (!IsLoaded) throw new EntityNotLoadedException();
            IsLoaded = false;
        }
    }
}
