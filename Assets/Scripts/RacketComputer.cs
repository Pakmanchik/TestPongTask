using Interface;
using UnityEngine;

public class RacketComputer  
{
    private IMove _move = new RacketBase();

    public void MoveRacket(Vector2 targetPosition, Vector2 racketPosition,float speedRacket,Rigidbody2D rigidBodyRacket)
    {
        Debug.Log($"{targetPosition} ballPosition");
        
        if (targetPosition.x > -3f)
        {
            if (targetPosition.y >= racketPosition.y)
            {
                _move.Move(Vector2.up * speedRacket,rigidBodyRacket);
            }
            else if (targetPosition.y <= racketPosition.y)
            {
                _move.Move(Vector2.down * speedRacket,rigidBodyRacket);
            }
        }
    }
}
