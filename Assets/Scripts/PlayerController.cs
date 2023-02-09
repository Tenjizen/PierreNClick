using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;

    public IInteractable Interactable;
    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (NavMeshAgent.isOnNavMesh &&   NavMeshAgent.pathPending == false)
        {
            if (NavMeshAgent.remainingDistance <= NavMeshAgent.stoppingDistance)
            {
                if (NavMeshAgent.hasPath == false || NavMeshAgent.velocity.sqrMagnitude >= 0.01f)
                {
                    if (Interactable != null)
                        Action(Interactable);
                }
            }
        }
    }
    public void Action(IInteractable interactable)
    {
        interactable.Execute();
        Interactable = null;
    }
    public void Move(Vector3 position)
    {
        NavMeshAgent.destination = position;
    }
}
