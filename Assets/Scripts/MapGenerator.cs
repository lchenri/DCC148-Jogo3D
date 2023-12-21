using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] section;
    [SerializeField] private GameObject player;
    [SerializeField] private int zPos = 60;
    private int secNum;
    private int lastSection = 0;
    private float playerZPos;

    void Update()
    {
        playerZPos = player.transform.position.z;

        if (zPos < playerZPos + 300)
        {

            secNum = Random.Range(0, 3);
            while (secNum == lastSection)
            {
                secNum = Random.Range(0, 3);
            }
            lastSection = secNum;
            Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);

            zPos += 60;
        }
    }
}
