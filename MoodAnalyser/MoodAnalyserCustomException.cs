using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserCustomException:Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE,EMPTY_MESSAGE,NO_SUCH_CLASS,NO_SUCH_METHOD, NO_SUCH_FIELD
        }
        private readonly ExceptionType type;
        
        public MoodAnalyserCustomException(ExceptionType type, string message):base(message)
        {
            this.type = type;
        }
    }
}
