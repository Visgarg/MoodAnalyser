using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserClass
    {
        public string message;
        public MoodAnalyserClass(string message)
        {
            this.message = message;
        }
        public MoodAnalyserClass()
        {

        }
        public string AnalyseMood()
        {
            try
            {
                if(message=="")
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
                if (this.message.Contains("Sad") || this.message.Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch(NullReferenceException)
            {
                // return "Happy "+ex.Message;
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be passed as a null value");
            }
        }

    }

}
