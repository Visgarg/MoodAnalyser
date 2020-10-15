using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq.Expressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// Creates the mood analyse method which creates object of Mood Analyser Class with default constructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// No constructor found
        /// or
        /// No class found
        /// </exception>
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            //pass the details of mood analyser class in type using reflection.
            Type type = typeof(MoodAnalyserClass);
            //checks for the correct class name using details from type.
            //reflection can be used to get complete details of the class from the assembly and saved in attribute type.
            if (type.FullName.Equals(className) || type.Name.Equals(className))
            {
                //regex pattern
                string pattern = @"." + constructorName + "$";
                //matches pattern of constructor with class name
                Match result = Regex.Match(className, pattern);
                //if constructor is not matched with class name, then constructor name does not exist.
                if (result.Success)
                {
                    //creates an assembly
                    //Assembly.GetExecutingAssembly() gets assembly (dll file) of class here.
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    //returns default object of the class.
                    return Activator.CreateInstance(moodAnalyseType);
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "No constructor found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "No class found");
            }
        }
        //using optional parameters to create a method that can be used for both parametrized and default constructor.        
        /// <summary>
        /// Creates the mood analyse object with optional parameter. if optional parameter is default value, then default constructor is made
        /// if optional paramber is passed through method, parametrized constructor is called.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Constructor not found
        /// or
        /// class not found
        /// </exception>
        public static object CreateMoodAnalyseObjectUsingParamaterizedConstructor(string className, string constructorName, string message="default")
        {
            Type type = typeof(MoodAnalyserClass);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    //old method
                    /*ConstructorInfo construct = type.GetConstructor(new[] { typeof(string) });
                    object objects = construct.Invoke(new object[] { message });
                    return objects;*/
                    //new method
                    Assembly Executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = Executing.GetType(className);
                    if(message=="default")
                    {
                        return Activator.CreateInstance(moodAnalyseType);
                    }
                    else 
                        //passing parameter along with the message
                        return Activator.CreateInstance(moodAnalyseType, message);
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
                }

            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "class not found");
            }
        }
        /// <summary>
        /// Invokes the analyser method.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">method not found</exception>
        public static string InvokeAnalyserMethod(string message, string methodName)
        {
            try
            {
                //gets the  type object from type attribute which is passed with class details of the mood analyse class.
                Type type = Type.GetType("MoodAnalyser.MoodAnalyserClass");
                //methodinfo are obtained by passing method name in type attribute using reflection.
                MethodInfo methodInfo = type.GetMethod(methodName);
                //creation of object for mood analyser class using mood analyser factory class.
                object moodAnalyserObject = CreateMoodAnalyseObjectUsingParamaterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass", message);
                //Invoke takes 2 input, 1st input is object of class, 2nd is parameter.
                //object of method is created using invoke method.
                //object contains value returned by calliing analyse mood method from mood analyse class.
                object AnalyseMood = methodInfo.Invoke(moodAnalyserObject, null);
                //returns value from mood analyse class and analyse mood method.
                return AnalyseMood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "method not found");
            }

        }
        /// <summary>
        /// Gets the field for mood analysis.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// null value found.
        /// or
        /// field not found
        /// </exception>
        public static object GetFieldForMoodAnalysis(string message, string fieldName)
        {
            try
            {
                //creation of object of mood analyser class.
                MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass();
                //gets the type of mood analyser class.
                Type type = typeof(MoodAnalyserClass);
                //field name is passed in type and if that field exists, it is saved in fieldinfo.
                FieldInfo fieldInfo = type.GetField(fieldName);
                if(message==null)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "null value found.");
                }
                //field info is set with value by passing object and value
                fieldInfo.SetValue(moodAnalyserClass, message);
                //class is returned with field value initialized
                return moodAnalyserClass ;
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "field not found");
            }
        }
    }
}
 