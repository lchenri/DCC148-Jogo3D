using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    public static float leftBound = -1.5f;
    public static float rightBound = 1.5f;
    public float left;
    public float right;

    // Update is called once per frame
    void Update()
    {
        left = leftBound;
        right = rightBound;
    }
}
