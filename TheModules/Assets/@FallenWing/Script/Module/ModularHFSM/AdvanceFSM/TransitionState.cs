using System;
namespace FallenWing.Module.AdvanceFSM
{
    public struct TransitionState : IPredicate
    {
        public AdvanceFSM_State<AdvanceFSM_Factory> from;
        public AdvanceFSM_State<AdvanceFSM_Factory> to;

        public TransitionState(AdvanceFSM_State<AdvanceFSM_Factory> from, AdvanceFSM_State<AdvanceFSM_Factory> to, Func<bool> predicate)
        {
            this.from = from;
            this.to = to;
            this.predicate = predicate;
        }

        public Func<bool> predicate { get; set; }

    }
}