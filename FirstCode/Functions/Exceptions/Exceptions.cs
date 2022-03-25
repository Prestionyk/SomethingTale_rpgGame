using System;

namespace FinalGame.Functions.Exceptions
{
    [Serializable]
    class NoChoiceException : Exception
    {
        public NoChoiceException() { }
    }

    [Serializable]
    class PlayerDeadException : Exception
    {
        public PlayerDeadException() { }
    }
}
