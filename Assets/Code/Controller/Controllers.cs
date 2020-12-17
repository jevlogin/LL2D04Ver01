using System.Collections.Generic;

namespace JevLogin
{
    internal sealed class Controllers : IInitialization, IExecute, ILateExecute, ICleanup
    {
        #region Fields

        private readonly List<IInitialization> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateControllers;
        private readonly List<ICleanup> _cleanupControllers;

        #endregion


        #region Properties

        internal Controllers()
        {
            _initializeControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _lateControllers = new List<ILateExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        #endregion


        #region Methods

        internal Controllers Add(IExecute controller)
        {
            if (controller is IInitialization initializationController)
            {
                _initializeControllers.Add(initializationController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is ILateExecute lateUpdateController)
            {
                _lateControllers.Add(lateUpdateController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            for (int index = 0; index < _initializeControllers.Count; index++)
            {
                _initializeControllers[index].Initialization();
            }
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            for (int index = 0; index < _executeControllers.Count; index++)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }

        #endregion


        #region iLateExecute

        public void LateExecute(float deltaTime)
        {
            for (int index = 0; index < _lateControllers.Count; index++)
            {
                _lateControllers[index].LateExecute(deltaTime);
            }
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            for (int index = 0; index < _cleanupControllers.Count; index++)
            {
                _cleanupControllers[index].Cleanup();
            }
        }

        #endregion
    }
}