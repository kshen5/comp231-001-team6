using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBomb : MonoBehaviour
{

    public Vector3 direction;
    public float speed;

    public void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);
    }
}
