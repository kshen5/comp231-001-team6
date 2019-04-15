using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingBlink : MonoBehaviour
{
    int count, blinkCount;
    float nextTime;

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
    private void Update()
    {
        if(Time.time > nextTime)
        {
            nextTime = Time.time + .3f;
            if (count == 0)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                blinkCount++;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            count++;
            if(count == 2)
            {
                count = 0;
            }
            if(blinkCount == 3)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = true;
                this.enabled = false;
            }
        }
    }
}
