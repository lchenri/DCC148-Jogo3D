using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent), typeof(AgentLinkMover))]
public class AI : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private string Menu;
    private NavMeshAgent agent;

    public GameObject alvo;

    private Quaternion initialRotation;

    private Animator animator;

    



    void Start()
    {
        animator = playerObject.GetComponent<Animator>();
        animator.SetBool("Running", true);
        initialRotation = transform.rotation;
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        agent.SetDestination(alvo.transform.position);
        agent.transform.rotation = initialRotation;

        //se o player estiver perto do final do cenário, volta para o menu
        if(agent.transform.position.z == 162f)
        {
            Debug.Log("Fim do jogo");
            SceneManager.LoadScene(Menu);
        }
    }

}
