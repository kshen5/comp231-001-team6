using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingCheck : MonoBehaviour
{
    public static bool continueClicked;
    public GameObject player;
    public bool king;

    private void Start()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<AsteroidPlayer>().enabled = false;
        continueClicked = false;
    }
    void Update()
    {
        if (continueClicked == true)
        {
            GetComponent<Dialogue>().enabled = false;
            GetComponent<OnClickNPC>().enabled = false;
            GetComponent<Ship>().enabled = true;
            GetComponent<AddStartingForce>().enabled = true;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.GetComponent<CircleCollider2D>().enabled = true;
            player.GetComponent<AsteroidPlayer>().enabled = true;
            continueClicked = false;
            this.enabled = false;
        } 
    }
}
