using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickNPC : MonoBehaviour
{
    public bool clicked;

    // If the mouse is pressed on npc, do what is in method
    private void OnMouseDown()
    {
        // foreach npc found with the tag npc, turn off clicked so we do not overlap
        foreach(var npc in GameObject.FindGameObjectsWithTag("NPC"))
        {
            npc.GetComponent<OnClickNPC>().clicked = false;
        }
        // set clicked to true
        clicked = true;
    }
}
