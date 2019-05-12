using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public delegate void GoalEvents(Player player);
    public event GoalEvents MakeGoal;

    private Team _team;
    private BoxCollider _goalArea;

    private void Awake()
    {
        _goalArea = GetComponent<BoxCollider>();
    }

    public void InitializateTeam(Team team)
    {
        _team = team;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            //Проверка на событие забитого гола в свои ворота 
            var ball = other.transform.GetComponent<Ball>();
            if(ball != null)
            {
                if(!ball.GetLastPlayer().GetTeam().Equals(_team))
                    MakeGoal(ball.GetLastPlayer());
            }
        }
    }
}
