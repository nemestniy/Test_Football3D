using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teams : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private List<Team> _teams = new List<Team>(2);

    public void InitalizateTeams()
    {
        if (_teams != null)
        {
            foreach (Team team in _teams)
            {
                team.InitializateScore();
                team.GetGoal().InitializateTeam(team);
                for (int i = 0; i < team.GetPlayersCount(); i++)
                {
                    //Создание игроков
                    var playerObject = Instantiate(_player, team.GetSpawnPosition(), Quaternion.identity) as GameObject;
                    var player = playerObject.GetComponent<Player>();
                    if (player != null)
                    {
                        player.InitializateTeam(team);
                        team.AddPlayer(player);   
                    }
                }
            }
        }
    }

    public Team GetWinner()
    {
        int maxScore = 0;
        Team winner = null;
        int winnerCount = 0;
        if (_teams != null)
        {
            foreach(Team team in _teams)
            {
                if(team.GetScore() > maxScore)
                {
                    maxScore = team.GetScore();
                    winner = team;
                }
            }

            foreach(Team team in _teams)
            {
                if (team.GetScore() == maxScore)
                    winnerCount++;
            }
        }

        if (winnerCount > 1)
            return null;
        else
            return winner;
    }

    public void RespawnTeams()
    {
        if(_teams != null)
        {
            foreach(Team team in _teams)
            {
                foreach(Player player in team.GetPlayers())
                {
                    player.Respawn(team.GetSpawnPosition());
                }
            }
        }
    }

    public List<Team> GetTeams()
    {
        return _teams;
    }
}

[Serializable]
public class Team
{
    [SerializeField]
    private string _teamName;

    [SerializeField]
    private Color _teamColor;

    [SerializeField]
    private InputManager _inputManager;

    [SerializeField]
    private Goal _teamGoal; 

    [SerializeField]
    private int _playersCount;

    [SerializeField]
    private Transform _spawnPosition;

    [SerializeField]
    private Text _textScore;

    private int _score;
    private List<Player> _players = new List<Player>();

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public List<Player> GetPlayers()
    {
        return _players;
    }

    public string GetTeamName()
    {
        return _teamName;
    }

    public Goal GetGoal()
    {
        return _teamGoal;
    }

    public void InitializateScore()
    {
        _score = 0;
        SetScore();
    }

    public int GetScore()
    {
        return _score;
    }

    public void IncreaseScore()
    {
        _score++;
        SetScore();
    }

    public void SetScore()
    {
        _textScore.text = _score.ToString();
    }

    public Vector3 GetSpawnPosition()
    {
        return _spawnPosition.position;
    }

    public InputManager GetInputManager()
    {
        return _inputManager;
    }

    public int GetPlayersCount()
    {
        return _playersCount;
    }

    public Color GetColor()
    {
        return _teamColor;
    }
}
