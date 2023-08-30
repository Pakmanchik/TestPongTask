using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        if (_rigidbody == null) Debug.Log($"Ball не найден RigidBody");
    }

    private void Start()
    {
        AddShootBall();
    }

    private void AddShootBall()
    {
        float x = Random.value < 0.5F ? Random.Range(-1.0f, -0.5f) :
                                        Random.Range(0.5f, 1.0f);
        float y = Random.value < 0.5f ? -1.0f : 1.0f;

        Vector2 direction = new(x, y);
        _rigidbody.AddForce(direction * speed);
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        
        AddShootBall();
    }
}
