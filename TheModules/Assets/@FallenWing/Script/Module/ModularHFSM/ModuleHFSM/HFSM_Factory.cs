using System.Collections.Generic;
using UnityEngine;
namespace FallenWing.Module.HFSM
{
    public class HFSM_Factory<StateEnum, TController> : MonoBehaviour where StateEnum: System.Enum where TController : MonoBehaviour
    {
        public Dictionary<StateEnum, HFSM_BaseState<StateEnum, TController>> states = new Dictionary<StateEnum, HFSM_BaseState<StateEnum, TController>>();

        protected HFSM_BaseState<StateEnum, TController> currentState;
        protected bool canAction;
      
        protected virtual void Awake()
        {
        }

        protected virtual void FixedUpdate()
        {
            if (canAction)
            {
                currentState.DoOnStateFixedUpdates();
            }
        }
        protected virtual void Update()
        {
            if (canAction)
            {
                currentState.DoOnStateUpdates();
            }
        }

        public void ChangeState(HFSM_BaseState<StateEnum, TController> _source, StateEnum _toStates)
        {
            if (!states.ContainsKey(_toStates)) return;
            if (currentState != null) currentState.DoOnExitState();

            //Change root
            if (_source.isRoot)
            {
                if (_source.subState != null) _source.subState.DoOnExitState();
                if (currentState != null) currentState.DoOnExitState();
                currentState = states[_toStates];
                currentState.DoOnEnterState();
                currentState.InitializeSubState();
                if (currentState.subState != null) currentState.subState.DoOnEnterState();
            }
            else if (_source.superState != null)
            {
                //Change branch
                _source.DoOnExitState();
                states[_toStates].InitializeSubState();
                states[_toStates].DoOnEnterState();
                _source.superState.SetSubState(states[_toStates]);
                //reset its sub state if the state has sub or override the sub
            }
        }


    }
}