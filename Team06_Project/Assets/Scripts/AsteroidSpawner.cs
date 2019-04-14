using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject player;
    public static int currentSpawnerWave;
    public GameObject ship, kingShip;
    public GameObject king, dialog;
    public Transform[] spawnPoints;
    List<Transform> unusedSpawns = new List<Transform>();
    public static float spawnAmount;
    public static bool allAsteroidGone;
    public static float shipsLeft;
    bool lastBattle;

    private void Start()
    {
        // set current wave to 1
        currentSpawnerWave = 1;
        spawnAmount = 0;
        shipsLeft = 1;
    }
    private void Update()
    {
        if(shipsLeft == 0)
        {
            if (!lastBattle)
            {
                if (AsteroidGameManager.currentWave != 2)
                {
                    Camera.main.orthographicSize += 1;
                    AsteroidGameManager.currentWave++;
                    currentSpawnerWave++;
                    //    // get a new list of spawnpoints
                    GetAllSpawns();
                    for (int i = 0; i < currentSpawnerWave; i++)
                    {
                        // get a random spawn point in the list
                        int randomSpawn = Random.Range(0, unusedSpawns.Count);
                        // spawn the asteroid at the random spawn point with no set rotation( so what ever rotation that was initally set when creating the game object)
                        Instantiate(ship, unusedSpawns[randomSpawn].position, Quaternion.identity);
                        // removed the spawned rocks spawn point from the list so we do not spawn at the same point
                        unusedSpawns.Remove(unusedSpawns[randomSpawn]);
                        shipsLeft++;
                        // increase the current amount of rocks spawned at the moment
                    }
                }
                else
                {
                    StartCoroutine(KingEnter());
                }
            }
            else
            {
                Debug.Log("Here");
                AsteroidGameManager.won = true;
            }
            // turn off bool so only fires once in game
        }
        //// if there are no rocks left
        //if(spawnAmount == 0)
        //{
        //    // we can now spawn
        //    allAsteroidGone = true;
        //}
        //// now we spawn if nothing is left
        //if(allAsteroidGone == true)
        //{
        //    // increase the current wave text
        //    AsteroidGameManager.currentWave++;
        //    // increase the amount of rocks we will be spawning by 1
        //    currentSpawnerWave++;
        //    // get a new list of spawnpoints
        //    GetAllSpawns();
        //    // spawn all rocks
        //    for(int i = 0; i < currentSpawnerWave; i++)
        //    {
        //        // get a random spawn point in the list
        //        int randomSpawn = Random.Range(0, unusedSpawns.Count);
        //        // spawn the asteroid at the random spawn point with no set rotation( so what ever rotation that was initally set when creating the game object)
        //        Instantiate(ship, unusedSpawns[randomSpawn].position, Quaternion.identity);
        //        // removed the spawned rocks spawn point from the list so we do not spawn at the same point
        //        unusedSpawns.Remove(unusedSpawns[randomSpawn]);
        //        // increase the current amount of rocks spawned at the moment
        //        spawnAmount++; 
        //    } 
        //    // turn off bool so only fires once in game
        //    allAsteroidGone = false;
        //}
    }
    IEnumerator KingEnter()
    {
        if (king != null)
        {
            player.transform.position = new Vector3(-0.05f, -3.66f);
            player.GetComponent<AsteroidPlayer>().enabled = false;
            player.GetComponent<CircleCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            yield return new WaitForSeconds(.2f);
            lastBattle = true;
            AsteroidGameManager.currentWave = 3;
            king.GetComponent<OnClickNPC>().clicked = true;
            king.SetActive(true);
            shipsLeft = 2;
        }
        else
        {
            player.GetComponent<AsteroidPlayer>().enabled = true;
            player.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
    void GetAllSpawns()
    {
        // clear list of spawns just incase there are some in the list
        unusedSpawns.Clear();
        // for each point in the spawnpoints array
        foreach(var point in spawnPoints)
        {
            // add it to the unused spawn point array
            unusedSpawns.Add(point);
        }
    }
}
