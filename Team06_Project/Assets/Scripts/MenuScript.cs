using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject soundOff;
    public static bool music;
    public static int soundCount;

    private void Start()
    {
        if (PlayerPrefs.GetString("Music") == "Off")
        {
            PlayerPrefs.SetString("Music", "Off");
            if (soundOff != null)
            {
                soundOff.SetActive(true);
            }
            music = false;
            soundCount = 1;
        }
        else
        {
            PlayerPrefs.SetString("Music", "On");
            if (soundOff != null)
            {
                soundOff.SetActive(false);
            }
            music = true;
            soundCount = 0;
        }
    }
    private void Update()
    {        
        if (music == true)
        {
            if (GetClipInfo.clip != null)
            {
                GetClipInfo.clip.enabled = true;
            }
        }
        if (music == false)
        {
            if (GetClipInfo.clip != null)
            {
                GetClipInfo.clip.enabled = false;
            }
        }
    }
    public void SoundClicked()
    {
        if (soundCount == 0)
        {
            PlayerPrefs.SetString("Music", "Off");
            soundOff.SetActive(true);
            music = false;
        }
        if (soundCount == 1)
        {
            PlayerPrefs.SetString("Music", "On");
            soundOff.SetActive(false);
            music = true;
        }
        soundCount++;
        if (soundCount > 1)
        {
            soundCount = 0;
        }
    }
}
