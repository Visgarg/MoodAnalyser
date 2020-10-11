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
                MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(null);
                string mood = moodAnalyserClass.AnalyseMood();
                Console.WriteLine(mood);
            }
            catch(MoodAnalyserCustomException ex)
            {
                Console.WriteLine(ex.GetType().Name + ex.Message);
                Console.WriteLine(ex);

            }

        }
    }
}
