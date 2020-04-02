using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseGame : MonoBehaviour
{
    public Text totalScoreText;
    public Text nameText;

    private int pointIn;
    private string inputName;

    public void Start() {
        inputName = GameValues.theName;
        nameText.GetComponent<Text>().text = inputName.ToString();
        pointIn = GameValues.totalPoint;
        totalScoreText.GetComponent<Text>().text = pointIn.ToString();
    }
    public void onMenuButtonClick() {
        SceneManager.LoadScene("Main");
    }
}
