using System;
using MapKit;
using CoreLocation;

namespace ExtendedMap.Forms.Plugin.iOS
{
	public class ExtendedMapAnnotation : MKAnnotation
	{
		private CLLocationCoordinate2D _coordinate;
		public override CLLocationCoordinate2D Coordinate {get{return _coordinate;}}
		private string _title, _subtitle;
		public override string Title { get{ return _title; }}
		public override string Subtitle { get{ return _subtitle; }}

		public event EventHandler<ExtendedMapAnnotation> Clicked;

		public void AnnotationClicked(object sender)
		{
			if (Clicked != null) {
				Clicked.Invoke (sender, this);
			}
		}

		public ExtendedMapAnnotation (CLLocationCoordinate2D coordinate, string title, string subtitle) {
			_coordinate = coordinate;
			_title = title;
			_subtitle = subtitle;
		}
	}
}

