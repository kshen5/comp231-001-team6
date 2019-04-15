using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is the game controller, this controls different aspects of the game like, What the Menu Buttons do, when to start, end, etc..
public class GameController : MonoBehaviour
{
    public static OnClickNPC currentNPCClicked;
    public GameObject dialogueBox;

    // Methods for score will be in the script
    public TextMeshProUGUI score, highscore;

    // in the inspector, check this to true if using a score based system
    public bool scoreBased;

    // Static variables (values that do not change and can be edited by just calling to the script from other scripts)
    public static bool gameOver; // gameover is static because we will be asking another script if player has died or not
    public static float currentScore; // currentscore is static because we want to see if an object died from another script


    void Start()
    {
        if(scoreBased == true)
        {
            LoadHighscore();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true)
        {
            // if game is over, show end screen and do this only once, so turn of bool after it is done (reason it's off is because update runs 60 times a second, so it will do the game over 60 times a seconds and will cause major lag if not)
            gameOver = false;
        }
        if(scoreBased == true)
        {
            KeepTrackOfScore();
        }
    }
    public void Continue()
    {
        TypingCheck.continueClicked = true;
        dialogueBox.SetActive(false);
        currentNPCClicked.clicked = false;
    }
    // show the current score as a text
    void KeepTrackOfScore()
    {
        score.text = currentScore.ToString();
    }
    void SaveHighscore()
    {
        // If the current score is greater than the saved score
        if(currentScore > PlayerPrefs.GetFloat("Highscore"))
        {
            // current score will now be the highscore
            PlayerPrefs.SetFloat("Highscore", currentScore);
            // show highscore as a text so player can see
            highscore.text = currentScore.ToString();
        }
    }
    void LoadHighscore()
    {
        // load the highscore and make it a text so the player can see
        highscore.text = PlayerPrefs.GetFloat("Highscore", 0).ToString();
    }
}
