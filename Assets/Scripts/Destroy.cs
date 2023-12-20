using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    private float playerZPos;
    void Start()
    {
        StartCoroutine(DestroySection());
    }

    IEnumerator DestroySection()
    {
        if (transform.name == "Section(Clone)")
        {
            yield return new WaitForSeconds(30);
            playerZPos = player.transform.position.z;
            if (playerZPos < transform.position.z + 60)
            {
                yield return new WaitForSeconds(25);
            }
            Destroy(gameObject);
        }
    }
}
