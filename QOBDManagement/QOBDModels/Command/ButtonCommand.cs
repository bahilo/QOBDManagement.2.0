﻿using System;
using System.Windows.Input;
using QOBDCommon.Classes;
using System.Windows;

namespace QOBDModels.Command
{
    public class ButtonCommand<P> : ICommand
    {
        private object _lock = new object();
        private Action<P> _executeAction;
        private Func<P, bool> _canExecuteAction;

        public event EventHandler CanExecuteChanged;

        public ButtonCommand(Action<P> actionToExecute)
        {
            _executeAction = actionToExecute;
        }

        public ButtonCommand(Func<P, bool> canExecute)
        {
            _canExecuteAction = canExecute;
        }

        public ButtonCommand(Action<P> actionToExecute, Func<P, bool> canActionExecute)
        {
            _executeAction = actionToExecute;
            _canExecuteAction = canActionExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteAction != null)
            {
                return _canExecuteAction((P)parameter);
            }
            
            return false;
        }

        public void Execute(object parameter)
        {
            if (_executeAction != null)
                _executeAction((P)parameter);
        }

        public void raiseCanExecuteActionChanged()
        {
            try
            {
                if(Application.Current != null && !Application.Current.Dispatcher.CheckAccess())
                {
                    Application.Current.Dispatcher.Invoke(()=> {
                        if (CanExecuteChanged != null)
                            CanExecuteChanged(this, EventArgs.Empty);
                    });
                }
                else
                {
                    if (CanExecuteChanged != null)
                        CanExecuteChanged(this, EventArgs.Empty);
                }
                
            }
            catch (Exception ex)
            {
                lock (_lock)
                    Log.error(ex.Message, QOBDCommon.Enum.EErrorFrom.COMMAND);
            }
        }

    }
}
