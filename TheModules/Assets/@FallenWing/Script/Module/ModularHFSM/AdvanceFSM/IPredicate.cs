using System;
namespace FallenWing.Module.AdvanceFSM
{
    public interface IPredicate
    {
        Func<bool> predicate { get; set; }

    }
}