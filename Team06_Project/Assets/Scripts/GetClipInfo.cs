using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetClipInfo : MonoBehaviour
{
    public static AudioSource clip;

    private void Awake()
    {
        clip = GetComponent<AudioSource>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        clip = GetComponent<AudioSource>();
    }
    private void Update()
    {
        clip = GetComponent<AudioSource>();
    }

}
