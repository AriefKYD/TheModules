using System.Collections.Generic;
using UnityEngine;
namespace FallenWing.Module.AdvanceFSM
{
    public class AdvanceFSM_Factory : MonoBehaviour
    {
        public List<AdvanceFSM_State<AdvanceFSM_Factory>> FSM = new List<AdvanceFSM_State<AdvanceFSM_Factory>>();
        public AdvanceFSM_State<AdvanceFSM_Factory> currentState;
        public void AddTransition(TransitionState transition)
        {
            AdvanceFSM_State<AdvanceFSM_Factory> stateFrom = GetOrAdd(transition.from);
            AdvanceFSM_State<AdvanceFSM_Factory> stateTo = GetOrAdd(transition.to);
            transition.to = stateTo;
            stateFrom.AddTransition(transition);
        }

        private AdvanceFSM_State<AdvanceFSM_Factory> GetOrAdd(AdvanceFSM_State<AdvanceFSM_Factory> state)
        {
            if(!FSM.Contains(state))
            {
                FSM.Add(state);
                return state;
            }

            return FSM.Find(x=>x==state);
        }

        public virtual void Update()
        {
            if (currentState == null) return;
            currentState.CheckTransition();
            currentState.DoOnStateUpdate();
        }
       
    }
}