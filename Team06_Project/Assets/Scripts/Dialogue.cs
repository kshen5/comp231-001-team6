using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    // Variables
    public GameObject dialogueBox;
    public DialogueInformation dialogue;
    public TextMeshProUGUI sentence, characterName;
    float nextLetter;
    int letterIndex;
    public bool finishedTying;
    bool on;

    private void Update()
    {
        // Go to OnClickNPC script and check if it is clicked or not
        if (GetComponent<OnClickNPC>().clicked == true)
        {
            // if it is, set on to true and show the dialogue box with the name given
            on = true;
            dialogueBox.SetActive(true);
            characterName.text = dialogue.characterName;
            GameController.currentNPCClicked = GetComponent<OnClickNPC>();
        }
        else
        {
            // else on will stay false
            on = false;
        }
        if (on == true)
        {
            // see if we are still typing or if we are finished
            if (finishedTying == false)
            {
                // clear the last sentence
                if(nextLetter < .2f)
                {
                    sentence.text = "";
                }
                Debug.Log(dialogue.sentence);
                // if the time in game is more than the amount of nextLetter, do what is in the if statement
                if (Time.time > nextLetter)
                {
                    // add the time and .5f seconds to nextLetter
                    nextLetter = Time.time + .05f;
                    // add each character of the dialogues sentence to the sentence text in dialogue box
                    sentence.text += dialogue.sentence[letterIndex].ToString();
                    // increase the letter index
                    letterIndex++;
                    // if we have reached the max length, then we are finished typing and nextLetter will go back to 0, incase we click npc again and want to see the dialogue again
                    if (letterIndex == dialogue.sentence.Length)
                    {
                        // we can enable the continue button here
                        finishedTying = true;
                        nextLetter = 0;
                    }
                }
            }
        }
    }

}
