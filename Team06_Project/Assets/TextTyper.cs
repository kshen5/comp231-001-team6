using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Text writer effect for the introduction & instructions text
public class TextTyper : MonoBehaviour
{
    TextMeshProUGUI sentence;
    public string sentenceToType;
    public bool typeScript;
    float nextLetter;
    bool doneTyping;
    int index;

    private void Start()
    {
        sentence = GetComponent<TextMeshProUGUI>();
        if (typeScript == false)
        {
            sentence.text = sentenceToType;
        }
        else
        {
            sentence.text = "";
        }
    }
    private void Update()
    {
        if (typeScript == true)
        {
            if (doneTyping == false)
            {
                if (Time.time > nextLetter)
                {
                    nextLetter = Time.time + .05f;
                    sentence.text += sentenceToType[index];
                    index++;
                    if (index == sentenceToType.Length)
                    {
                        doneTyping = true;
                    }
                }
            }
        }
    }
}
