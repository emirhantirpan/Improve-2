using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class IdleState : IAnimStates
{
    // Idle Animasyonu

    public void EnterState(CharacterState state)
    {
        state.Animator.Play(state.IDLE);
        Debug.Log("Idle animasyonu bitti.");
    }
    public void UpdateState(CharacterState state)
    {
        if (state.Agent.velocity != Vector3.zero)
        {
            state.TransitionToState(new WalkState());
        }
        else if (state.isAttacking == true)
        {
            state.TransitionToState(new AttackState());
        }
        else if (state.healthController.health == 0)
        {
            state.TransitionToState(new DieState());
        }
    }
    public void ExitState(CharacterState state)
    {
        Debug.Log("Idle animasyonu bitti.");
    }
}
