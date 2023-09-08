using Interface;
using UnityEngine;

public sealed class RacketComputer : MonoBehaviour ,IHaveMoveRacket
{
    private IMove _move = new RacketBase();

    private Transform _targetPosition;
    private float _speedRacket;
    private Rigidbody2D _rigidBodyRacket;
    private Transform _transformRacket;
    
    public void InitializerComputerRacket(Transform positionTarget, float speed)
    {
        _targetPosition = positionTarget;
        _speedRacket = speed;
        _rigidBodyRacket = GetComponent<Rigidbody2D>();
        _transformRacket = _rigidBodyRacket.GetComponent<Transform>();
    }

    public void MoveRacket()
    {
        if (_targetPosition.position.x > -3f)
        {
            if (_targetPosition.position.y > _rigidBodyRacket.position.y )
            {
                _move.Move(_transformRacket.TransformVector(Vector2.up) * _speedRacket,_rigidBodyRacket);
            }
            else if (_targetPosition.position.y < _rigidBodyRacket.position .y)
            {
                _move.Move(_transformRacket.TransformVector(Vector2.down) * _speedRacket,_rigidBodyRacket);
            }
        }
    }
}