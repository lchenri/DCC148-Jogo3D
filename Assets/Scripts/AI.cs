using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private NavMeshAgent agent;

    public float moveSpeed = 3f;

    public LayerMask layerMask;

    public float minDistanciaAcao = 2f;

    public float horizontalSpeed = 4f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.Move(Vector3.forward * moveSpeed * Time.deltaTime);
        Vector3 forwardDirection = agent.transform.forward;
        NavMeshHit hit;
        if (NavMesh.Raycast(agent.transform.position, forwardDirection, out hit, NavMesh.AllAreas))
        {
            Debug.DrawLine(agent.transform.position, hit.position, Color.red);

            // Verifica se a distância do ponto de impacto é menor que a distância mínima desejada
            if (Vector3.Distance(agent.transform.position, hit.position) <= minDistanciaAcao)
            {
                Debug.Log("Ponto de impacto dentro da distância mínima de ação");
                Vector3 hitObjectDirection = hit.position;

                // Verifica se deve virar à esquerda ou à direita do objeto de impacto
                if(agent.transform.position.x < 0)
                {
                    Debug.Log("Agente à esquerda do ponto de impacto");
                    agent.transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
                }
                else
                {
                    Debug.Log("Agente à direita do ponto de impacto");
                    agent.transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
                }
                

                /*// Verifica se o ponto de impacto está à esquerda ou à direita do agente
                if (hitObjectDirection.x < agent.transform.position.x)
                {
                    Debug.Log("Ponto de impacto à esquerda do agente");
                    // Se o ponto de impacto estiver à esquerda do agente, vire à esquerda
                    agent.transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);

                }
                else if (hitObjectDirection.x > agent.transform.position.x)
                {
                    Debug.Log("Ponto de impacto à direita do agente");
                    // Se o ponto de impacto estiver à direita do agente, vire à direita
                    agent.transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
                }
                else
                {
                    Debug.Log("Ponto de impacto à frente do agente");
                    // Se o ponto de impacto estiver à frente do agente, analisa a posição do objeto de impacto e decide se deve virar à esquerda ou à direita
                    
                }*/
            }
        }
        else
        {
            // Se não houver colisão com o NavMesh, você pode desenhar um raio mais longo para fins de depuração
            Debug.DrawRay(agent.transform.position, forwardDirection * 100f, Color.green);
        }


    }
}
