using UnityEngine.AI;
using UnityEngine;

public class MoveToDistance : Task
{
     Transform player;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float stopDistance;

    private void Awake()
    {
        player = FindObjectOfType<Player>().transform;
    }

    public override bool Execute()
    {
        float d = Vector3.Distance(TargetAI.transform.position, player.position);
        if (d<=stopDistance)
        {
            return false;
        }
        else
        {
            agent.SetDestination(player.position);
            return true;
        }
    }
}