using System.Collections;
using UnityEngine;
namespace FallenWing.Module.CommandPattern
{
    public abstract class BaseCommand
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}