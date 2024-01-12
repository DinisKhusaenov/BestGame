using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : AirbornState
{
    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
    {
    }
}
