using System.Collections;
using System.Linq;
using UnityEngine;
namespace FallenWing.Module.FSM
{
    public abstract class FSM_BaseState<StateEnum,TController> where StateEnum : System.Enum where TController : MonoBehaviour
    {
        protected FSM_BaseState(StateEnum stateKey,TController controller)
        {
            StateKey = stateKey;
            Controller = controller;
        }

        public StateEnum StateKey { get; private set; }
        public TController Controller { get; private set; }

        public abstract void DoOnEnterState();
        public abstract void DoOnStateUpdate();
        public abstract void DoOnStateFixedUpdate();
        public abstract void DoOnExitState();
        public abstract StateEnum NextState();
    }
}