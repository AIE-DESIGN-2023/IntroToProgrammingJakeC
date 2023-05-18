using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public void ConfirmChoice(bool hasChosenTails)
    {
        //Setting our global variable to the boolean value passed via the button clicked
        choseTails = hasChosenTails;

        //Setting a random number between 1 and 0 to assign heads or tails
        headsOrTails = Random.Range(0, 2);

        //If Heads
        if (headsOrTails == 0)
        {
            //Change text to say heads
            outputText.text = "Coin landed on Heads";

        }
        else
        {
            //Change text to say tails
            outputText.text = "Coin landed on Tails";
        }

        //Win state - Computer and player chose heads
        if(headsOrTails == 0 && choseTails == false)
        {
            outputText.text += " - you also chose heads... you win!";
            winCount++;
        }
        //Win state - Computer and player chose tails
        else if (headsOrTails == 0 && choseTails == true)
        {
            outputText.text += " - you also chose tails... you win!";
            winCount++;
        }
        else
        {
            outputText.text += " - you died";
            loseCount++;
        }
        winCountText.text = "Wins: " + winCount;
        loseCountText.text = "Loses: " + loseCount;
        


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
