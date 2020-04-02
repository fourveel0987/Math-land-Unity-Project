using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public Text CountdownDisplay;

    public int countdowmTime;

    public void Start() {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart() {
        CountdownDisplay.text = "READY!";

        yield return new WaitForSeconds(1f);

        while (countdowmTime > 0) {
            CountdownDisplay.text = countdowmTime.ToString();

            yield return new WaitForSeconds(1f);

            countdowmTime--;
              
        }

        CountdownDisplay.text = "GO!";

        // GameController.Start();

        yield return new WaitForSeconds(1f);

        CountdownDisplay.gameObject.SetActive(false);
    }
}
