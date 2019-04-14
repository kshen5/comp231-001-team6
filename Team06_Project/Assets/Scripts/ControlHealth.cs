using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHealth : MonoBehaviour
{
    public Transform mask;
    public float[] spots;
    public bool dead;
    public bool hit;
    int index;

    void Update()
    {
        if(hit)
        {
            mask.localPosition = new Vector3(spots[index], mask.localPosition.y);
            index++;
            if(index == spots.Length)
            {
                Destroy(transform.parent.gameObject);
                AsteroidGameManager.currentScore += 2;
                AsteroidSpawner.spawnAmount -= .5f;
            }
            hit = false;
        }
    }
}
