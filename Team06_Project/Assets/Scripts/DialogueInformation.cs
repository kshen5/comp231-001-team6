using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueInformation
{
    // information to fill in, make sure it doesn't inherit from MonoBehaviour or will not work
    public string characterName;
    [TextArea]
    public string sentence;
}
