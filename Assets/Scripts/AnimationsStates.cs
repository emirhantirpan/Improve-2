using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsStates 
{

}
    // State'ler interface þeklinde methodlara ayrýlýr
    public interface IAnimStates
    {
        void EnterState(CharacterState state);
        void UpdateState(CharacterState state);
        void ExitState(CharacterState state);
    }
