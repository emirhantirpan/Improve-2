using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsStates 
{

}
    // State'ler interface �eklinde methodlara ayr�l�r
    public interface IAnimStates
    {
        void EnterState(CharacterState state);
        void UpdateState(CharacterState state);
        void ExitState(CharacterState state);
    }
