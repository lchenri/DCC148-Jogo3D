using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDemoController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private string Menu;
    // Start is called before the first frame update
    void Start()
    {
        Menu = "MenuPrincipal";
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z > 162f)
        {
            Debug.Log("Fim do jogo");
            SceneManager.LoadScene(Menu);
        }
    }
}
