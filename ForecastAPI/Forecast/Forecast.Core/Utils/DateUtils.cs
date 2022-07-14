using System;

namespace Forecast.Core.Utils
{
    /// <summary>
    /// Custom util to retrieve timestamp
    /// </summary>
    public static class DateUtils
    {
        public static long GetUtcTimestamp(DateTime date) {
            var updatedDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
            return (long)(updatedDate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
