using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WCF_IOC.Domain.Validation
{

    public class AssertionConcern
    {
        #region Nullable
        public static void EnsureIsNotNull(object obj, string errorMessage)
        {
            if (obj == null)
                throw new Exception(errorMessage);
        }
        #endregion

        #region Date
        public static void EnsureDateIsGreaterThan(DateTime startDate, DateTime endDate, string errorMessage)
        {
            if (startDate < endDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureDateIsLessThan(DateTime startDate, DateTime endDate, string errorMessage)
        {
            if (startDate > endDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureDateIsGreaterOrEqualThan(DateTime startDate, DateTime endDate, string errorMessage)
        {
            if (startDate < endDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureDateIsLessOrEqualThan(DateTime startDate, DateTime endDate, string errorMessage)
        {
            if (startDate > endDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureDayOfWeekIsNotWeekend(DateTime date, string errorMessage)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday)
                throw new Exception(errorMessage);
        }

        public static void EnrureListDontHaveDate(IList<DateTime> dateList, DateTime date, string errorMessage)
        {
            if (dateList != null)
            {
                foreach (var item in dateList)
                {
                    if (item.Date == date.Date)
                        throw new Exception(errorMessage);
                }
            }
        }

        public static void EnrureListDontHaveDateAndTime(IList<DateTime> dateList, DateTime date, string errorMessage)
        {
            if (dateList != null)
            {
                foreach (var item in dateList)
                {
                    if (item == date)
                        throw new Exception(errorMessage);
                }
            }
        }
        #endregion

        #region Hour
        public static void EnsureHourIsGreaterThan(int startHour, int endHour, string errorMessage)
        {
            if (startHour < endHour)
                throw new Exception(errorMessage);
        }

        public static void EnsureHourIsLessThan(int startHour, int endHour, string errorMessage)
        {
            if (startHour > endHour)
                throw new Exception(errorMessage);
        }

        public static void EnsureHourIsGreaterOrEqualThan(int startHour, int endHour, string errorMessage)
        {
            if (startHour < endHour)
                throw new Exception(errorMessage);
        }

        public static void EnsureHourIsLessOrEqualThan(int startHour, int endHour, string errorMessage)
        {
            if (startHour > endHour)
                throw new Exception(errorMessage);
        }

        public static void EnsureTotalHourIsLessThan(int startHour, int endHour, int totalHoursAllowed, string errorMessage)
        {
            if ((endHour - startHour) > totalHoursAllowed)
                throw new Exception(errorMessage);
        }
        #endregion

        #region Time
        public static void EnsureTimeIsGreaterThan(DateTime startTime, DateTime endTime, string errorMessage)
        {
            // Prepare dates
            DateTime compareStartDate = new DateTime(1900, 1, 1, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime compareEndDate = new DateTime(1900, 1, 1, endTime.Hour, endTime.Minute, endTime.Second);

            if (compareStartDate <= compareEndDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureTimeIsLessThan(DateTime startTime, DateTime endTime, string errorMessage)
        {
            // Prepare dates
            DateTime compareStartDate = new DateTime(1900, 1, 1, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime compareEndDate = new DateTime(1900, 1, 1, endTime.Hour, endTime.Minute, endTime.Second);

            if (compareStartDate >= compareEndDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureTimeIsGreaterOrEqualThan(DateTime startTime, DateTime endTime, string errorMessage)
        {
            // Prepare dates
            DateTime compareStartDate = new DateTime(1900, 1, 1, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime compareEndDate = new DateTime(1900, 1, 1, endTime.Hour, endTime.Minute, endTime.Second);

            if (compareStartDate < compareEndDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureTimeIsLessOrEqualThan(DateTime startTime, DateTime endTime, string errorMessage)
        {
            // Prepare dates
            DateTime compareStartDate = new DateTime(1900, 1, 1, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime compareEndDate = new DateTime(1900, 1, 1, endTime.Hour, endTime.Minute, endTime.Second);

            if (compareStartDate > compareEndDate)
                throw new Exception(errorMessage);
        }
        #endregion

        #region Integer
        public static void EnsureIsGreaterThan(int value, int comparer, string errorMessage)
        {
            if (value < comparer)
                throw new Exception(errorMessage);
        }

        public static void EnsureIsLessThan(int value, int comparer, string errorMessage)
        {
            if (value > comparer)
                throw new Exception(errorMessage);
        }

        public static void EnsureIsGreaterOrEqualThan(int value, int comparer, string errorMessage)
        {
            if (value < comparer)
                throw new Exception(errorMessage);
        }

        public static void EnsureIsLessOrEqualThan(int value, int comparer, string errorMessage)
        {
            if (value > comparer)
                throw new Exception(errorMessage);
        }
        #endregion

        #region String
        public static void EnsureStringIsNotNullOrEmpty(string value, string errorMessage)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(errorMessage);
        }
        #endregion

       
        public static void AssertArgumentEquals(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentFalse(bool boolValue, string message)
        {
            if (boolValue)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentLength(string stringValue, int maximum, string message)
        {
            int length = stringValue.Trim().Length;
            if (length > maximum)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentMatches(string pattern, string stringValue, string message)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(stringValue))
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentNotNullOrEmpty(string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentNotEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentNotNull(object object1, string message)
        {
            if (object1 == null)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentRange(double value, double minimum, double maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentRange(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentRange(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentRange(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertArgumentTrue(bool boolValue, string message)
        {
            if (!boolValue)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertStateFalse(bool boolValue, string message)
        {
            if (boolValue)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertStateTrue(bool boolValue, string message)
        {
            if (!boolValue)
            {
                throw new InvalidOperationException(message);
            }
        }

        protected AssertionConcern()
        {
        }

        protected void SelfAssertArgumentEquals(object object1, object object2, string message)
        {
            AssertionConcern.AssertArgumentEquals(object1, object2, message);
        }

        protected void SelfAssertArgumentFalse(bool boolValue, string message)
        {
            AssertionConcern.AssertArgumentFalse(boolValue, message);
        }

        protected void SelfAssertArgumentLength(string stringValue, int maximum, string message)
        {
            AssertionConcern.AssertArgumentLength(stringValue, maximum, message);
        }

        protected void SelfAssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            AssertionConcern.AssertArgumentLength(stringValue, minimum, maximum, message);
        }

        protected void SelfAssertArgumentMatches(string pattern, string stringValue, string message)
        {
            AssertionConcern.AssertArgumentMatches(pattern, stringValue, message);
        }

        protected void SelfAssertArgumentNotEmpty(string stringValue, string message)
        {
            AssertionConcern.AssertArgumentNotNullOrEmpty(stringValue, message);
        }

        protected void SelfAssertArgumentNotEquals(object object1, object object2, string message)
        {
            AssertionConcern.AssertArgumentNotEquals(object1, object2, message);
        }

        protected void SelfAssertArgumentNotNull(object object1, string message)
        {
            AssertionConcern.AssertArgumentNotNull(object1, message);
        }

        protected void SelfAssertArgumentRange(double value, double minimum, double maximum, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected void SelfAssertArgumentRange(float value, float minimum, float maximum, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected void SelfAssertArgumentRange(int value, int minimum, int maximum, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected void SelfAssertArgumentRange(long value, long minimum, long maximum, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected void SelfAssertArgumentTrue(bool boolValue, string message)
        {
            AssertionConcern.AssertArgumentTrue(boolValue, message);
        }

        protected void SelfAssertStateFalse(bool boolValue, string message)
        {
            AssertionConcern.AssertStateFalse(boolValue, message);
        }

        protected void SelfAssertStateTrue(bool boolValue, string message)
        {
            AssertionConcern.AssertStateTrue(boolValue, message);
        }

    }

}
