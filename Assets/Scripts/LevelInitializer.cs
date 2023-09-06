using System;
using Interface;
using UnityEngine;

public class LevelInitializer : MonoBehaviour , IHaveTargetPosition
{ 
// GameManager
    [SerializeField]
     private GameManager _gameManager;
// Ball   
    [SerializeField]
    private BallElements _ballElements;
  
    private GameObject _ballGameObject;
    public Rigidbody2D TargetPosition => _ballRigidbody;
    private Rigidbody2D _ballRigidbody;
    
    private Vector2 _ballTransform;
    private Ball _ballScrypt;
// ScoreManager
    [SerializeField]
    private ScoreManager _scoreManager;
    private int _endGameScore;
// EndGame    
    [Space(15)]
    private IPauseGame _iPauseGame;
    
// CompRacket
     [SerializeField] 
     private GameObject _computerRacketObject;
     public Rigidbody2D RigidbodyComputer => _rigidbodyComputer;
     [SerializeField] 
     private Rigidbody2D _rigidbodyComputer;

     public float SpeedComputerRacket => _speedComputerRacket;
     [SerializeField] 
     private float _speedComputerRacket;

     public RacketComputer RacketComputerScrypt => _racketComputerScrypt;
     private RacketComputer _racketComputerScrypt;

     public Vector2 RacketComputerTransform => _racketComputerTransform;
     [SerializeField]
     private Vector2 _racketComputerTransform;

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
         _ballGameObject = _ballElements.Ball;
         _ballRigidbody = _ballElements.BallRb;
         _ballTransform = _ballElements.Balltransform;
         _ballScrypt = _ballElements.BallScrypt;

         _rigidbodyComputer = GetComponent<Rigidbody2D>();
         _racketComputerScrypt = new RacketComputer();
         _computerRacketObject = GetComponent<GameObject>();
         _racketComputerTransform = GetComponent<Vector2>();
         
         _gameManager = GetComponent<GameManager>();
         
         _iPauseGame = GetComponent<IPauseGame>();
         
         _scoreManager = new ScoreManager();
         
         
         CheckReferences();
     }

     private void InitializeElements()
     {
         _ballElements.InitializeElementsBall();
                 
         Debug.Log($"<InitializeElements выполнено");
     }
     
     private void CheckReferences()
     {
         if (_ballGameObject == null) Debug.Log($"_ballGameObject = null  ({this})");
         if (_ballRigidbody == null) Debug.Log($"_ballRigidBody = null  ({this})");
         if (_gameManager == null) Debug.Log($"_gameManager = null  ({this})");
         if (_racketComputerTransform == null) Debug.Log($"_gameManager = null  ({this})");
         
         Debug.Log($"<InitializeElementsLevelInitialize проверил");
     }

     public GameObject BallGameObject => _ballGameObject;
     public Rigidbody2D BallRigidbody => _ballRigidbody;
     public Vector2 BallTransform => _ballTransform;
     public Ball BallScrypt => _ballScrypt;

     public ScoreManager ScoreManager => _scoreManager;

     public GameManager GameManager => _gameManager;
     
     public IPauseGame PauseGame => _iPauseGame;


     [Serializable]
     private class BallElements
     {
         [SerializeField] private GameObject _ball;

         private Rigidbody2D _ballRigidBody;
         private Vector2 _ballTransform;
         private Ball _ballScrypt;

         public void InitializeElementsBall()
         {
             _ballRigidBody = _ball.GetComponent<Rigidbody2D>();
             _ballScrypt = _ball.GetComponent<Ball>();
             _ballTransform = _ball.GetComponent<Vector2>();
             

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
         public Vector2 Balltransform => _ballTransform;
         public Ball BallScrypt => _ballScrypt;
     }
}

