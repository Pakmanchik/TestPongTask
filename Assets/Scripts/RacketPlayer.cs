using UnityEngine;

public class RacketPlayer : ParentRacket
{
    [SerializeField] private float _speedRacket;
    private Vector2 _directionRacket;
    private float _vericalalVector;

    private void Update()
    {
        MoveRacket();
    }

    private void MoveRacket()
    {
        _vericalalVector = Input.GetAxis("Vertical");

        _directionRacket = new Vector2(0,_vericalalVector) * _speedRacket * Time.deltaTime;
        transform.Translate(_directionRacket);
    }
}
