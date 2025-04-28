using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class WalkState : IAnimStates
{
    // Walk Animasyonu

    public void EnterState(CharacterState state)
    {
        state.Animator.Play(state.WALK);
    }
    public void UpdateState(CharacterState state)
    {
        if (state.Agent.velocity == Vector3.zero)
        {
            state.TransitionToState(new IdleState());
        }
        else if (state.healthController.health == 0)
        {
            state.TransitionToState(new DieState());
        }
    }
    public void ExitState(CharacterState state)
    {
        Debug.Log("Walk animasyonu bitti.");
    }
}
