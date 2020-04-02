using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameTranfer : MonoBehaviour
{
    public GameObject inputField;
    public Text errorText;

    public string theName;
    public string checkInput;

    
    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        GameValues.theName = theName;
    }

    public void OkButton()
    {
        checkInput = GameValues.theName;
        Debug.Log("OK!!!");
        if (checkInput != "")
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            errorText.GetComponent<Text>().text = "Plaese enter name";
        }
    }
}
