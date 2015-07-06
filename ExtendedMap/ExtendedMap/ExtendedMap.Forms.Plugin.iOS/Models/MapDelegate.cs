using System;
using System.Threading.Tasks;
using CoreGraphics;
using MapKit;
using UIKit;
using Xamarin.Forms;

namespace ExtendedMap.Forms.Plugin.iOS.Models
{
	public class MapDelegate : MKMapViewDelegate 
	{
	  private ExtendedMapAnnotation _previouslySelectedPin;
	  private const string AnnotationIdentifier = "BasicAnnotation";
	  private MKAnnotationView _previouslySelectedNativePin;

    public event EventHandler MapTapped;

	  public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, IMKAnnotation annotation)
		{
      var extendedAnnotation = annotation as ExtendedMapAnnotation;

	    if (extendedAnnotation == null) return null;

	    // try and dequeue the annotation view
	    var annotationView = mapView.DequeueReusableAnnotation(AnnotationIdentifier);

	    // if we couldn't dequeue one, create a new one
	    if (annotationView == null)
	    {
	      annotationView = new MKAnnotationView(extendedAnnotation, AnnotationIdentifier);
	    }
	    else // if we did dequeue one for reuse, assign the annotation to it
	      annotationView.Annotation = extendedAnnotation;

	    // configure our annotation view properties
	    annotationView.CanShowCallout = false;
	    annotationView.Selected = true;

	    if (!string.IsNullOrEmpty(extendedAnnotation.PinIcon))
	    {
	      annotationView.Image = UIImage.FromFile(extendedAnnotation.PinIcon);
	    }

	    return annotationView;
		}

	  public override async void DidDeselectAnnotationView(MKMapView mapView, MKAnnotationView view)
	  {
      //Call reset with delay in case another pin is selected
	    await Task.Delay(TimeSpan.FromMilliseconds(100)).ContinueWith((result) =>
	    {
         Device.BeginInvokeOnMainThread(() =>
         {
           if (_previouslySelectedNativePin != null && view == _previouslySelectedNativePin)
           {
             if (MapTapped != null)
               MapTapped.Invoke(this, new EventArgs());

             ResetPrevioslySelectedPin();
           }
         });
	    });
	  }

	  public override void DidSelectAnnotationView (MKMapView mapView, MKAnnotationView view)
		{
			var pinAnnotationView = view;

		  if (pinAnnotationView == null) return;

      if(_previouslySelectedNativePin != null)
        ResetPrevioslySelectedPin();
			
      view.Image = UIImage.FromFile("defaultPin.png").Scale(new CGSize(40,50));
      var extendedMapAnnotation = pinAnnotationView.Annotation as ExtendedMapAnnotation;

		  if (extendedMapAnnotation != null) {
		    extendedMapAnnotation.AnnotationClicked (mapView);
		  }

      _previouslySelectedPin = extendedMapAnnotation;
      _previouslySelectedNativePin = view;
		}

	  private void ResetPrevioslySelectedPin()
    {
      //todo : This should reset to the default icon for the pin (right now the icon is hard coded)
      if (_previouslySelectedNativePin != null && !string.IsNullOrEmpty(_previouslySelectedPin.PinIcon))
      {
        _previouslySelectedNativePin.Image = UIImage.FromFile(_previouslySelectedPin.PinIcon);
      }

      _previouslySelectedNativePin = null;
    }
	}
}