using System.Collections.Generic;
using FallenWing.Core;

namespace FallenWing.Module.CommandPattern
{
    using FallenWing.Module.EventManager;
    public class CommandListner : BaseSingleton<CommandListner>
    {
        private List<BaseCommand> commandStacks = new List<BaseCommand>();

        private void OnEnable()
        {
            EventManager.onAddCommand += AddCommand;
            EventManager.onRemoveCommand += RemoveCommand;
            EventManager.onUndoCommand += Undo;
        }


        private void OnDisable()
        {
            EventManager.onAddCommand -= AddCommand;
            EventManager.onRemoveCommand -= RemoveCommand;
            EventManager.onUndoCommand -= Undo;
        }

        private void AddCommand(BaseCommand _command)
        {
            if (commandStacks.Contains(_command)) return;
            _command.Execute();
            commandStacks.Add(_command);
        }

        private void RemoveCommand(BaseCommand _command)
        {

            if (!commandStacks.Contains(_command)) return;
            _command.Undo();
            commandStacks.Remove(_command);
        }

        private void Undo()
        {
            commandStacks[commandStacks.Count - 1].Undo();
            commandStacks.RemoveAt(commandStacks.Count - 1);
        }
    }
}