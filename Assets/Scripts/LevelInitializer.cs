using System;
using System.Collections;
using BuilderRacket;
using Interface;
using UnityEngine;

public class LevelInitializer : MonoBehaviour , IHaveTargetPosition
{
    #region MyRegion

    // GameManager
    public GameManager GameManager => _gameManager;
    private GameManager _gameManager;
// Ball   
    [SerializeField]
    private BallElements _ballElements;
    
    public Transform TargetPosition => _ballTransform;
    private Transform _ballTransform;
    public Ball BallScrypt => _ballScrypt;
    private Ball _ballScrypt;
// ScoreManager
    private ScoreManager _scoreManager;
    
    private int _endGameScore;
// EndGame  
    public IPauseGame PauseGame => _pauseGame;
    private IPauseGame _pauseGame;
// CompRacket
    private RacketComputer _racketComputer;
    public GameObject RacketComputerObject => _computerRacketObject;
    [SerializeField] 
    private GameObject _computerRacketObject;
     
    public Rigidbody2D ComputerRacketRigidbody => _computerRacketRigidbody;
    private Rigidbody2D _computerRacketRigidbody;
     
    public float SpeedComputerRacket => _speedComputerRacket;
    [SerializeField] 
    private float _speedComputerRacket;
     
    public IHaveMoveRacket MoveRacketComputer => _moveRacket;
    private IHaveMoveRacket _moveRacket;
     
    public Transform RacketComputerTransform => _racketComputerTransform;
    private Transform _racketComputerTransform;
// RacketPlayer
    private GameObject _selectedRacket;
    public GameObject PlayerRacketObject => _selectedRacket; 
    [Space(15)]
    [SerializeField]                            // TODO: Сделать привязку от билдера 
    private GameObject _playerRacketObjectBolt;
    [SerializeField]                             
    private GameObject _playerRacketObjecClassic;
    
    public Rigidbody2D PlayerRigidbody => _playerRigidbody;
    private Rigidbody2D _playerRigidbody;

    public float SpeedPlayerRacket => _speedPlayerRacket;
    [SerializeField]
    private float _speedPlayerRacket;

    public IHaveMoveRacket PlayerMove => _playerMove;
    private IHaveMoveRacket _playerMove;
    
// RacketBuilder
    [Space(15)]
    public SkinRacket _skinRacket;

    private BuilderBase _builderBase;

    #endregion

    public RacketPlayer RacketPlayerScrypt => _racketPlayerScrypt;
    private RacketPlayer _racketPlayerScrypt;
    
     private void Awake()
     {
         _gameManager = GetComponent<GameManager>();
         _gameManager.enabled = false;
     }

     private void Start()
     {
        Initialize();
         
         Debug.Log("До старта gameManager");
         StartGameManager();
         Debug.Log("после старта gameManager");
     }

     private void Initialize()
     {
         Debug.Log("До инициализации элементов");
         InitializeElements();
         Debug.Log("после инициализации элементов");
         
         Debug.Log("До инициализации элементов левела");
         InitializeElementsLevelInitialize();
         Debug.Log("после инициализации элементов левела");  
     }

     private void StartGameManager() => _gameManager.enabled = true;

     private void BuildRacket()
     {
         _builderBase.BuildRacket(_skinRacket.ToString());

         _selectedRacket = _playerRacketObjectBolt ??= _playerRacketObjecClassic;
     }

     private void InitializeElementsLevelInitialize()
     {
         _ballTransform = _ballElements.Balltransform;
         _ballScrypt = _ballElements.BallScrypt;
         _ballScrypt.InitializerBall(_ballElements.Ball);

         _racketComputer = RacketComputerObject.GetComponent<RacketComputer>();
         _moveRacket = _computerRacketObject.GetComponent<IHaveMoveRacket>();
         _computerRacketRigidbody = _computerRacketObject.GetComponent<Rigidbody2D>();
         _racketComputerTransform = _computerRacketObject.GetComponent<Transform>();
         _racketComputer.InitializerComputerRacket(
             _ballTransform,
             _racketComputerTransform,
             _speedComputerRacket,
             _computerRacketObject);

         _builderBase = GetComponent<BuilderBase>();
         BuildRacket();
         
         _pauseGame = GetComponent<IPauseGame>();
         
         _scoreManager = this.GetComponent<ScoreManager>();
         Debug.Log("после _scoreManager элементов");
         
         
         _racketPlayerScrypt = _selectedRacket.GetComponent<RacketPlayer>();
         _racketPlayerScrypt.InitializedPlayer(_speedPlayerRacket);
         _playerMove = _selectedRacket.GetComponent<IHaveMoveRacket>();

         CheckReferencesLevel();
     }
     
     private void InitializeElements()
     {
         Debug.Log($"<InitializeElements началось");
         
         _ballElements.InitializeElementsBall();
                 
         Debug.Log($"<InitializeElements выполнено");
     }
     
     private void CheckReferencesLevel()
     {
         Debug.Log($"<InitializeElementsLevelInitialize начал проверку");
         
         if (_ballTransform == null) Debug.Log($"_ballTransform = null  ({this})");
         if (_moveRacket == null) Debug.Log($"_moveRacket = null  ({this})");
         if (_pauseGame == null) Debug.Log($"_iPauseGame = null  ({this})");
         if (_scoreManager == null) Debug.Log($"_scoreManager = null  ({this})");
         if (_moveRacket == null) Debug.Log($"_gameManager = null  ({this})");
         if (_builderBase == null) Debug.Log($"_builderBase = null  ({this})");
         
         Debug.Log($"<InitializeElementsLevelInitialize проверил");
     }
     
     public enum SkinRacket : byte
     {
         Classic, //0
         Bolt, //1
     }
   
     [Serializable]
     private class BallElements
     {
         public GameObject Ball => _ball;
         [SerializeField] 
         private GameObject _ball;
         
         public Rigidbody2D BallRb => _ballRigidBody;
         private Rigidbody2D _ballRigidBody; 
         
         public Transform Balltransform => _ballTransform;
         private Transform _ballTransform;
         
         public Ball BallScrypt => _ballScrypt;
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
         
      
     }
}

