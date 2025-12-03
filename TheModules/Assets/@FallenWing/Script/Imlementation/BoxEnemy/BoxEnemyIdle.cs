using UnityEngine;
using FallenWing.Module.FSM;

public class BoxEnemyIdle : FSM_BaseState<BoxEnemyController.BoxEnemyEnum, BoxEnemyController>
{
    public BoxEnemyIdle(BoxEnemyController.BoxEnemyEnum stateKey, BoxEnemyController controller) : base(stateKey, controller)
    {
    }

    public override void DoOnEnterState()
    {
        Debug.Log("Idle");
    }

    public override void DoOnExitState()
    {
    }

    public override void DoOnStateFixedUpdate()
    {
    }

    public override void DoOnStateUpdate()
    {
        Debug.Log("Idling");
    }

    public override BoxEnemyController.BoxEnemyEnum NextState()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            return BoxEnemyController.BoxEnemyEnum.Patrol;
        }
        return BoxEnemyController.BoxEnemyEnum.Idle;
    }
}
