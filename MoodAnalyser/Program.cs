using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to Mood Analyser Problem");

                //Directly passing mood analyser class with null as a parameter.
                //MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(null);

                //Get field for mood analysis method is called from mood analyser factory to pass a field message dynamically. 
                string field= MoodAnalyserFactory.GetFieldForMoodAnalysis("HAPPY", "message"); 
                //field from mood analyser factory is called and passed to parametrized object in mood analyser factory.
                object moodAnalyserClass=MoodAnalyserFactory.CreateMoodAnalyseObjectUsingParamaterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass", field); 
                // object is converted into instance of mood analyser class.
                MoodAnalyserClass mood = (MoodAnalyserClass)moodAnalyserClass;
                //Analyse method method is called using class.
                string moodOutput = mood.AnalyseMood();
                Console.WriteLine(moodOutput);

                // creating a object with default constructor in mood analyser factory using reflection
                //object moodAnalyserClass = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");

                //Directly calling method class from Mood analyser factory using reflection.
                //string mood= MoodAnalyserFactory.InvokeAnalyserMethod("happy", "AnalyseMood");
                //Console.WriteLine(mood);
            }
            catch (MoodAnalyserCustomException ex)
            {
                Console.WriteLine(ex.GetType().Name + ex.Message);
                //Console.WriteLine(ex);

            }

        }
    }
}
