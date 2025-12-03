using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenWing.Module.CommandPattern;

namespace FallenWing.Module.EventManager
{
    /// <summary>
    /// Basic Sub-Pup pattern
    /// </summary>
    public class EventManager : MonoBehaviour
    {
        public delegate void OnAddCommand(BaseCommand _command);
        public static event OnAddCommand onAddCommand;
        public static void OnAddingCommand(BaseCommand _command)
        {
            onAddCommand?.Invoke(_command);
        }
        
        public delegate void OnRemoveCommand(BaseCommand _command);
        public static event OnRemoveCommand onRemoveCommand;
        public static void OnRemovingCommand(BaseCommand _command)
        {
            onRemoveCommand?.Invoke(_command);
        } 
        
        public delegate void OnUndoCommand();
        public static event OnUndoCommand onUndoCommand;
        public static void OnUndoingCommand()
        {
            onUndoCommand?.Invoke();
        } 
        
        
        
        public delegate void OnPlayerAttacked();
        public static event OnPlayerAttacked onPlayerAttacked;
        public static void OnPlayerAttack()
        {
            onPlayerAttacked?.Invoke();
        }
    }
}