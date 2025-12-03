using UnityEngine;
using FallenWing.Module.AdvanceFSM;
public class AdvanceFSMController : AdvanceFSM_Factory
{
    void Start()
    {
        AdvanceFSM_Idle _idle = new AdvanceFSM_Idle(this);
        AdvanceFSM_Walk _walk = new AdvanceFSM_Walk(this);
        AddTransition(new TransitionState(_idle, _walk, DoThings));
        AddTransition(new TransitionState(_walk, _idle, WalkToIdle));
        currentState = _idle;
        currentState.DoOnEnterState();
        Debug.Log("");
    }

    public bool DoThings()
    {
        if (Input.GetKeyDown(KeyCode.Return)) return true;
        return false;
    }

    public bool WalkToIdle()
    {
        if (Input.GetKeyDown(KeyCode.Space)) return true;
        return false;
    }
}
