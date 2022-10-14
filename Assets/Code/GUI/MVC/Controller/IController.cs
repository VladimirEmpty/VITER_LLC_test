﻿using Code.GUI.MVC.View;

namespace Code.GUI.MVC.Controller
{
    /// <summary>
    /// Основной интерфейс Controller обеспечивает функционал добавления объекта View
    /// </summary>
    public interface IController
    {
        void AddView<V>(V view) where V : class, IView;
    }
}
