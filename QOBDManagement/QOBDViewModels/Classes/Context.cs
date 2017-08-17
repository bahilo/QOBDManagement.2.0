using QOBDViewModels.Interfaces;
using System;

namespace QOBDViewModels.Classes
{
    public class Context
    {
        private IState _previousState;
        private IMainWindowViewModel _main;
        private Func<object, object> _page;

        private IState _nexState;

        public Context(IMainWindowViewModel main)
        {
            _main = main;
            _page = main.navigation;
        }

        public IState NextState
        {
            get { return _nexState; }
            set { _nexState = value; }
        }

        public IState PreviousState
        {
            get { return _previousState; }
            set { _previousState = value; }
        }

        public Func<object, object> Page
        {
            get { return _page; }
            set { _page = value; }
        }

        public void Request()
        {
            if(_previousState != null)
                _previousState.Handle(this, Page);
        }


    }
}
