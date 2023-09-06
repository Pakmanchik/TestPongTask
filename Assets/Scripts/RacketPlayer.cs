using Interface;
using UnityEngine;

public class RacketPlayer : MonoBehaviour
{
    [SerializeField] 
    private float _speedRacket;
    [SerializeField] 
    private Rigidbody2D _rigidbody2D;

    private IMove _move = new RacketBase();
    private Vector2 _direction;
    private float _verticalVector;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        if(_rigidbody2D == null)  Debug.Log($"(RacketPlayer) не нашел rigidbody  ({this})");
        if(_move == null)  Debug.Log($"(RacketPlayer) не нашел _move  ({this})");
        Debug.Log($"(RacketPlayer) _speedRacket = {_speedRacket}  ({this})");
    }

    private void FixedUpdate() => MoveRacket();
    
    public void MoveRacket()
    {
        _verticalVector = Input.GetAxis("Vertical");
        _direction = new Vector2(0,_verticalVector * _speedRacket);
        _move.Move(_direction,_rigidbody2D);
    }
}
