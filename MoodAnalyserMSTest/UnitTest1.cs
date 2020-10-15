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
        /// <summary>
        /// creating the object of mood analyse class, every time a test method is run.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            moodAnalyserClass = new MoodAnalyserClass("");
        }
        /// <summary>
        /// Testing analyse mood by passing expected value and actual value as sad.
        /// </summary>
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
        /// <summary>
        /// Testing analyse mood and giving happy when any mood is passed other than happy.
        /// </summary>
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
        /// <summary>
        /// when null value is passed to the analyse mood, it returns exception.
        /// </summary>
        [TestMethod]
        // [ExpectedException(typeof(NullReferenceException))]
        public void GivenNullShouldReturnHappy()
        {
            //Arrange
            try
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                string expected = "Happy " + ex.Message;
                string actual = moodAnalyserClass.AnalyseMood();
                Assert.AreEqual(expected, actual);

            }
        }
        /// <summary>
        /// passing null in mood analyse method to get custom exception
        /// </summary>
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
        /// <summary>
        /// passing empty string in mood analyser to get custom exception
        /// </summary>
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
        /// <summary>
        /// Validating Mood analyser object with default constructor to return a mood analyser class object
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            //string message = null;
            object expected = new MoodAnalyserClass();
            object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");
            expected.Equals(actual);
            //Assert.AreEqual(expected, actual) -> this can not be used, as we are not testing strings.or other data type, here it is object.
        }
        /// <summary>
        /// Validating mood analyser object with default constructor to return exception when passed incorrect class name
        /// </summary>
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
        /// <summary>
        /// Validating mood analyser object with default constructor to return exception when passed incorrect constructor name
        /// </summary>
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
        /// <summary>
        /// Validating Mood analyser object with parametrized constructor to return a mood analyser class object
        /// </summary>
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
        /// <summary>
        /// Validating mood analyser object with parametrized constructor to return exception when passed incorrect class name
        /// </summary>
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
        /// <summary>
        /// Validating mood analyser object with default constructor to return exception when passed incorrect constructor name
        /// </summary>
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
        /// <summary>
        /// Validating Invoke method from mood analyser factory by passing different values in datarow.
        /// </summary>
        [DataRow("Happy","AnalyseMood","HAPPY")]
        [DataRow("Happy", "AnalysMood", "method not found")]
        [TestMethod]

        public void GivenMessageAndWrongMethodReturnExceptionWhenCallingInvokeMethodUsingReflection(string message,string method, string expected)
        {
            try
            {
                string actual = MoodAnalyserFactory.InvokeAnalyserMethod(message, method);
                Assert.AreEqual(expected, actual);
            }
            catch(MoodAnalyserCustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// Setting up field value in mood analyser factory and returning class to call analyse mood to validate mood 
        /// </summary>
        [TestMethod]
        public void SettingFieldValueandReturnUsingMoodAnalyserClass()
        {
            string expected = "HAPPY";
            MoodAnalyserClass moodAnayserClass= (MoodAnalyserClass)MoodAnalyserFactory.GetFieldForMoodAnalysis("happy", "message"); 
            string actual = moodAnalyserClass.AnalyseMood(); 
            //string actual = MoodAnalyserFactory.InvokeAnalyserMethod(mood, "AnalyseMood");
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// setting up incorrect field value in mood analyser factory and validating for exception
        /// </summary>
        [TestMethod]
        public void SettingIncorrectFieldValueAndReturingCustomException()
        {
            try
            {
                string expected = "happy";
                MoodAnalyserClass moodAnalyser = (MoodAnalyserClass)MoodAnalyserFactory.GetFieldForMoodAnalysis("happy", "mesage");
                //MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
                string actual = moodAnalyser.AnalyseMood();   
                //string actual = MoodAnalyserFactory.InvokeAnalyserMethod(mood, "AnalyseMood");
                Assert.AreEqual(actual, expected);
            }
            catch(MoodAnalyserCustomException ex)
            {
                string expected = "field not found";
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// passing null value in field value in mood analyser factory and validate for exception
        /// </summary>
        [TestMethod]
        public void SettingIncorrectMessageValueAndReturingCustomException()
        {
            try
            {
                string expected = "happy";
                MoodAnalyserClass moodAnalyserClass1= (MoodAnalyserClass)MoodAnalyserFactory.GetFieldForMoodAnalysis(null, "message");
                string actual = moodAnalyserClass.AnalyseMood();    
                //string actual = MoodAnalyserFactory.InvokeAnalyserMethod(mood, "AnalyseMood");
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
