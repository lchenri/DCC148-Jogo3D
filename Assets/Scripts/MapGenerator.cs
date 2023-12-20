using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] section;
    [SerializeField] private GameObject player;
    [SerializeField] private int zPos = 60;
    private bool generating = false;
    private int secNum;
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
        sectionTime = 40 / player.GetComponent<PlayerMovement>().moveSpeed;

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
