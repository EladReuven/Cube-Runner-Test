using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 2.0f;

    private void Update()
    {

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.position , speed * Time.deltaTime);
    }
}
