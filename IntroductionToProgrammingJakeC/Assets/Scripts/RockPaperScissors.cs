using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class RockPaperScissors : MonoBehaviour
{
    //Variables for decision of player and AI
    public string playerDecision;
    public string AIDecision;

    //Variable for the text output
    public TMP_Text outputText;

    //Variables for the image component and the sprites
    public Image playerImage;
    public Image AIImage;

    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    //Variables for win streak
    public int winStreak;
    public TMP_Text winStreakText;




    //Player clicks the button to make their decision and we assign the playerDecision variable
    public void DecisionMade(string decision)
    {
        playerDecision = decision;

        if(playerDecision == "Rock")
        {
            //Set player image to rock sprite
            playerImage.sprite = rockSprite;
        }
        else if(playerDecision == "Paper")
        {

            //Set player image to paper sprite
            playerImage.sprite = paperSprite;
        }
        else
        {
            //Set player image to scissor sprite
            playerImage.sprite = scissorsSprite;
        }
        AIPicker();

    }
    
    //Make the AI pick RP or S
    public void AIPicker()
    {
        //create a temporary variable (int) to create a random decsion to assisgn to RP or S
        //0 = R , 1 = P. 2 = S
        int randomNumber = Random.Range(0, 3);

        //run if statements to find out which choice the random number made
        if(randomNumber == 0)
        {
            //rock
            AIDecision = "Rock";
            AIImage.sprite = rockSprite;
        }
        else if(randomNumber == 1)
        {
            //paper
            AIDecision = "Paper";
            AIImage.sprite = paperSprite;
        }
        else
        {
            //scissors
            AIDecision = "Scissors";
            AIImage.sprite = scissorsSprite;
        }
        CheckForOutcome();
    }
   
    //Function to check if the player wins, loses or draws
    public void CheckForOutcome()
    {
        if(playerDecision == AIDecision)
        {
            //Draw
            outputText.text = "Draw - you chose " + playerDecision + " - the computer chose " + AIDecision;
        }
        else
        {
            //Run through each type and compart it to others to see if player wins or loses
            
            //Plyaer chose rock
            if(playerDecision == "Rock")
            {
                if (AIDecision == "Paper")
                {
                    //Player loses
                    outputText.text = "You died - you chose " + playerDecision + "- the computer chose " + AIDecision;
                    winStreak = 0;
                }
                else
                {
                    //Player Wins
                    outputText.text = "You won! - you chose " + playerDecision + "- the computer chose " + AIDecision;
                    winStreak++;
                }
            }
            //Player chose Paper
            else if (playerDecision == "Paper")
            {
                if (AIDecision == "Scissors")
                {
                    //Player loses
                    outputText.text = "You died - you chose " + playerDecision + "- the computer chose " + AIDecision;
                    winStreak = 0;
                }
                else
                {
                    //Player Wins
                    outputText.text = "You won! - you chose " + playerDecision + "- the computer chose " + AIDecision;
                    winStreak++;
                }
            }
            //Player chose scissor
            else
            {
                if (AIDecision == "Rock")
                {
                    //Player loses
                    outputText.text = "You died - you chose " + playerDecision + "- the computer chose " + AIDecision;
                    winStreak = 0;
                }
                else
                {
                    //Player Wins
                    outputText.text = "You won! - you chose " + playerDecision + "- the computer chose " + AIDecision;
                    winStreak++;
                }
            }
        }
        winStreakText.text = "Winstreak = " + winStreak;
    }
}
