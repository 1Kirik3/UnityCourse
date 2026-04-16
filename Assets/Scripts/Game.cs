using Assets.Scripts.Bird;
using Assets.Scripts.Enemy;
using Assets.Scripts.ScoreSystem;
using Assets.Scripts.Services;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private InputHandler _input;
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private ScoreCounter _scoreCounter;

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
    }

    private void OnJumpPressed()
    {
        if (Time.timeScale > 0)
            _birdMover.Fly();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
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
