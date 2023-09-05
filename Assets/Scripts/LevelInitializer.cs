using System;
using DefaultNamespace;
using Interface;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelInitializer : MonoBehaviour
{ 
// GameManager
    [SerializeField]
     private GameManager _gameManager;
// Ball   
    [SerializeField]
    private BallElemets _ballElemets;
  
    private GameObject _ballGameObject;
    private Rigidbody2D _ballRigidBody;
    private Transform _ballTransform;
    private Ball _ballScrypt;
// ScoreManager
    [SerializeField]
    private ScoreManagerElemets _scoreManagerElemets;
    private ScoreManager _scoreManager;
    private int _endGameScore;
// EndGame    
    [Space(15)]
    private IPauseGame _iPauseGame;

     private void Start()
     {
         _gameManager.enabled = false;
         Initialize();
     }

     private void Initialize()
     {
         InitializeElements();


         InitializeElementsLevelInitialize();
         StartGameManager();
     }

     private void StartGameManager() => _gameManager.enabled = true;
     

     private void InitializeElementsLevelInitialize()
     {
         _ballGameObject = _ballElemets.Ball;
         _ballRigidBody = _ballElemets.BallRb;
         _ballTransform = _ballElemets.Balltransform;
         _ballScrypt = _ballElemets.BallScrypt;
         _gameManager = GetComponent<GameManager>();
         _iPauseGame = GetComponent<IPauseGame>();
         _scoreManager = new ScoreManager();
         
         CheckReferences();
     }

     private void InitializeElements()
     {
         _ballElemets.InitializeElementsBall();
         _scoreManagerElemets.InitializeElementsScoreManager();
         
                 
         Debug.Log($"<InitializeElements выполнено");
     }
     
     private void CheckReferences()
     {
         if (_ballGameObject == null) Debug.Log($"_ballGameObject = null  ({this})");
         if (_ballRigidBody == null) Debug.Log($"_ballRigidBody = null  ({this})");
         if (_ballTransform == null) Debug.Log($"_ballTransform = null  ({this})");
         if (_gameManager == null) Debug.Log($"_gameManager = null  ({this})");
         
         Debug.Log($"<InitializeElementsLevelInitialize проверил");
     }

     public GameObject BallGameObject => _ballGameObject;
     public Rigidbody2D BallRigidBody => _ballRigidBody;
     public Transform BallTransform => _ballTransform;
     public Ball BallScrypt => _ballScrypt;

     public ScoreManager ScoreManager => _scoreManager;

     public GameManager GameManager => _gameManager;
     public IPauseGame IPauseGame => _iPauseGame;

     
     [Serializable]
     private class BallElemets
     {
         [SerializeField] 
         private GameObject _ball;
         
         private Rigidbody2D _ballRigidBody;
         private Transform _ballTransform;
         private Ball _ballScrypt;

         public void InitializeElementsBall()
         {
             _ballRigidBody = _ball.GetComponent<Rigidbody2D>();
             _ballScrypt = _ball.GetComponent<Ball>();
             _ballTransform = _ball.GetComponent<Transform>();

             CheckReferences();
         }

         private void CheckReferences()
         {
             if (_ball == null) Debug.Log($"_ball = null  ({this})");
             if (_ballRigidBody == null) Debug.Log($"_ballRigidbody = null  ({this})");
             if (_ballTransform == null) Debug.Log($"_ballTransform = null  ({this})");
             
             Debug.Log($"<BallElemets проверил");
         }
         
         public GameObject Ball => _ball;
         public Rigidbody2D BallRb => _ballRigidBody;
         public Transform Balltransform => _ballTransform;
         public Ball BallScrypt => _ballScrypt;

     }
     
     
     [Serializable]
     private class ScoreManagerElemets
     { 
        [SerializeField]
        [Tooltip("Задать конечный счет")]
        private int _endScore;

         public void InitializeElementsScoreManager()
         {
             CheckReferences();
         }

         private void CheckReferences()
         {
             if (_endScore < 1) _endScore = 1;
     
             Debug.Log($"<BallElemets проверил");
         }
         
         public int EndScore => _endScore;
    

     }
}
