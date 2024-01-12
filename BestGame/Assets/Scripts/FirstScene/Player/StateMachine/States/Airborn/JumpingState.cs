using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : AirbornState
{ 
    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
    {
    }
}
