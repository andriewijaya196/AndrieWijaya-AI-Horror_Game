using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Target is Hiding", story: "Set [TargetisHiding] from [AI]", category: "Action", id: "cc7b319075dbf412dc2b4cabea3cbbb5")]
public partial class SetTargetIsHidingAction : Action
{
    [SerializeReference] public BlackboardVariable<bool> TargetisHiding;
    [SerializeReference] public BlackboardVariable<GhostAIController> AI;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (AI.Value == null && AI.Value.Target == null)
        {
            return Status.Failure;
        }
        TargetisHiding.Value = AI.Value.Target.IsHiding;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

