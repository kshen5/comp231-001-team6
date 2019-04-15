using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour
{
    Vector2 screenSize;

    private void Start()
    {

    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if Avatar/James hits collectable then it removes the graphic
        if (collision.gameObject.tag.Equals("Player"))
        {
            Player.partsCount += 1;
            Destroy(gameObject);
            Player.ShipCounter();
        }
    }
}