using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroySection());
    }

    IEnumerator DestroySection()
    {
        if (transform.name == "Section(Clone)")
        {
            yield return new WaitForSeconds(80);
            Destroy(gameObject);
        }
    }
}
