using UnityEngine;

namespace Interface
{
    public interface IMove
    {
        public void Move(Vector2 verticalVector, Rigidbody2D rigidbody2D);
    }
}