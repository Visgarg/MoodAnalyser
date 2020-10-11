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
            NULL_MESSAGE,EMPTY_MESSAGE
        }
        private readonly ExceptionType type;
        
        public MoodAnalyserCustomException(ExceptionType type, string message):base(message)
        {
            this.type = type;
        }
    }
}
