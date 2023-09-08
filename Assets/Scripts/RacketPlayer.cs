using Interface;
using UnityEngine;

public class RacketPlayer : MonoBehaviour , IHaveMoveRacket
{
    [SerializeField]
    private float _speedRacket;
   
    private Rigidbody2D _rigidbody2D;
    
    private IMove _move;
    private Vector2 _direction;
    private float _verticalVector;

    public void InitializedPlayer( float speed)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
       
        _move = new RacketBase();
        
        if(_rigidbody2D == null)  Debug.Log($"(RacketPlayer) не нашел rigidbody  ({this})");
        if(_move == null)  Debug.Log($"(_move) не нашел rigidbody  ({this})");
    }

    public void UpdateTicKPlayer()
    {
        MoveRacket();
    }
    
    public void MoveRacket()
    {
        _verticalVector = Input.GetAxis("Vertical");
      
        _direction = new Vector2(0,1 * _speedRacket );
        Debug.Log(_direction);
        
        Move(_direction,_rigidbody2D);
    }
    private void Move(Vector2 verticalVector,Rigidbody2D rigidbody2D)
    {
        if(rigidbody2D == null)  Debug.Log($"(RacketPlayer) не нашел rigidbody  ({this})");
        
        Debug.Log($"Move called. Instance: [{rigidbody2D.gameObject.name}]. Ref pos: [{rigidbody2D.position.x}:{rigidbody2D.position.y}]. IncVector: [{verticalVector.x}:{verticalVector.y}]");
        
        rigidbody2D.MovePosition(rigidbody2D.position + verticalVector * Time.fixedDeltaTime);
    }
}
