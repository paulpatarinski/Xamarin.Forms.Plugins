using System;
using CoreLocation;
using MapKit;

namespace ExtendedMap.Forms.Plugin.iOS.Models
{
	public class ExtendedMapAnnotation : MKAnnotation
	{
    public ExtendedMapAnnotation(CLLocationCoordinate2D coordinate, string title, string subtitle, string pinIcon)
    {
      _coordinate = coordinate;
      _title = title;
      _subtitle = subtitle;
      _pinIcon = pinIcon;
    }

		private readonly CLLocationCoordinate2D _coordinate;
	  private readonly string _title;
	  private readonly string _subtitle;
	  private readonly string _pinIcon;

	  public override string Title { get{ return _title; }}
		public override string Subtitle { get{ return _subtitle; }}

	  public string PinIcon
	  {
	    get
	    {
	      return _pinIcon;
	    }
	  }

	  public override CLLocationCoordinate2D Coordinate { get { return _coordinate; } }

		public event EventHandler<ExtendedMapAnnotation> Clicked;

		public void AnnotationClicked(object sender)
		{
			if (Clicked != null) {
				Clicked.Invoke (sender, this);
			}
		}
	}
}