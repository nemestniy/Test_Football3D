using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game properties:")]
    [Range(60, 300)]
    [SerializeField]
    private int _gameTimeInSeconds;
    private float _timer;
    private bool _startGame = false;
    private bool _lastGoal = false;

    [Header("Ball properties:")]
    [SerializeField]
    private Ball _ball;

    [SerializeField]
    private Transform _ballSpawnPosition;

    [Header("System Settings:")]
    [SerializeField]
    private DialogWindowController _dialogWindowController;

    [SerializeField]
    private CameraController _cameraController;

    [SerializeField]
    private Timer _UITimer;

    private Teams _teams;

    private void Awake()
    {
        _teams = GetComponent<Teams>();
        if (_teams != null)
            _teams.InitalizateTeams();
        foreach(Team team in _teams.GetTeams())
        {
            //Подписка на события забитого гола
            team.GetGoal().MakeGoal += GameManager_MakeGoal;
        }

        //Создание мяча
        _ball = Instantiate(_ball, _ballSpawnPosition.position, Quaternion.identity);

        //Установка объекта слежения для камеры 
        _cameraController.SetTrackingObject(_ball.transform);

        //Инициализация таймера
        _timer = _gameTimeInSeconds;

        _startGame = true;
    }

    private void Update()
    {
        if (_startGame)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1)
            {
                _gameTimeInSeconds--;
                _UITimer.UpdateTime(_gameTimeInSeconds);
                _timer = 0;
            }

            if(_gameTimeInSeconds <= 0)
            {
                _startGame = false;
                _lastGoal = true;
            }
        }

        if (_lastGoal)
        {
            var winner = _teams.GetWinner();
            if (winner != null)
                FinishGame(winner);
        }
    }

    private void FinishGame(Team winner)
    {
        if(_dialogWindowController != null)
        {
            _dialogWindowController.ShowWinner(winner);
        }
    }

    private void GameManager_MakeGoal(Player player)
    {
        var teams = _teams.GetTeams();
        if (teams != null)
        {
            foreach (Team team in teams)
            {
                //Поиск команды игрока, забившего мяч
                if (team.Equals(player.GetTeam()))
                {
                    team.IncreaseScore();
                    NextGame();
                }
            }
        }
    }

    private void NextGame()
    {
        _ball.Respawn(_ballSpawnPosition.position);
        if (_teams != null)
            _teams.RespawnTeams();
        if (_cameraController != null)
            _cameraController.NextGame();
    }

    private void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
