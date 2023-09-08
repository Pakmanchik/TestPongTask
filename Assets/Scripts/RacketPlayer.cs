using Interface;
using UnityEngine;

public sealed class RacketPlayer : MonoBehaviour , IHaveMoveRacket
{
    [SerializeField]
    private float _speedRacket;
   
    private Rigidbody2D _rigidbody2D;
    
    private IMove _move;
    
    private Vector2 _direction;
    private float _verticalVector;

    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
       
        _move = new RacketBase();
        
        if(_rigidbody2D == null)  Debug.Log($"(RacketPlayer) не нашел rigidbody  ({this})");
        if(_move == null)  Debug.Log($"(_move) не нашел rigidbody  ({this})");
    }

    private void FixedUpdate()
    {
        MoveRacket();
    }

    public void MoveRacket()
    {
        _verticalVector = Input.GetAxis("Vertical");
      
        _direction = new Vector2(0,_verticalVector * _speedRacket );
        
        _move.Move(_direction,_rigidbody2D);
    }
}