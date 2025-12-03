using UnityEngine;
using System.Collections.Generic;

namespace FallenWing.Module.HFSM
{

    public abstract class HFSM_BaseState <StateEnum,TController> where StateEnum : System.Enum where TController : MonoBehaviour
    {
        internal bool isRoot = false;
        //public PlayerController pc;
        //public PlayerStateFactory pFactory;
        public HFSM_BaseState<StateEnum,TController> subState, superState;
        protected StateEnum stateKey;
        protected TController controller;

        protected HFSM_BaseState(StateEnum stateKey, TController controller)
        {
            this.stateKey = stateKey;
            this.controller = controller;
        }

        public abstract void InitializeSubState();
        public abstract void DoOnEnterState();
        public abstract void DoOnStateUpdate();
        public void DoOnStateUpdates()
        {
            if (subState != null)
            {
                subState.DoOnStateUpdates();
            }
            DoOnStateUpdate();
        }
        public abstract void DoOnStateFixedUpdate();
        public void DoOnStateFixedUpdates()
        {
            if (subState != null)
            {
                subState.DoOnStateFixedUpdates();
            }
            DoOnStateFixedUpdate();
        }
        public abstract void DoOnExitState();
        public void SetSuperState(HFSM_BaseState<StateEnum,TController> _superState)
        {
            superState = _superState;
        }
        public void SetSubState(HFSM_BaseState<StateEnum, TController> _subState)
        {
            subState = _subState;
            subState.InitializeSubState();
            _subState.SetSuperState(this);
        }

        public virtual void OverriderBool(bool _flag1)
        {

        }

    }

}