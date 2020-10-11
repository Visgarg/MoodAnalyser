using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System.Runtime.InteropServices;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyserClass moodAnalyserClass;
        [TestInitialize]
        public void Setup()
        {
             moodAnalyserClass = new MoodAnalyserClass("I am in any mood");
        }
        [TestMethod]
        public void GivenSadMoodShouldReturnSAD()
        {
            //Arrange
            string expected = "SAD";
             //string message = "I am in Sad Mood";
            //MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(message);

            //Act
            string actual = moodAnalyserClass.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GivenAnyMoodShouldReturnHAPPY()
        {
            //Arrange
            string expected = "HAPPY";
            //string message = "I am in any mood";
            //Add
            string actual= moodAnalyserClass.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
            
        }
    }
}
