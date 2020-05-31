using Chleking.Render.Exceptions;

namespace SpaceGame.Render
{
    /// <summary>
    /// Переключает состаяние загружен ли объект рендера в рендер.
    /// </summary>
    internal sealed class RenderEntityState
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
