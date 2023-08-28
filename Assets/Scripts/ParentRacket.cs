using UnityEngine;

public class ParentRacket : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    public float speedPush = 20f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null) Debug.Log($"ParentRacket не нашел RigidBody");
    }
}
