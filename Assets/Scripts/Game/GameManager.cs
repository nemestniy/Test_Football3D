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
            //Подписка на события забитого гола
            team.GetGoal().MakeGoal += GameManager_MakeGoal;
        }

        //Создание мяча
        Instantiate(_ball.gameObject);
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
                }
            }
        }
    }
}
