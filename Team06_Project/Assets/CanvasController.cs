using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public void PlayIntroButton()
    {
        SceneManager.LoadScene("Intro");
    }
    public void PlayGameButton()
    { 
        SceneManager.LoadScene("Game"); 
    }
    public void MenuButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
