using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserClass
    {
        public string message;
        /// <summary>
        /// Parametrized Constructor to pass a value to variable.
        /// </summary>
        /// <param name="message"> message field</param>
        public MoodAnalyserClass(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MoodAnalyserClass()
        {

        }
        /// <summary>
        /// Analyses the mood.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Mood should not be empty
        /// or
        /// Mood should not be passed as a null value
        /// </exception>
        public string AnalyseMood()
        {
            try
            {
                //Message should not be empty.
                if(message=="")
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
                //message can be any emotion.
                if (this.message.Contains("Sad") || this.message.Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            //catches exception of null type.
            catch(NullReferenceException)
            {
                // return "Happy "+ex.Message;
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be passed as a null value");
            }
        }

    }

}
