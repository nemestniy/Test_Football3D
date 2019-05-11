using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Ball _ball;

    private Teams _teams;

    private void Awake()
    {
        _teams = GetComponent<Teams>();
        if (_teams != null)
            _teams.InitalizateTeams();
        foreach(Team team in _teams.GetTeams())
        {
            team.GetGoal().MakeGoal += GameManager_MakeGoal;
        }
        Instantiate(_ball.gameObject);
    }

    private void GameManager_MakeGoal(Player player)
    {
        var teams = _teams.GetTeams();
        if (teams != null)
        {
            foreach (Team team in teams)
            {
                if (team.Equals(player.GetTeam()))
                {
                    team.IncreaseScore();
                }
            }
        }
    }
}
