using Interface;
using UnityEngine;

public class RacketBase : IMove
{
    public void Move(Vector2 verticalVector,Rigidbody2D rigidbody2D)
    {
        if(rigidbody2D == null)  Debug.Log($"(RacketPlayer) не нашел rigidbody  ({this})");
        
        rigidbody2D.MovePosition(rigidbody2D.position + verticalVector * Time.fixedDeltaTime);
    }

}