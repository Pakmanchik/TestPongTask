using System;
using Interface;
using UnityEngine;
using UnityEngine.Serialization;
// Комменты для запуска  
public class RacketComputer  : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D _ball;
    [SerializeField] 
    private float _speedRacket;
    
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    private IMove _move = new RacketBase();
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        if(_rigidbody2D == null)  Debug.Log($"(RacketComputer) не нашел rigidbody  ({this})");
        Debug.Log($"(RacketComputer) _speedRacket = {_speedRacket}  ({this})");
    }

    private void FixedUpdate()  => MoveRacket();

    public void MoveRacket()
    {
        if (_ball)
        {
            if (_ball.velocity.x > -3f)
            {
                if (_ball.position.y >= transform.position.y)
                {
                    _move.Move(Vector2.up * _speedRacket,_rigidbody2D);
                }
                else if (_ball.position.y <= transform.position.y)
                {
                    _move.Move(Vector2.down * _speedRacket,_rigidbody2D);
                }
            }
        }
    }
}
