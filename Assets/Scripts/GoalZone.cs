using System;
using Interface;

using UnityEngine.EventSystems;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [SerializeField]
    private EventTrigger.TriggerEvent scoreTrigger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);
        }
    }
}