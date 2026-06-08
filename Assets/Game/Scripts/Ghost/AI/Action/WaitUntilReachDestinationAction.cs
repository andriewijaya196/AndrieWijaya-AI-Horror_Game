using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Wait Until Reach Destination", story: "[AI] wait untuil reach destination", category: "Action", id: "af241fdbf9b26df5ae720f4b08008494")]
public partial class WaitUntilReachDestinationAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostAIController> AI;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (AI.Value == null )
        {
            return Status.Failure;
        }

        NavMeshAgent agent = AI.Value.NavMeshAgent;

        if (agent == null)
        {
            return Status.Failure;
        }

        if (agent.pathPending == true)
        {
            return Status.Running;
        }

        if (agent.remainingDistance > agent.stoppingDistance + 0.5)
        {
            return Status.Running;
        }
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

