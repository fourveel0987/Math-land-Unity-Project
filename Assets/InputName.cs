using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InputName : MonoBehaviour
{
    public GameObject inputField;
    public GameObject errorDisplay;

    private string theName = ""; // check error for theName != "" if user click ok before input name

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text + "";
        GameValues.theName = theName;
    }

    public void OkButton()
    {
        Debug.Log("OK!!!");
        if (theName != "")
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            errorDisplay.GetComponent<Text>().text = "Plaese enter name";
        }
    }
}
