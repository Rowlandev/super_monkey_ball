using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System; // used for exception handling

public class UICanvas : MonoBehaviour
{

    // PRIVATE ATTRIBUTES

    private int numZeroesNeeded;
    private int scoreValue;
    private float timeLeft;
    private bool gameEnded;

    // PUBLIC ATTRIBUTES

    public Text timeLabel;
    public Text scoreLabel;

    // CONSTRUCTORS

    private void Start() {

        timeLeft = 60f; // where the timer starts
        timeLabel.text = getTimeLeft().ToString(); // updates time with calculated value
        scoreLabel.text = "00000"; // initial text for score
        scoreValue = 0; // beginning score
        numZeroesNeeded = 0;
        gameEnded = false;
    }

    // GETTERS

    public float getTimeLeft() {
        return this.timeLeft;
    }

    // SETTERS

    public void incrementScoreLabelValueAndUpdate(int enteredScoreLabelValue) {
        this.scoreValue += enteredScoreLabelValue; // update score value
        scoreLabel.text = scoreValue.ToString(); // update score label with calculated score value

        // .PadLeft(numZeroesNeeded, '0')
        numZeroesNeeded = 6 - scoreValue.ToString().Length;
        string updatedScore = scoreValue.ToString().PadLeft(numZeroesNeeded, '0');
        scoreLabel.text = updatedScore;
    }

    private void Update()
    {

        try
        {
           updateTime();
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.StackTrace);
        }
    }

    // PUBLIC METHODS

    public void updateTime()
    {

        // check if timeLabel is Null
        if (timeLabel == null)
        {
            throw new System.Exception("We caught the Null Reference Exception!");
        }

        if (timeLeft > 0 && gameEnded == false)
        {
            timeLeft -= Time.deltaTime;
            timeLabel.text = timeLeft.ToString("F");
        }
        else if (timeLeft <= 0 && gameEnded == true)
        { // this is where the player has lost
            timeLabel.text = "00:00";
        }
    }

    public void updateScore(int value)
    {
        incrementScoreLabelValueAndUpdate(value);
    }

    public void endGame(Player currentPlayer)
    {
        gameEnded = true;
        currentPlayer.setIsMoveable(false);
    }

}

