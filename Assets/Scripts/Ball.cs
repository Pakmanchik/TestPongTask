using Interface;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    [FormerlySerializedAs("speed")] [SerializeField] 
    private float _speed;
    
    
   

    public void AddShootBall(Rigidbody2D rigidbody2D)
    {
        
        float x = Random.value < 0.5F ? Random.Range(-1.0f, -0.5f) :
                                        Random.Range(0.5f, 1.0f);
        float y = Random.value < 0.5f ? -1.0f : 1.0f;

        Vector2 direction = new(x, y);
        if(rigidbody2D == null)  Debug.Log($"_ballRigidbody = null  ({this})");
        rigidbody2D.AddForce(direction *  _speed);
    }

    public void ResetPosition(Rigidbody2D rigidbody2D)
    {
        rigidbody2D.position = Vector2.zero;
        rigidbody2D.velocity = Vector2.zero;
        
        AddShootBall(rigidbody2D);
    }
}
