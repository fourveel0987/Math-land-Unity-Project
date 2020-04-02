using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int setPoint = 0;

    public void PlayGame() {
        GameValues.totalPoint = setPoint;
        SceneManager.LoadScene("GameLv1");
    }

    public void ExitGame() {
        Debug.Log("Exit!!!");
        Application.Quit();
    }
}
