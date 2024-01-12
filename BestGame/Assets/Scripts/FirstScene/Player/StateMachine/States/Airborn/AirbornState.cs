using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AirbornState : MovementState
{
    protected AirbornState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
    {
    }
}
