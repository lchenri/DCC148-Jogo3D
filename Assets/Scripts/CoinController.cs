using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] private AudioSource coinSFX;

    void Update()
    {
        transform.Rotate(0, speed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreController.instance.UpdateScore(this.transform.position.z);
            coinSFX.Play();
            Destroy(gameObject);
        }
    }
}
