using UnityEngine;

namespace Interface
{
    public interface IHaveTargetPosition
    {
        public Rigidbody2D TargetPosition { get; }
    }
}