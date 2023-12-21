using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(AgentLinkMover))]
public class AI : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    private NavMeshAgent agent;

    public bool movimenta = true;

    public float moveSpeed = 3f;

    public LayerMask layerMask;

    public float minDistanciaAcao = 2f;

    public float horizontalSpeed = 4f;

    public bool isJumping = false;
    public bool goingDown = false;

    public GameObject alvo;

    public float alturaDoPe = 0.1f;
    //[SerializeField]private AnimationCurve m_Curve;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.pathfindingFailed += OnPathfindingFailed;
    }

    /*void Pula()
    {
        if (!isJumping)
            {
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("jumpAnimation");
                StartCoroutine(JumpSequence());
                Debug.Log("Pulo");
            }
    }

    void FinalPulo()
    {
        if (isJumping)
        {
            if (!goingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 5f, Space.World);
            }

            if (goingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -5f, Space.World);
            }
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        //agent.Move(Vector3.forward * moveSpeed * Time.deltaTime);
        agent.SetDestination(alvo.transform.position);


        if(agent.isOnOffMeshLink)
        {

        }

    }

}
