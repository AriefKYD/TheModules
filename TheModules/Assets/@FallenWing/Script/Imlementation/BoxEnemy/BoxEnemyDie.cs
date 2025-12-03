using UnityEngine;
using FallenWing.Module.FSM;

public class BoxEnemyDie : FSM_BaseState<BoxEnemyController.BoxEnemyEnum, BoxEnemyController>
{
    public BoxEnemyDie(BoxEnemyController.BoxEnemyEnum stateKey, BoxEnemyController controller) : base(stateKey, controller)
    {
    }

    public override void DoOnEnterState()
    {
        Debug.Log("Die");
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

    public override BoxEnemyController.BoxEnemyEnum NextState()
    {
        return BoxEnemyController.BoxEnemyEnum.Die;
    }
}