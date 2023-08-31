using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RacketComputer : RacketBase
{
    [SerializeField] 
    private Rigidbody2D _ball;
    [SerializeField] 
    private float _speedRacket;
    
    private void FixedUpdate() => MoveRacket();

    private void MoveRacket()
    {
        if (_ball)
        {
            if (_ball.velocity.x > -3f)
            {
                if (_ball.position.y >= transform.position.y)
                {
                    Move(Vector2.up,_speedRacket);
                }
                else if (_ball.position.y <= transform.position.y)
                {
                    Move(Vector2.down,_speedRacket);
                }
            }
        }
    }
}
