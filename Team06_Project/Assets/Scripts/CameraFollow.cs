using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float negX, x;

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, -31, 0), 0, -10);
    }
}
