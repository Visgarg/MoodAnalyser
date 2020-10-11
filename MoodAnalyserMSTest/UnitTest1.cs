using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System;
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
             moodAnalyserClass = new MoodAnalyserClass(null);
        }
        [TestMethod]
        public void GivenSadMoodShouldReturnSAD()
        {
            //Arrange
            string expected = "SAD";
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
        [TestMethod]    
       // [ExpectedException(typeof(NullReferenceException))]
        public void GivenNullShouldReturnHappy()
        {
            //Arrange
            try
            {
                throw new NullReferenceException();
            }
            catch(NullReferenceException ex)
            {
                string expected = "Happy " + ex.Message;
                string actual= moodAnalyserClass.AnalyseMood();
                Assert.AreEqual(expected, actual);

            }
        }


    }
}
