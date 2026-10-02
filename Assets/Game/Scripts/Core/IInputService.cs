using System;
using UnityEngine;

namespace Game.Scripts.Core
{
    public interface IInputService
    {
        public event Action JumpPressed;
        public event Action<Vector2> LookChanged;
        public Vector2 Direction { get; }
        public bool IsUsing { get; }
    }
}