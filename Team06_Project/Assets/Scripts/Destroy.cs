using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(GameObject.FindGameObjectWithTag("Player") != null ? GameObject.FindGameObjectWithTag("Player") : this.gameObject);
        }
    }
}
