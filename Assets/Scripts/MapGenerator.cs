using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] section;
    public GameObject player;
    public int zPos = 60;
    public bool generating = false;
    public int secNum;
    private int lastSection;
    private float sectionTime;

    void Update()
    {
        sectionTime = 0;
        if (generating == false)
        {
            generating = true;
            StartCoroutine(GenerateSection());
        }
    } 

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        lastSection = secNum;
        sectionTime = 60 / player.GetComponent<PlayerMovement>().moveSpeed;

        while (secNum == lastSection)
        {
            secNum = Random.Range(0, 3);
        }

        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 60;
        yield return new WaitForSeconds(sectionTime);
        generating = false;
    }
}
