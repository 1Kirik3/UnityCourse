using Assets.Scripts;
using Assets.Scripts.Bird;
using Assets.Scripts.Bullets;
using Assets.Scripts.Enemy;
using Assets.Scripts.ScoreSystem;
using Assets.Scripts.Services;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private CameraFollower _camera;
    [SerializeField] private InputHandler _input;
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private BulletPool _bulletPool;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
        _input.JumpPressed += OnJumpPressed;
        _enemySpawner.EnemySpawned += OnEnemySpawned;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
        _input.JumpPressed -= OnJumpPressed;
        _enemySpawner.EnemySpawned -= OnEnemySpawned;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        ResetAllObjects();
    }

    private void OnJumpPressed()
    {
        if (Time.timeScale > 0)
            _birdMover.Fly();
    }

    private void OnGameOver()
    {
        _endGameScreen.Open();
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        RestartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        ResetAllObjects();
        Time.timeScale = 1;
    }

    private void RestartGame()
    {
        _endGameScreen.Close();
        ResetAllObjects();
        Time.timeScale = 1;
    }

    private void ResetAllObjects()
    {
        _scoreCounter.Reset();
        _bird.Reset();
        _birdMover.Reset();
        _enemySpawner.Reset();

        if (_bulletPool != null)
            _bulletPool.Reset();

        _camera.ResetPosition();
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _scoreCounter.Add();
        enemy.Died -= OnEnemyDied;
    }
}