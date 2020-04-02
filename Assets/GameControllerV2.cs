using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerV2 : MonoBehaviour
{
    public Text mathText;
    public Text resultText;
    public Text scoreText;
    public Text timeText;
    public Text monsText;
    public Text heroText;
    public Text pointText;
    public Text nameText;
    public Text CountdownDisplay;

    public int timeLeft;
    public int countdowmTime;
    public int currentScore;

    private string inputName;
    private int leftNumber;
    private int rightNumber;
    private int mathOperator; // ( + - * )
    private int trueResult;
    private int falseResult;
    private int monsOne = 3;
    private int monsAtk = 2;
    private int hpHero = GameValues.hpHero;
    private int numTurn = 0;
    private int pointTurn = 100;
    private int totalPoint = 0;

    public void Start()
    {
        heroText.GetComponent<Text>().text = hpHero.ToString();
        countTime();
        runGame();
    }

    public void Update()
    {

    }

    public void runGame()
    {
        timeUp();
        setName();
        setPoint();
        currentScore = 0;
        createMath();
    }

    public void timeUp()
    {
        StartCoroutine(CountdownToPlay());
    }

    IEnumerator CountdownToPlay()
    {
        if (totalPoint == 0)
        {
            yield return new WaitForSeconds(4f);
        }

        while (timeLeft > 0)
        {
            timeText.text = timeLeft.ToString();
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }
        if (timeLeft == 0)
        {
            timeText.text = "0";
            CountdownDisplay.text = "time up!";
            CountdownDisplay.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            CountdownDisplay.text = "attack!";
            yield return new WaitForSeconds(2f);
            CountdownDisplay.gameObject.SetActive(false);
        }
    }

    public void countTime()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        CountdownDisplay.text = "READY!";
        yield return new WaitForSeconds(1f);

        while (countdowmTime > 0)
        {
            CountdownDisplay.text = countdowmTime.ToString();
            yield return new WaitForSeconds(1f);
            countdowmTime--;
        }

        CountdownDisplay.text = "GO!!!";
        yield return new WaitForSeconds(1f);
        CountdownDisplay.gameObject.SetActive(false);
    }

    public void setName()
    {
        inputName = GameValues.theName;
        nameText.GetComponent<Text>().text = inputName.ToString();
    }

    public void setPoint()
    {
        pointText.GetComponent<Text>().text = pointTurn.ToString();
    }

    public void newTurn()
    {
        currentScore = 0;
        scoreText.GetComponent<Text>().text = currentScore.ToString();
        timeAgainDelay();
    }

    public void createMath()
    {
        leftNumber = Random.Range(0, 10);
        rightNumber = Random.Range(0, 10);

        mathOperator = Random.Range(0, 3);

        switch (mathOperator)
        {
            case 0: // +
                trueResult = leftNumber + rightNumber;
                falseResult = trueResult + Random.Range(-2, 2);
                mathText.GetComponent<Text>().text = leftNumber.ToString() + " + " + rightNumber.ToString();
                resultText.GetComponent<Text>().text = falseResult.ToString();
                break;
            case 1: // -
                trueResult = leftNumber - rightNumber;
                falseResult = trueResult + Random.Range(-2, 2);
                mathText.GetComponent<Text>().text = leftNumber.ToString() + " - " + rightNumber.ToString();
                resultText.GetComponent<Text>().text = falseResult.ToString();
                break;
            case 2: // *
                trueResult = leftNumber * rightNumber;
                falseResult = trueResult + Random.Range(-2, 2);
                mathText.GetComponent<Text>().text = leftNumber.ToString() + " * " + rightNumber.ToString();
                resultText.GetComponent<Text>().text = falseResult.ToString();
                break;
            default:
                break;
        }

        if (currentScore < 0)
        {
            scoreText.GetComponent<Text>().text = "0";
        }
        else
        {
            scoreText.GetComponent<Text>().text = currentScore.ToString();
        }
    }

    public void onTrueButton()
    {
        if (countdowmTime == 0)
        {
            if (timeLeft > 0)
            {
                if (trueResult == falseResult)
                {
                    currentScore += 1;
                    createMath();
                }
                else
                {
                    currentScore -= 1;
                    createMath();
                }
            }
        }
    }

    public void onFalseButton()
    {
        if (countdowmTime == 0)
        {
            if (timeLeft > 0)
            {
                if (trueResult != falseResult)
                {
                    currentScore += 1;
                    createMath();
                }
                else
                {
                    currentScore -= 1;
                    createMath();
                }
            }
        }
    }

    public void getAttack()
    {
        if (timeLeft == 0)
        {
            if (currentScore >= monsOne)
            {
                monsOne = 0;
                monsText.GetComponent<Text>().text = monsOne.ToString();
                numTurn += 0;
                scoreUpdate();
            }
            if (currentScore < monsOne)
            {
                monsOne -= currentScore;
                monsText.GetComponent<Text>().text = monsOne.ToString();
                hpHero -= monsAtk;
                turnMonsAtk();
            }
            totalPoint = pointTurn - (numTurn * 10);
            pointText.GetComponent<Text>().text = totalPoint.ToString();
        }
    }

    public void loseGame()
    {
        GameValues.totalPoint += totalPoint;
        GameValues.hpHero = hpHero;
        SceneManager.LoadScene("totalPointV2");
    }

    public void onSurrenderButton()
    {
        SceneManager.LoadScene("ShowScore");
    }

    public void scoreUpdate()
    {
        if (monsOne == 0)
        {
            totalPoint = pointTurn - (numTurn * 10);
            pointText.GetComponent<Text>().text = totalPoint.ToString();
            timeNextDelay();
        }
    }

    public void timeNextDelay()
    {
        StartCoroutine(CountdownToDelay());
    }

    IEnumerator CountdownToDelay()
    {
        yield return new WaitForSeconds(3f);
        CountdownDisplay.text = "GREAT!";
        CountdownDisplay.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        loseGame();
    }

    public void timeAgainDelay()
    {
        StartCoroutine(CountdownToAgain());
    }

    IEnumerator CountdownToAgain()
    {
        yield return new WaitForSeconds(2f);
        CountdownDisplay.text = "Try";
        CountdownDisplay.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        CountdownDisplay.text = "agian!";
        yield return new WaitForSeconds(1f);
        CountdownDisplay.text = "GO!!!";
        yield return new WaitForSeconds(1f);
        CountdownDisplay.gameObject.SetActive(false);
        timeLeft = 10;
        timeUp();
        createMath();
    }

    public void turnMonsAtk()
    {
        StartCoroutine(CountdownToTurn());
    }

    IEnumerator CountdownToTurn()
    {
        GameValues.hpHero = hpHero;
        yield return new WaitForSeconds(2f);
        CountdownDisplay.text = "Turn";
        CountdownDisplay.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        CountdownDisplay.text = "monster!";
        yield return new WaitForSeconds(1f);
        CountdownDisplay.gameObject.SetActive(false);
        if (hpHero <= 0)
        {
            heroText.GetComponent<Text>().text = "0";
            yield return new WaitForSeconds(2f);
            CountdownDisplay.text = "Game Over!!";
            CountdownDisplay.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            CountdownDisplay.gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("ShowScore");
        }
        else
        {
            heroText.GetComponent<Text>().text = hpHero.ToString();
        }
        numTurn += 1;
        totalPoint = pointTurn - (numTurn * 10);
        pointText.GetComponent<Text>().text = totalPoint.ToString();
        newTurn();
    }
}
