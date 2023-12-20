using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPricipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoJogo;
    [SerializeField] private string nomeSeletorSkin;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoJogo);
    }

    public void Skin()
    {
        SceneManager.LoadScene(nomeSeletorSkin);
    }

    public void Sair()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
