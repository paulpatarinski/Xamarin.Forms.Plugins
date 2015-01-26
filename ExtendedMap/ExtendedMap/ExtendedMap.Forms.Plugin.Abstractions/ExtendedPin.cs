using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace ExtendedMap.Forms.Plugin.Abstractions
{
	public class ExtendedPin
	{
		public string Label { get; set; }

		public string Address { get; set; }

		public string PinIcon { get; set; }

		public string PhoneNumber { get; set; }

		public Position Position { get; set; }

		public List<ScheduleEntry> ScheduleEntries { get; set; }

		/// <summary>
		/// Other data relevant to the pin. ie. Website Url, 
		/// </summary>
		/// <value>The others.</value>
		public List<ExtraDetailModel> Others { get; set; }
	}
}

