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
                //MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(null);
                //string field= MoodAnalyserFactory.GetFieldForMoodAnalysis("HAPPY", "message"); ---> why this method calling is not storing a value in field of moodAnayserClass.
                object moodAnalyserClass=MoodAnalyserFactory.CreateMoodAnalyseObjectUsingParamaterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass","sad"); //field string can be passed in place of sad here, and code is working fine.
                MoodAnalyserClass mood = (MoodAnalyserClass)moodAnalyserClass;
                string moodOutput = mood.AnalyseMood();
                Console.WriteLine(moodOutput);

                //object moodAnalyserClass = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");
                
                //string mood= MoodAnalyserFactory.InvokeAnalyserMethod("happy", "AnalyseMood");
                //Console.WriteLine(mood);
            }
            catch(MoodAnalyserCustomException ex)
            {
                Console.WriteLine(ex.GetType().Name + ex.Message);
                //Console.WriteLine(ex);

            }

        }
    }
}
