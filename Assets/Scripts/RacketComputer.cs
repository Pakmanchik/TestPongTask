using UnityEngine;
public class RacketComputer : ParentRacket
{
    [Tooltip("Граница видимости ИИ")]
    [SerializeField]
    private Rigidbody2D _pointView;
    [SerializeField] 
    private Rigidbody2D ball;
    [SerializeField] 
    private float _speedRacket;

    private Vector2 _vericalalVector;
    private Vector2 _directionRacket;

    private void Update() => MoveRacket();
 
    private void MoveRacket()
    {
        if (ball.position.x > _pointView.position.x)
        {
            if (ball.position.y > transform.position.y)
            {
                DirectionRacket(Vector2.up);
            }
            else if (ball.position.y < transform.position.y)
            {
                DirectionRacket(Vector2.down);
            }
        }
    }

    private void DirectionRacket(Vector2 verticalVector)
    {
        _directionRacket = verticalVector * _speedRacket; 
        
        rigidbody.MovePosition(rigidbody.position + _directionRacket * Time.deltaTime);
    }
}
