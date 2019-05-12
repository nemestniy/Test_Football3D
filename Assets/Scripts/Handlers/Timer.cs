using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text _minutes;

    [SerializeField]
    private Text _seconds;

    public void UpdateTime(int seconds)
    {
        int minutes = seconds / 60;
        _minutes.text = minutes.ToString();

        int restOfSeconds = seconds % 60;
        _seconds.text = restOfSeconds.ToString();
    }
}
