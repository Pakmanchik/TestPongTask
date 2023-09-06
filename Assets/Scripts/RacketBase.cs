using Interface;
using UnityEngine;

public class RacketBase : IMove
{
    private Vector2 _directionRacket;

    public void Move(Vector2 verticalVector,Rigidbody2D rigidbody2D)
    {
        _directionRacket = verticalVector; 
        
        if(rigidbody2D == null)  Debug.Log($"(RacketPlayer) не нашел rigidbody  ({this})");
        rigidbody2D.MovePosition(rigidbody2D.position + _directionRacket * Time.fixedDeltaTime);
    }

}