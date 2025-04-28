using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IAnimStates
{
    // �l�m Animasyonu

    public void EnterState(CharacterState state)
    {
        state.Animator.Play(state.DIE);
    }
    public void UpdateState(CharacterState state)
    {
        Debug.Log("�l�yor.");
    }
    public void ExitState(CharacterState state)
    {
        Debug.Log("�ld�.");
    }
}
