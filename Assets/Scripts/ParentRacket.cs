using UnityEngine;


public class ParentRacket : MonoBehaviour
{
    protected Rigidbody2D rigidbody;
    protected float speedPush = 20f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody == null) Debug.Log($"ParentRacket не нашел RigidBody");
    }

}