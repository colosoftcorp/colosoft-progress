using System;

namespace Colosoft.Progress
{
    public class ProgressMessageChangedEventArgs : EventArgs
    {
        public IMessageFormattable Message { get; private set; }

        public object UserState { get; private set; }

        public ProgressMessageChangedEventArgs(IMessageFormattable message, object userState)
        {
            this.Message = message;
            this.UserState = userState;
        }
    }
}
