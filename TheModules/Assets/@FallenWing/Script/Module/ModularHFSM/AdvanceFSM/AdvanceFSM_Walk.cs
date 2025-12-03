using UnityEngine;
using FallenWing.Module.AdvanceFSM;

public class AdvanceFSM_Walk : AdvanceFSM_State<AdvanceFSM_Factory>
{
    public AdvanceFSM_Walk(AdvanceFSM_Factory contex) : base(contex)
    {
    }

    public override void DoOnEnterState()
    {
        Debug.Log("Enter Walk");
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