using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCamera : MonoBehaviour
{
    public Transform target;
    public float trailDistance = 5.0f;
    public float heightOffset = 3.0f;
    public float cameraDelay = 0.02f;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position - (target.forward * trailDistance);

        pos.y += heightOffset;
        transform.position += (pos - transform.position) * cameraDelay;

        transform.LookAt(target);

    }
}
