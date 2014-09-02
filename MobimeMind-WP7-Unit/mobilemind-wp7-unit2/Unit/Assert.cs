using System.Collections;
using System;

namespace MobileMindWP7Unit.Unit
{
    /// <summary>
    /// Asserts for Comparations
    /// 
    /// Ricardo Bocchi
    /// </summary>
    public class Assert
    {

        private const String DefaultFailMessage = "test fail";

 
        /// <summary>
        /// throw fail exception
        /// 
        /// </summary>
        public static void Fail()
        {
            Fail(DefaultFailMessage);
        }

        /// <summary>
        /// throw fails exception
        /// 
        /// </summary>
        /// <param name="message">Error message</param>
        public static void Fail(String message)
        {
            throw new TestException(message);
        }

        /// <summary>
        /// Compares two objects using the Equals method. Equals must be true.
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public static void AreEqual(Object obj1, Object obj2)
        {
            AreEqual(obj1, obj2, DefaultFailMessage);
        }

        /// <summary>
        /// Compares two objects using the Equals method. Equals must be true.
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <param name="message"></param>
        public static void AreEqual(Object obj1, Object obj2, String message)
        {
            if ((obj1 == null) || (obj2 == null) || !obj1.Equals(obj2))
            {
                const string text = "expected '{0}' but '{1}' found: ";
                String text1 = (obj1 ?? "null").ToString();
                String text2 = (obj2 ?? "null").ToString();
                Fail(String.Format(text, text1, text2) + message);
            }
        }

        /// <summary>
        /// Compares two objects using the Equals method. Equals must be false.
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public static void AreNoEqual(Object obj1, Object obj2)
        {
            AreNoEqual(obj1, obj2, DefaultFailMessage);
        }

        /// <summary>
        /// Compares two objects using the Equals method. Equals must be false.
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <param name="message"></param>
        public static void AreNoEqual(Object obj1, Object obj2, String message)
        {
            if ((obj1 == null) || (obj2 == null) || obj1.Equals(obj2))
            {
                String text = "expected '{0}' but '{1}' found: ";
                String text1 = (obj1 ?? "null").ToString();
                String text2 = (obj2 ?? "null").ToString();
                Fail(String.Format(text, text1, text2) + message);
            }
        }

        /// <summary>
        /// Must be false
        /// 
        /// </summary>
        /// <param name="state"></param>
        public static void IsFalse(Object state)
        {
            IsFalse(state, DefaultFailMessage);
        }

        /// <summary>
        /// Must be false
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="message"></param>
        public static void IsFalse(Object state, String message)
        {

            bool b = (state != null && state is bool) ? (bool)state : false;

            if (b)
            {
                Fail("false expected, but true found: " + message);
            }
        }

        /// <summary>
        /// Must be true
        /// 
        /// </summary>
        /// <param name="state"></param>
        public static void IsTrue(bool state)
        {
            IsTrue(state, DefaultFailMessage);
        }

        /// <summary>
        /// Must be true
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="message"></param>
        public static void IsTrue(Object state, String message)
        {

            bool b = (state != null && state is bool) ? (bool)state : false;

            if (!b)
            {
                Fail("true expected, but false found: " + message);
            }
        }

        /// <summary>
        /// Must be null
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public static void IsNull(Object obj)
        {
            IsNull(obj, DefaultFailMessage);
        }

        /// <summary>
        /// Must be null
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        public static void IsNull(Object obj, String message)
        {
            if (obj != null)
            {
                String text = "null expected, but '{0}' found:";
                Fail(String.Format(text, obj.ToString()) + message);
            }
        }

        /// <summary>
        /// Can't be null
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public static void IsNotNull(Object obj)
        {
            IsNotNull(obj, DefaultFailMessage);
        }

        /// <summary>
        /// Can't be null
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        public static void IsNotNull(Object obj, String message)
        {
            if (obj == null)
            {
                Fail("not null expected, but null value found: " + message);
            }
        }

        /// <summary>
        /// Must be Greater
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public static void IsGreater(Object obj1, Object obj2)
        {
            IsGreater(obj1, obj2, DefaultFailMessage);
        }

        /// <summary>
        /// Must be Greater
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <param name="message"></param>
        public static void IsGreater(Object obj1, Object obj2, String message)
        {
            if (Compare(obj1, obj2) != 1)
            {
                String text = "expected greater than '{0}', but '{1}' found: ";
                String text1 = obj1 == null ? "null" : obj1.ToString();
                String text2 = obj2 == null ? "null" : obj2.ToString();
                Fail(String.Format(text, text1, text2) + message);
            }
        }

        /// <summary>
        /// Must be Greater Or Equals
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public static void IsGreaterOrEqual(Object obj1, Object obj2)
        {
            IsGreaterOrEqual(obj1, obj2, DefaultFailMessage);
        }

        
        /// <summary>
        /// Must be Greater Or Equals
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <param name="message"></param>
        public static void IsGreaterOrEqual(Object obj1, Object obj2, String message)
        {
            int value = Compare(obj1, obj2);
            if (value != 0 && value != 1)
            {
                String text = "expected greater or Equals than '{0}', but '{1}' found: ";
                String text1 = obj1 == null ? "null" : obj1.ToString();
                String text2 = obj2 == null ? "null" : obj2.ToString();
                Fail(String.Format(text, text1, text2) + message);
            }
        }

        /// <summary>
        /// Must be Less
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public static void IsLess(Object obj1, Object obj2)
        {
            IsLess(obj1, obj2, DefaultFailMessage);
        }

        /// <summary>
        /// Must be Less
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <param name="message"></param>
        public static void IsLess(Object obj1, Object obj2, String message)
        {
            if (Compare(obj1, obj2) != -1)
            {
                String text = "expected less than '{0}', but '{1}' found: ";
                String text1 = obj1 == null ? "null" : obj1.ToString();
                String text2 = obj2 == null ? "null" : obj2.ToString();
                Fail(String.Format(text, text1, text2) + message);
            }
        }

        /// <summary>
        /// Must be Less Or Equal
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public static void IsLessOrEqual(Object obj1, Object obj2)
        {
            IsLessOrEqual(obj1, obj2, DefaultFailMessage);
        }

        /// <summary>
        /// 
        /// Must be Less Or Equal
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <param name="message"></param>
        public static void IsLessOrEqual(Object obj1, Object obj2, String message)
        {
            int value = Compare(obj1, obj2);
            if (value != -1 && value != 0)
            {
                String text = "expected less or Equals than '{0}', but '{1}' found: ";
                String text1 = obj1 == null ? "null" : obj1.ToString();
                String text2 = obj2 == null ? "null" : obj2.ToString();
                Fail(String.Format(text, text1, text2) + message);
            }
        }


        private static int Compare(Object obj1, Object obj2)
        {
            if (obj1 is IComparer && obj2 is IComparer)
            {
                return ((IComparer)obj1).Compare(obj1, obj2);
            }

            if (obj1 is IComparable && obj2 is IComparable)
            {
                return ((IComparable)obj1).CompareTo(obj2);
            }

            throw new TestException("values can not be compared");
        }
    }
}
