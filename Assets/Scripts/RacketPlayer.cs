using UnityEngine;

public class RacketPlayer : ParentRacket
{
    [SerializeField] 
    private float _speedRacket = 0;
    
    private Vector2 _directionRacket;
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
        _directionRacket = new Vector2(0f, _vericalalVector * _speedRacket);  
        
        rigidbody.MovePosition(rigidbody.position + _directionRacket * Time.fixedDeltaTime);
    }
    
    
}
