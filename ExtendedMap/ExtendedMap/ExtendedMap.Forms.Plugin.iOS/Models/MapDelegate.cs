using System;
using System.Drawing;
using System.IO;
using System.Linq;
using MapKit;
using UIKit;
using Foundation;

namespace ExtendedMap.Forms.Plugin.iOS
{
	public class MapDelegate : MKMapViewDelegate 
	{
		protected string annotationIdentifier = "BasicAnnotation";
		UIButton detailButton; // avoid GC

		public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, IMKAnnotation annotation)
		{
			// try and dequeue the annotation view
			MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(annotationIdentifier);   
			// if we couldn't dequeue one, create a new one
			if (annotationView == null)
				annotationView = new MKPinAnnotationView(annotation, annotationIdentifier);
			else // if we did dequeue one for reuse, assign the annotation to it
				annotationView.Annotation = annotation;

			// configure our annotation view properties
			annotationView.CanShowCallout = false;
			(annotationView as MKPinAnnotationView).AnimatesDrop = true;
			annotationView.Selected = true;
		  annotationView.Image = GetImage("Chicken.png");
		
			return annotationView;
		}

    public UIImage GetImage(string imageName)
    {
      var documents =
        Environment.GetFolderPath(Environment.SpecialFolder.Resources);

      var filename = Path.Combine(documents, imageName);

      var image = UIImage.FromFile(filename).Scale(new SizeF() { Height = 20, Width = 30 });

      return image;
    }

		public override void DidSelectAnnotationView (MKMapView mapView, MKAnnotationView view)
		{
			var pinAnnotationView = view as MKPinAnnotationView;

			if (pinAnnotationView != null) {
				var extendedMapAnnotation = pinAnnotationView.Annotation as ExtendedMapAnnotation;

				if (extendedMapAnnotation != null) {
					extendedMapAnnotation.AnnotationClicked (mapView);
				}
			}
		}
//	
		// as an optimization, you should override this method to add or remove annotations as the
		// map zooms in or out.
		public override void RegionChanged (MKMapView mapView, bool animated) {}
	}
}

