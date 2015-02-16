using System;

namespace ExtendedMap.Forms.Plugin.Abstractions.Models
{
	public class ScheduleEntry
	{
		public string Day {
			get;
			set;
		}

		/// <summary>
		/// The start and end time
		/// </summary>
		/// <value>The times.</value>
		public string HoursOfOperation { get; set; }
	}

  public class ScheduleEntryModel
  {
    public DateTime StartTime
    {
      get;
      set;
    }

    public DateTime EndTime
    {
      get;
      set;
    }
  }
}