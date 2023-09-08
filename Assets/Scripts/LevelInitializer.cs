using BuilderRacket;
using Interface;
using UnityEngine;

public sealed class LevelInitializer : MonoBehaviour, IHaveTargetPosition
{
   private ScoreManager _scoreManager;

   private GameManager _gameManager;

   private BuilderBase _builderBase;
   
   #region Ball
   
      [SerializeField]
      private GameObject _ballObject;
   
      private Ball _ballScrypt;
      public Transform TargetPosition => _ballRigidbody;
      private Transform _ballRigidbody;
      private Transform _ballTransform;
   #endregion

   #region ComputerRacket
   
      [Space(15)]
      [SerializeField]
      private GameObject _racketComputerObject;
      [SerializeField]
      private float _speedRacketComputer;
      
      private RacketComputer _racketComputer;
   #endregion

   #region EndGame
   
      [Space(15)]
      [SerializeField] 
      private GameObject _buttonEndGame;
   
      private EndGame _endGame;
   #endregion
   
   private void Awake()
   {
      _gameManager = GetComponent<GameManager>();
      _gameManager.enabled = false;
   }
   
   private void GameManagerOn() => _gameManager.enabled = true;

   private void Start()
   {
      Initializer();

      GameManagerOn();
   }

   private void Initializer()
   {
      InitializerForBall();
      
      _builderBase.BuildRacket();
      
      InitializerForScore();
      InitializerForEndGame();
      InitializerForRacketComputer();
      
      _gameManager.InitializerGameManager(_ballObject,_racketComputerObject);
   }
   
   private void InitializerForBall()
   {
      _builderBase = GetComponent<BuilderBase>();
      _ballScrypt = _ballObject.GetComponent<Ball>();
      if(_ballScrypt == null) Debug.Log($"_ballScrypt = null  ({this})");
      _ballRigidbody = _ballObject.GetComponent<Transform>();
      _ballTransform = _ballObject.GetComponent<Transform>();
      
      _ballScrypt.InitializerBall();
   }
   
   private void InitializerForScore()
   {
      _scoreManager = GetComponent<ScoreManager>();
      if(_scoreManager == null) Debug.Log($"_scoreManager = null  ({this})");

      _scoreManager.InitializeScoreManager(_ballObject);
   }
   
   private void InitializerForEndGame()
   {
      _endGame = GetComponent<EndGame>();
      if(_endGame == null) Debug.Log($"_endGame = null  ({this})");

      _endGame.InitializeEndGame(_ballObject,_buttonEndGame);
   }
   
   private void InitializerForRacketComputer()
   {
      _racketComputer = _racketComputerObject.GetComponent<RacketComputer>();
      if(_racketComputer == null) Debug.Log($"_racketComputer = null  ({this})");

      _racketComputer.InitializerComputerRacket(_ballTransform,_speedRacketComputer);
   }
}

