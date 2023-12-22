using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPricipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoJogo;
    [SerializeField] private string nomeTutorial;
    [SerializeField] private GameObject painelScore;
    [SerializeField] private GameObject painelMenu;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoJogo);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(nomeTutorial);
    }

    public void AbrirScore()
    {
        painelMenu.SetActive(false);
        painelScore.SetActive(true);
    }

    public void FecharScore()
    {
        painelMenu.SetActive(true);
        painelScore.SetActive(false);
    }

    public void Sair()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
