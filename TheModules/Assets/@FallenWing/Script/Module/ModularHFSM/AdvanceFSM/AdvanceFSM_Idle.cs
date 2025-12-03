using UnityEngine;
using FallenWing.Module.AdvanceFSM;
public class AdvanceFSM_Idle : AdvanceFSM_State<AdvanceFSM_Factory>
{
    public AdvanceFSM_Idle(AdvanceFSM_Factory contex) : base(contex)
    {
    }

    public override void DoOnEnterState()
    {
        Debug.Log("Enter Idle");
    }

    public override void DoOnExitState()
    {
    }

    public override void DoOnStateFixedUpdate()
    {
    }

    public override void DoOnStateUpdate()
    {
    }
}
