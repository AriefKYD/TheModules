using System.Collections.Generic;
namespace FallenWing.Module.AdvanceFSM
{
    public abstract class AdvanceFSM_State<TContex> where TContex : AdvanceFSM_Factory
    {
        public TContex contex;
        public List<TransitionState> transitions = new List<TransitionState>();

        protected AdvanceFSM_State(TContex contex)
        {
            this.contex = contex;
            transitions = new List<TransitionState>();
        }

        public abstract void DoOnEnterState();
        public abstract void DoOnStateUpdate();
        public abstract void DoOnStateFixedUpdate();
        public abstract void DoOnExitState();

        public void AddTransition(TransitionState transition)
        {
            transitions.Add(transition);
        }

        public void RemoveTransition(TransitionState transition)
        {
            transitions.Remove(transition);
        }

        public void CheckTransition()
        {
            foreach (var transition in transitions) 
            {
                if(transition.predicate.Invoke())
                {
                    contex.currentState=transition.to;
                    contex.currentState.DoOnEnterState();
                }
            }
        }

    }
}