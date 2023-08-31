using Interface;
using UnityEngine;


public class RacketBase : MonoBehaviour, IMove
{
    protected Rigidbody2D rigidbody;
    private Vector2 _directionRacket;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody == null) Debug.Log($"ParentRacket не нашел RigidBody");
    }
    
    public void Move(Vector2 verticalVector, float speedRacket)
    {
        _directionRacket = verticalVector * speedRacket; 
        
        rigidbody.MovePosition(rigidbody.position + _directionRacket * Time.fixedDeltaTime);
    }

}