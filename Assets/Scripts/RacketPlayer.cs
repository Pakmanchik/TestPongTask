using Interface;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Serialization;

public class RacketPlayer : MonoBehaviour
{
    [SerializeField] 
    private float _speedRacket = 0;
    [SerializeField] 
    private Rigidbody2D _rigidbody2D;

    private IMove _move = new RacketBase();
    private Vector2 _direction;
    private float _vericalalVector;
    
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
        _vericalalVector = Input.GetAxis("Vertical");
        _direction = new Vector2(0,_vericalalVector * _speedRacket);
        _move.Move(_direction,_rigidbody2D);
    }
}
