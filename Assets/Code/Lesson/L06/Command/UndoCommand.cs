using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Command
{
    public sealed class UndoCommand : ICommand
    {
        #region Fields

        private readonly List<ICommand> _commands;

        #endregion


        #region Properties

        public bool Succeeded { get; private set; }

        #endregion


        #region ClassLifeCycles

        public UndoCommand(List<ICommand> commands)
        {
            _commands = commands;
        }

        #endregion


        #region ICommand

        public bool Execute(Transform box)
        {
            if (_commands.Count > 0)
            {
                ICommand latestCommand = _commands[_commands.Count - 1];

                if (latestCommand.Succeeded)
                {
                    latestCommand.Undo(box);
                    _commands.RemoveAt(_commands.Count - 1);
                    Succeeded = true;
                }
            }
            Succeeded = false;
            return Succeeded;
        }

        public void Undo(Transform box)
        {
        }

        #endregion
    }
}