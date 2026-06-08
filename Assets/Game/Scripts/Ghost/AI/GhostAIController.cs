using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

public class GhostAIController : MonoBehaviour
{
    [SerializeField] private BehaviorGraphAgent _behaviorGraphAgent;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private PlayerCharacter _target;
    [SerializeField] private SightPerception _sightPerception;

    public BehaviorGraphAgent BehaviorGraphAgent => _behaviorGraphAgent;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public PlayerCharacter Target => _target;
    public SightPerception SightPerception => _sightPerception;

}
