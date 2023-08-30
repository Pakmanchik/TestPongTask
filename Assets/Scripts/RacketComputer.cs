using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RacketComputer : ParentRacket
{
    [SerializeField] 
    private Rigidbody2D _ball;
    [SerializeField] 
    private float _speedRacket;

    private Vector2 _vericalalVector;
    private Vector2 _directionRacket;

    private void FixedUpdate() => MoveRacket();
 
    private void MoveRacket()
    {
        if (_ball.velocity.x > -3f)
        {
            if (_ball.position.y >= transform.position.y)
            {
                DirectionRacket(Vector2.up);
            }
            else if (_ball.position.y <= transform.position.y)
            {
                DirectionRacket(Vector2.down);
            }
        }
    }
    
    private void DirectionRacket(Vector2 verticalVector)
    {
        _directionRacket = verticalVector * _speedRacket; 
        
        rigidbody.MovePosition(rigidbody.position + _directionRacket * Time.fixedDeltaTime);
    }
}
