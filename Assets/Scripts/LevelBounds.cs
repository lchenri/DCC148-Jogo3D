using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    public static float leftBound = 16f;
    public static float rightBound = 20f;
    public float left;
    public float right;

    // Update is called once per frame
    void Update()
    {
        left = leftBound;
        right = rightBound;
    }
}
