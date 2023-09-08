using Interface;
using UnityEngine;

public class RacketComputer : MonoBehaviour ,IHaveMoveRacket
{
    private IMove _move = new RacketBase();

    private Transform _targetPosition;
    private Transform _racketPosition;
    private float _speedRacket;
    private Rigidbody2D _rigidBodyRacket;
    
    
    public void InitializerComputerRacket(Transform transformTarget, Transform transformRacket,float speed,GameObject racket)
    {
        _targetPosition = transformTarget;
        _racketPosition = transformRacket;
        _speedRacket = speed;
        _rigidBodyRacket = racket.GetComponent<Rigidbody2D>();
    }

    public void MoveRacket()
    {
        if (_targetPosition.position.x > -3f)
        {
            if (_targetPosition.position.y >= _racketPosition.position.y)
            {
                _move.Move(_racketPosition.TransformVector(Vector3.up) * _speedRacket,_rigidBodyRacket);
            }
            else if (_targetPosition.position.y <= _racketPosition.position.y)
            {
                _move.Move(_racketPosition.TransformVector(Vector3.down) * _speedRacket,_rigidBodyRacket);
            }
        }
    }
}