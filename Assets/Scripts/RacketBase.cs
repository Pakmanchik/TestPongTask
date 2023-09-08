using Interface;
using UnityEngine;

public class RacketBase : IMove
{
    private Vector2 _directionRacket;

    public void Move(Vector2 verticalVector,Rigidbody2D rigidbody2D)
    {
        _directionRacket = verticalVector; 
        
        if(rigidbody2D == null)  Debug.Log($"(RacketPlayer) не нашел rigidbody  ({this})");
        
        //Debug.Log($"Move called. Instance: [{rigidbody2D.gameObject.name}]. Ref pos: [{rigidbody2D.position.x}:{rigidbody2D.position.y}]. IncVector: [{verticalVector.x}:{verticalVector.y}]");
        
        rigidbody2D.MovePosition(rigidbody2D.position + verticalVector * Time.fixedDeltaTime);
    }

}