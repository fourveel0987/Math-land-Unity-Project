using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Text welcomeText;

    private string wel;
    private string input;

    public void Start()
    {
        input = GameValues.theName;
        wel = "Welcome " + input + " to the game!!!";
        welcomeText.GetComponent<Text>().text = wel;
    }

}
