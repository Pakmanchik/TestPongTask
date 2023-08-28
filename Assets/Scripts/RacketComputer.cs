using UnityEngine;
public class RacketComputer : ParentRacket
{
    [SerializeField] 
    private Rigidbody2D ball;
    [SerializeField] 
    private float _speedRacket;

    [Tooltip("Граница видимости ИИ")]
    [SerializeField]
    private Rigidbody2D _pointView;

    private Vector2 _directionRacket;
    private void Update()
    {
        MoveRacket();
    }

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
        else
        {
            if (transform.position.y > 0.0f)
            {
                DirectionRacket(Vector2.down);
            }
            else if (transform.position.y < 0.0f)
                DirectionRacket(Vector2.up);
        }
    }

    private void DirectionRacket(Vector2 verticalVector)
    {
        _directionRacket = new Vector2(0f,verticalVector.y) * _speedRacket * Time.deltaTime;
        transform.Translate(_directionRacket);
    }
}
