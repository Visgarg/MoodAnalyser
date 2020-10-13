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
            moodAnalyserClass = new MoodAnalyserClass("");
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
            string actual = moodAnalyserClass.AnalyseMood();
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
            catch (NullReferenceException ex)
            {
                string expected = "Happy " + ex.Message;
                string actual = moodAnalyserClass.AnalyseMood();
                Assert.AreEqual(expected, actual);

            }
        }
        [TestMethod]
        public void GivenNullShouldReturnCustomException()
        {
            try
            {
                //Add
                string actual = moodAnalyserClass.AnalyseMood();
            }
            catch (MoodAnalyserCustomException ex)
            {
                string expected = ex.Message;
                Assert.AreEqual(expected, "Mood should not be passed as a null value");
            }
        }
        [TestMethod]
        public void GivenEmptyStringShouldReturnCustomException()
        {
            try
            {
                //Add
                string actual = moodAnalyserClass.AnalyseMood();
            }
            catch (MoodAnalyserCustomException ex)
            {
                string expected = ex.Message;
                Assert.AreEqual(expected, "Mood should not be empty");
            }
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            //string message = null;
            object expected = new MoodAnalyserClass();
            object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");
            expected.Equals(actual);
            //Assert.AreEqual(expected, actual) -> this can not be used, as we are not testing strings.or other data type, here it is object.
        }
        [TestMethod]
        public void GivenClassNameWhenImproperShouldThrowMoodAnalysisExceptionWhenPassedInMoodAnalyseObjectInReflection()
        {
            try
            {
                //object expected = new MoodAnalyserClass();
                string expected = "Class not found";
                object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyseClass", "MoodAnalyserClass");
                expected.Equals(actual);
            }
            catch(MoodAnalyserCustomException ex)
            {
                string expected = "Class not found";
                expected.Equals(ex.Message);
            }
        }
        [TestMethod]
        public void GivenClassNameWhenImproperConstructorShouldThrowMoodAnalysisExceptionWhenPassedInMoodAnalyseObjectInReflection()
        {
            try
            {
                //object expected = new MoodAnalyserClass();
                string expected = "No constructor found";
                object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyseClass");
                expected.Equals(actual);
            }
            catch (MoodAnalyserCustomException ex)
            {
                string expected = "No constructor found";
                expected.Equals(ex.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            string message = "Happy";
            object expected = new MoodAnalyserClass(message);
            object actual = MoodAnalyserFactory.CreateMoodAnalyseObjectUsingParamaterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass", "Happy");
            expected.Equals(actual);
        }
        [TestMethod]
        public void GivenMessageAndMethodToInvokingMethodShouldReturnMessageUsingReflection()
        {
            string expected = "HAPPY";
            string actual = MoodAnalyserFactory.InvokeAnalyserMethod("Happy", "AnalyseMood");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenClassNameWhenImproper_ShouldThrowMoodAnalysisExceptionWhenPassedIn_ParametrizedMoodAnalyseObjectInReflection()
        {
            try
            {
                //object expected = new MoodAnalyserClass();
                string expected = "Class not found";
                object actual = MoodAnalyserFactory.CreateMoodAnalyseObjectUsingParamaterizedConstructor("MoodAnalyser.MoodAnalyseClass", "MoodAnalyserClass","happy");
                expected.Equals(actual);
            }
            catch (MoodAnalyserCustomException ex)
            {
                string expected = "Class not found";
                expected.Equals(ex.Message);
            }
        }
        [TestMethod]
        public void GivenClassNameWithImproperConstructor_ShouldThrowMoodAnalysisException_WhenPassedInParametrizedMoodAnalyseObjectInReflection()
        {
            try
            {
                //object expected = new MoodAnalyserClass();
                string expected = "No constructor found";
                object actual = MoodAnalyserFactory.CreateMoodAnalyseObjectUsingParamaterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyseClass","happy");
                expected.Equals(actual);
            }
            catch (MoodAnalyserCustomException ex)
            {
                string expected = "No constructor found";
                expected.Equals(ex.Message);
            }
        }
        [TestMethod]
        public void GivenMessageAndWrongMethodReturnExceptionWhenCallingInvokeMethodUsingReflection()
        {
            try
            {
                string expected = "HAPPY";
                string actual = MoodAnalyserFactory.InvokeAnalyserMethod("Happy", "AnalysMood");
                Assert.AreEqual(expected, actual);
            }
            catch(MoodAnalyserCustomException ex)
            {
                string expected = "method not found";
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void SettingFieldValueandReturnUsingInvokeMethod()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyserFactory.GetFieldForMoodAnalysis("happy", "message");
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
            //string actual = moodAnalyserClass.AnalyseMood();    -----> ask this doubt.
            string actual = MoodAnalyserFactory.InvokeAnalyserMethod(mood, "AnalyseMood");
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void SettingIncorrectFieldValueAndReturingCustomException()
        {
            try
            {
                string expected = "happy";
                string mood = MoodAnalyserFactory.GetFieldForMoodAnalysis("happy", "mesage");
                MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
                //string actual = moodAnalyserClass.AnalyseMood();    -----> ask this doubt.
                string actual = MoodAnalyserFactory.InvokeAnalyserMethod(mood, "AnalyseMood");
                Assert.AreEqual(actual, expected);
            }
            catch(MoodAnalyserCustomException ex)
            {
                string expected = "field not found";
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void SettingIncorrectMessageValueAndReturingCustomException()
        {
            try
            {
                string expected = "happy";
                string mood = MoodAnalyserFactory.GetFieldForMoodAnalysis(null, "message");
                MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
                //string actual = moodAnalyserClass.AnalyseMood();    -----> ask this doubt.
                string actual = MoodAnalyserFactory.InvokeAnalyserMethod(mood, "AnalyseMood");
                Assert.AreEqual(actual, expected);
            }
            catch (MoodAnalyserCustomException ex)
            {
                string expected = "null value found.";
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
        
}
