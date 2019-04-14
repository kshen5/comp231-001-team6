using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStartingForce : MonoBehaviour
{
    private void Start()
    {
        // get a random value
        float randomX = Random.Range(1, 2);
        float randomY = Random.Range(1, 2);
        // get another random value
        int randomNegative = Random.Range(1, 5);
        // change the randomX and randomY to negative to get different directions the objects can move in space instead of a steady direction
        RandomNegative(randomNegative, randomY, randomX);
    }
    private void RandomNegative(int randomNegative, float randomY, float randomX)
    {
        if (randomNegative == 1)
        {
            // this object moves more to the left and goes up
            GetComponent<Rigidbody2D>().AddForce(new Vector3(-randomX, randomY), ForceMode2D.Impulse);
        }
        if (randomNegative == 2)
        {
            // this object moves more to the right and goes down
            GetComponent<Rigidbody2D>().AddForce(new Vector3(randomX, -randomY), ForceMode2D.Impulse);
        }
        if (randomNegative == 3)
        {
            // this object moves more to the left and goes down
            GetComponent<Rigidbody2D>().AddForce(new Vector3(-randomX, -randomY), ForceMode2D.Impulse);
        }
        if (randomNegative == 4)
        {
            // this object moves more to the right and goes up
            GetComponent<Rigidbody2D>().AddForce(new Vector3(randomX, randomY), ForceMode2D.Impulse);
        }
    }
}
