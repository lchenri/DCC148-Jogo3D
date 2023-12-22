using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDemoController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private string Menu;
    void Start()
    {
        Menu = "MenuPrincipal";
    }

    void Update()
    {
        if(player.transform.position.z > 162f)
        {
            Debug.Log("Fim do jogo");
            SceneManager.LoadScene(Menu);
        }
    }
}
