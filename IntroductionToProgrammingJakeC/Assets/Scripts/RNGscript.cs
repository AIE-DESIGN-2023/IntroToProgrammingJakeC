using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RNGscript : MonoBehaviour
{
    public int randomNumber;
    public TMP_Text textBox;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        //Assiging a random number between 1-100 to randomNumber variable
        randomNumber = Random.Range(1, 101);

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

        if (inputField.text != "")
        {



            //assign input value to temporary variable
            int playerNumber = int.Parse(inputField.text);

            //check player value againt random number using if statements
            if (playerNumber == randomNumber)
            {
                //Means the player got the number right
                textBox.text = "Correct!";
            }
            else if (playerNumber < randomNumber)
            {
                //Means the player number is less than
                textBox.text = "Your guess is low...";

            }
            else if (playerNumber == 69)
            {
                textBox.text = "Nice :^)";
            }

            else
            {
                //Means the player number is more than
                textBox.text = "Your guess is high...";
            }

        }


    }
}
