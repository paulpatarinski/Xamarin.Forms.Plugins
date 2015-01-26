using System;

namespace ExtendedMap.Forms.Plugin.Abstractions
{
  public static class DateTimeExtensions
  {
    public static DateTime FromWeekDay(this DateTime date, DayOfWeek dayOfWeek)
    {
      var today = new DateTime();

      for (int day = 1; day <= 7; day++)
      {
        if (today.DayOfWeek == dayOfWeek)
          return today;

        today = today.AddDays(1);
      }

      return today;
    }
  }
}
