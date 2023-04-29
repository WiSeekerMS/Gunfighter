using System;

namespace Gameplay.ShotSystem.Interfaces
{
    public interface IShootAnimation
    {
        event Action CompleteEvent;
        float DelayBeforePlay { get; set; }
        void Prepare();
        void Play();
        void Stop();
    }
}