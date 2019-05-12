using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickRestartButton()
    {
        OnClickStartButton();
    }

    public void OnClickMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
