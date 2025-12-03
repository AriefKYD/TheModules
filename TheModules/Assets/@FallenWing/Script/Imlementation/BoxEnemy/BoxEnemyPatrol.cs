using UnityEngine;
using FallenWing.Module.FSM;

public class BoxEnemyPatrol : FSM_BaseState<BoxEnemyController.BoxEnemyEnum, BoxEnemyController>
{
    public BoxEnemyPatrol(BoxEnemyController.BoxEnemyEnum stateKey, BoxEnemyController controller) : base(stateKey, controller)
    {
    }

    public override void DoOnEnterState()
    {
        Debug.Log("Patrol");
    }

    public override void DoOnExitState()
    {
    }

    public override void DoOnStateFixedUpdate()
    {
    }

    public override void DoOnStateUpdate()
    {
        Debug.Log("Patroling");
    }

    public override BoxEnemyController.BoxEnemyEnum NextState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return BoxEnemyController.BoxEnemyEnum.Idle;
        } 
        
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            return BoxEnemyController.BoxEnemyEnum.Die;
        }
        return BoxEnemyController.BoxEnemyEnum.Patrol;
    }
}
