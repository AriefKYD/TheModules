using System.Collections.Generic;
using UnityEngine;
namespace FallenWing.Module.FSM
{
    public class FSM_Factory<StateEnum,TController> : MonoBehaviour  where StateEnum: System.Enum where TController : MonoBehaviour
    {
        protected Dictionary<StateEnum, FSM_BaseState<StateEnum, TController>> states = new Dictionary<StateEnum, FSM_BaseState<StateEnum, TController>>();

        protected FSM_BaseState<StateEnum, TController> currentState;

        protected virtual void Start()
        {
            currentState.DoOnEnterState();
        }
        protected virtual void Update()
        {
            StateEnum nextStateKey = currentState.NextState();
            if (!nextStateKey.Equals(currentState.StateKey))
            {
                TransitionToState(nextStateKey);
            }
            currentState.DoOnStateUpdate();
        }

        protected virtual void FixedUpdate()
        {
            currentState.DoOnStateFixedUpdate();
        }

        protected void TransitionToState(StateEnum key)
        {
            currentState.DoOnExitState();
            currentState = states[key];
            currentState.DoOnEnterState();
        }

    }


    public enum ENEMY_STATES
    {
        IDLE,
        CHASE,
        PATROL,
        ATTACK,
        MOVE_POINT,
        WONDER
    }
}