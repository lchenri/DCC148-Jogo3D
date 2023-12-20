using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float playerZPos;
    void Update()
    {
        playerZPos = player.transform.position.z;
        if (transform.name == "Section(Clone)")
        {
            if (playerZPos > transform.position.z + 90)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
