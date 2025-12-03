using FallenWing.Module.FSM;
using UnityEngine;

namespace FallenWing.Behavior.NPC.Minion
{
    public class FSM_MinionIdle : FSM_BaseState<MinionController.MinionState, MinionController>
    {
        public FSM_MinionIdle(MinionController.MinionState stateKey, MinionController controller) : base(stateKey, controller)
        {
        }

        public override void DoOnEnterState()
        {
            Debug.Log("Enter idle state");
        }

        public override void DoOnExitState()
        {
            Debug.Log("Exit idle state");
        }

        public override void DoOnStateFixedUpdate()
        {

        }

        public override void DoOnStateUpdate()
        {

        }

        public override MinionController.MinionState NextState()
        {
            return MinionController.MinionState.Idle;
        }
    }
}