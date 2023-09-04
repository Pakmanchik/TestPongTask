using System;
using Interface;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelInitializer : MonoBehaviour
{
     [SerializeField] private Ball _ballObject;
     private Rigidbody2D _ballRigidBody;

     private void Start()
     {
         Initialize();
         CheckReferences();
     }

     private void Initialize()
     {
         _ballRigidBody = _ballObject.GetComponent<Rigidbody2D>();
     }
     
     private void CheckReferences()
     {
         if (_ballRigidBody == null) Debug.Log($"_ballRigidbody = null  ({this})");
     }

     public Ball BallObject => _ballObject;

}
