using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject noSound;
    static bool audioSource;
    static int count;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        foreach (var music in GameObject.FindGameObjectsWithTag("Music"))
        {
            if (music != this.gameObject)
            {
                Destroy(music);
            }
        }
    }
    public void Music()
    {
        count++;
        if(count == 2)
        {
            count = 0;
        }
        if(count == 0)
        {
            audioSource = true;
        }
        if(count == 1)
        {
            audioSource = false;
        }
        if(audioSource == true)
        {
            if (noSound != null)
            {
                noSound.SetActive(false);
            }
            GetComponent<AudioSource>().enabled = true;
        }
        if (audioSource == false)
        {
            if (noSound != null)
            {
                noSound.SetActive(true);
            }
            GetComponent<AudioSource>().enabled = false;
        }
    }
}
