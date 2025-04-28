using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : IAnimStates
{
    // Attack Animasyonu

    public void EnterState(CharacterState state)
    {
        state.Animator.Play(state.ATTACK);
    }
    public void UpdateState(CharacterState state)
    {
        if (!state.Animator.GetCurrentAnimatorStateInfo(0).IsName(state.ATTACK))
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
        Debug.Log("Attack animasyonu bitti.");
    }
}
