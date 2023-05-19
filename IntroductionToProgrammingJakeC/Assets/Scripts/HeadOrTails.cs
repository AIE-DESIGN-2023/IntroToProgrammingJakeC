using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UI;

public class HeadOrTails : MonoBehaviour
{
    public GameObject[] buttons;
    public bool choseTails;
    public TMP_Text outputText;
    
    public int headsOrTails;

    public int winCount;
    public int loseCount;
    public TMP_Text winCountText;
    public TMP_Text loseCountText;
    public GameObject headsCoin;
    public GameObject tailsCoin;

    private void Start()
    {
        currencyRemaining = currencyMax;
        currencyText.text = "Currency Remaining: " + currencyRemaining.ToString();

        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }

    private void Win()
    {
        winCount++;
        currencyRemaining += betAmount * 2;
    }

    //Curency
    public int currencyRemaining;
    public int currencyMax;
    private int betAmount;
    public TMP_InputField betInput;
    public TMP_Text currencyText;

    public void InputBet()
    {
        //Check that the input is not empty
        if (betInput.text != "")
        {


            //Set bet amount to input text
            betAmount = int.Parse(betInput.text);

            //Check if we have enough money to make bet
            if (betAmount <= currencyRemaining && betAmount > 0)
            {


                //Turn on the heads tails buttons
                foreach (GameObject button in buttons)
                {
                    button.SetActive(true);
                }
            }
            else
            {
                //Turn off the heads tails buttons
                foreach (GameObject button in buttons)
                {
                    button.SetActive(false);
                }
            }
        }
    }

    public void ConfirmChoice(bool hasChosenTails)
    {
        //Take bet amount away from total currency
        currencyRemaining -= betAmount;

        //Setting our global variable to the boolean value passed via the button clicked
        choseTails = hasChosenTails;

        //Setting a random number between 1 and 0 to assign heads or tails
        headsOrTails = Random.Range(0, 2);

        //If Heads
        if (headsOrTails == 0)
        {
            //Change text to say heads
            outputText.text = "Coin landed on Heads";
            headsCoin.SetActive(true);

        }
        else
        {
            //Change text to say tails
            outputText.text = "Coin landed on Tails";
            tailsCoin.SetActive(true);
        }

        //Win state - Computer and player chose heads
        if(headsOrTails == 0 && choseTails == false)
        {
            outputText.text += " - you also chose Heads... you win " + (betAmount * 2) + " moneys!";
            Win();
        }
        //Win state - Computer and player chose tails
        else if (headsOrTails == 1 && choseTails == true)
        {
            outputText.text += " - you also chose Tails... you win " + (betAmount * 2) + " moneys!";
            Win();
        }
        else
        {
            outputText.text += " - you died! " + "the house takes " + betAmount + " moneys from you";
            loseCount++;
        }
        winCountText.text = "Wins: " + winCount;
        loseCountText.text = "Loses: " + loseCount;

        //Update currency text after each win/loss
        currencyText.text = "Currency Remaining: " + currencyRemaining.ToString();

        //Clear input field
        betInput.text = "";

        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
