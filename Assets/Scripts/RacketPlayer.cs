using Interface;
using UnityEngine;
using UnityEngine.Serialization;

public class RacketPlayer : RacketBase
{
    [SerializeField] 
    private float _speedRacket = 0;
    
    private Vector2 _direction;
    private float _vericalalVector;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
        Debug.Log($"(RacketPlayer) _speedRacket = {_speedRacket}  ({this})");
    }

    private void FixedUpdate() => MoveRacket();
    
    private void MoveRacket()
    {
        _vericalalVector = Input.GetAxis("Vertical");
        _direction = new Vector2(0,_vericalalVector * _speedRacket);
        Move(_direction,_speedRacket);
    }
}
