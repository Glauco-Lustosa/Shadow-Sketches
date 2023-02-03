using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
   public PlayerState CurrentSate { get; private set;}

    public void Initialize(PlayerState startingState)
    {
        CurrentSate = startingState;
        CurrentSate.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentSate.Exit();
        CurrentSate = newState;
        CurrentSate.Enter();
    }
}
