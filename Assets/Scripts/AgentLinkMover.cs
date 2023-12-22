using UnityEngine;
using UnityEngine.AI;
using System.Collections;



[RequireComponent(typeof(NavMeshAgent))]
public class AgentLinkMover : MonoBehaviour
{

    public delegate void LinkEvent();
    public LinkEvent OnLinkStart;
    public LinkEvent OnLinkEnd;
    public Animator animator;

    private Quaternion initialRotation;


    IEnumerator Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
        initialRotation = transform.rotation;
        agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                OnLinkStart?.Invoke();
               
                yield return StartCoroutine(Parabola(agent, 2.0f, 0.5f));
                
                agent.CompleteOffMeshLink();
                OnLinkEnd?.Invoke();
                transform.rotation = initialRotation;
            }
            animator.Play("Standard Run");
            yield return null;
        }
    }

    IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float normalizedTime = 0.0f;
        while (normalizedTime < 1.0f)
        {
            float yOffset = height * 4.0f * (normalizedTime - normalizedTime * normalizedTime);
            
            animator.Play("jumpAnimation");
            transform.rotation = initialRotation;
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }

}