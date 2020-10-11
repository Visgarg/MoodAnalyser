using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyser Problem");
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(null);
            string mood= moodAnalyserClass.AnalyseMood();
            Console.WriteLine(mood);

        }
    }
}
