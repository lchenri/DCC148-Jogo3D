using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject countdown;
    private GameObject count3;
    private GameObject count2;
    private GameObject count1;
    private GameObject countGo;

    void Start()
    {
        count3 = countdown.transform.GetChild(0).gameObject;
        count2 = countdown.transform.GetChild(1).gameObject;
        count1 = countdown.transform.GetChild(2).gameObject;
        countGo = countdown.transform.GetChild(3).gameObject;

        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(0.8f);
        count3.SetActive(true);
        yield return new WaitForSeconds(1);
        count2.SetActive(true);
        yield return new WaitForSeconds(1);
        count1.SetActive(true);
        yield return new WaitForSeconds(1);
        countGo.SetActive(true);
        yield return new WaitForSeconds(1);
        count1.SetActive(false);
        count2.SetActive(false);
        count3.SetActive(false);
        countGo.SetActive(false);
        PlayerMovement.running = true;
    }
}

