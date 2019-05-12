using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogWindowController : MonoBehaviour
{
    [SerializeField]
    private Text _winnerText;

    private void Awake()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
    }

    public void ShowWinner(Team team)
    {
        _winnerText.text = team.GetTeamName() + " WIN!!!";
        _winnerText.color = new Color(team.GetColor().r, team.GetColor().g, team.GetColor().b, 1);
        gameObject.SetActive(true);
    }
}
