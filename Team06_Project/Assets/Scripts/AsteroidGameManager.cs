using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidGameManager : MonoBehaviour
{
    public GameObject youDied, npc, gameWon;
    public TextMeshProUGUI score, highscore, wave;
    public static float currentScore, currentWave;
    public static bool gameOver, startOfGame, won;
    public float enemyBulletForce;

    private void Start()
    {
        LoadHighscore();
        currentScore = 0;
        currentWave = 1;
        youDied.SetActive(false);
        startOfGame = true;
        StartCoroutine(ShowDialog());
    }
    private void Update()
    {
        Ship.bulletForce = enemyBulletForce;
        if(won == true)
        {
            foreach(var bullet in GameObject.FindGameObjectsWithTag("Enemy Bullet"))
            {
                Destroy(bullet);
            }
            SaveHighscore();
            gameWon.SetActive(true);
            won = false;
        }
        // Sets the score
        score.text = currentScore.ToString();
        // sets the wave
        wave.text = currentWave.ToString();
        // If player is hit by asteriod, do something like open game over screen
        if(gameOver == true)
        {
            foreach (var bullet in GameObject.FindGameObjectsWithTag("Enemy Bullet"))
            {
                Destroy(bullet);
            }
            SaveHighscore();
            youDied.SetActive(true);
            gameOver = false;
        }
    }
    IEnumerator ShowDialog()
    {
        yield return new WaitForSeconds(.05f);
        npc.GetComponent<OnClickNPC>().clicked = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void SaveHighscore()
    {
        // If the current score is greater than the saved score
        if (currentScore > PlayerPrefs.GetFloat("Highscore"))
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
