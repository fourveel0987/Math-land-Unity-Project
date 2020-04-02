using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowTotalPoint : MonoBehaviour
{
    public Text showText;

    private int getPoint;

    public void Start() {
        getPoint = GameValues.totalPoint;
        showText.GetComponent<Text>().text = getPoint.ToString();
    }

    public void onNextButton() {
        SceneManager.LoadScene("GameLv2");
    }

}
