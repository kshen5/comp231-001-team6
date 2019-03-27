using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeOutline : MonoBehaviour
{
    void Start()
    {
        // Changes the text colors outline to match the original color of text
        GetComponent<TextMeshProUGUI>().outlineColor = GetComponent<TextMeshProUGUI>().color;
    }
}
