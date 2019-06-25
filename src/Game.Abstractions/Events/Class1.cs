using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Abstractions.Events
{
    public interface IHandlesQuit
    {
        void Quit();
    }

    public interface IHandlesUpdate
    {
        void Update(float delta);
    }

    public interface IHandlesLoad
    {
        void Load();
    }

    public interface IHandlesDraw
    {
        void Draw();
    }

    public interface IHandlesKeyUp
    {
        void KeyUp(KeyUpEvent keyup);
    }

    public interface IHandlesKeyDown
    {
        void KeyDown(KeyDownEvent keydown);
    }
}
