using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserCustomException:Exception
    {
        /// <summary>
        /// Creating a enum class for declaring constants of Exception type.
        /// </summary>
        public enum ExceptionType
        {
            NULL_MESSAGE,EMPTY_MESSAGE,NO_SUCH_CLASS,NO_SUCH_METHOD, NO_SUCH_FIELD
        }
        private readonly ExceptionType type;
        
        /// <summary>
        /// Constructor for mood analyser Custom Exception and message is passed to base class of exception.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public MoodAnalyserCustomException(ExceptionType type, string message):base(message)
        {
            this.type = type;
        }
    }
}
