using UnityEngine.EventSystems;
using UnityEngine;

public sealed class GoalZone : MonoBehaviour
{
    [SerializeField]
    private EventTrigger.TriggerEvent _scoreTrigger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this._scoreTrigger.Invoke(eventData);
        }
    }
}