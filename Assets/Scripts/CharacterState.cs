using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterState : MonoBehaviour
{
    // State Patern ile animasyon kontrolleri gerçekleþir

    public string IDLE = "Idle";
    public string WALK = "Walk";
    public string ATTACK = "Attack";
    public string DIE = "Die";

    public bool isAttacking;

    private IAnimStates currentState;
    public HealthController healthController;
    public Animator Animator { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    void Start()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        TransitionToState(new IdleState());
    }
    void Update()
    {
        currentState?.UpdateState(this);
    }
    public void TransitionToState(IAnimStates newState)
    {
        currentState?.ExitState(this); 
        currentState = newState;
        currentState.EnterState(this); 
    }
}
