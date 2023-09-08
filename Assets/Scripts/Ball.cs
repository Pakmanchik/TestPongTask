using Interface;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    [SerializeField] 
    private float _speed;

    private Rigidbody2D _rigidbody;
    
    public void InitializerBall(GameObject gameObject)
    {
         _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    
    public void AddShootBall()
    {
        float x = Random.value < 0.5F ? Random.Range(-1.0f, -0.5f) :
                                        Random.Range(0.5f, 1.0f);
        float y = Random.value < 0.5f ? -1.0f : 1.0f;

        Vector2 direction = new(x, y);
        if(_rigidbody == null)  Debug.Log($"_ballRigidbody = null  ({this})");
        _rigidbody.AddForce(direction *  _speed);
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector2.zero;
        _rigidbody.velocity = Vector2.zero;
        
        AddShootBall();
    }
}
