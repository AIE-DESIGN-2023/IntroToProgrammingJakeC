using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RNGscript : MonoBehaviour
{
    //Random number variables
    public int randomNumber;
    public int randomNumberMin;
    public int randomNumberMax;

    //Text box variables
    public TMP_Text textBox;

    public TMP_InputField inputField;
    public GameObject restartButton;

    //Guesses variables
    public int maxGuesses;
    private int remainingGuesses;
    public TMP_Text guessesText;

    // Start is called before the first frame update
    void Start()
    {
        //Assiging a random number between 1-100 to randomNumber variable
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function to run on button press
    public void CheckNumber()
    {
        //getting the value from the input field and checking whether
        //that is higher, lower or equal to randomNumber

        //Check that input field has a number

        if (inputField.text != "" && remainingGuesses > 0)
        {



            //assign input value to temporary variable
            int playerNumber = int.Parse(inputField.text);
            
         

            //check player value againt random number using if statements
            if (playerNumber == randomNumber)
            {
                //Means the player got the number right
                textBox.text = "Correct!";
                //Turn on restartButton
                restartButton.SetActive(true);
            }
            else if (playerNumber < randomNumber)
            {
                //Means the player number is less than
                textBox.text = "Your guess is low...";

                //Remove 1 from current guesses and update the text
                remainingGuesses--;
                guessesText.text = "Guesses Remaining = " + remainingGuesses.ToString();

            }
            else if (playerNumber == 69)
            {
                textBox.text = "Grow up";
            }

            else
            {
                //Means the player number is more than
                textBox.text = "Your guess is high...";

                //Remove 1 from current guesses and update the text
                remainingGuesses--;
                guessesText.text = "Guesses Remaining = " + remainingGuesses.ToString();
            }
            
        }


        if (remainingGuesses == 0)
        {
            textBox.text = "You Died";
            textBox.color = Color.red;
            restartButton.SetActive(true);
            inputField.gameObject.SetActive(false);
            restartButton.GetComponent<Button>().Select();

        }

        inputField.text = "";
        inputField.ActivateInputField();



    }
    //Function to restart scene
    public void Restart()
    {
        //SceneManager.LoadScene(0);

        //Reset everything in the scene
        textBox.text = "Guess a number between " + randomNumberMin.ToString() + " and " + (randomNumberMax -1).ToString();
        textBox.color = Color.black;
        restartButton.SetActive(false);
        inputField.text = "";
        randomNumber = Random.Range(randomNumberMin, randomNumberMax);
        inputField.Select();
        inputField.gameObject.SetActive(true);

        //Reset guesses text and guesses remaining value
        remainingGuesses = maxGuesses;
        guessesText.text = "Guesses Remaining = " + remainingGuesses.ToString();
    }
}
