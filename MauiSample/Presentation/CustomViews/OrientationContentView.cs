using Sharpnado.Tabs;
using Sharpnado.TaskLoaderView;

namespace MauiSample.Presentation.CustomViews
{
    public abstract class OrientationContentView : ContentView
    {
        private DisplayOrientation _lastKnownOrientation = DisplayOrientation.Unknown;
        protected View PortraitView { get; set; }
        protected View LandscapeView { get; set; }

        public OrientationContentView() : base()
        {
            SetContentFromOrientation();
        }

        private void SetContentFromOrientation()
        {
            _lastKnownOrientation = DeviceDisplay.MainDisplayInfo.Orientation;

            if (_lastKnownOrientation == DisplayOrientation.Portrait)
            {
                SetupPortraitLayout();
            }
            else if (_lastKnownOrientation == DisplayOrientation.Landscape)
            {
                SetupLandscapeLayout();
            }
            else
            {
                SetupLandscapeLayout();
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (DeviceDisplay.MainDisplayInfo.Orientation == _lastKnownOrientation)
                return;

            SetContentFromOrientation();
        }

        protected virtual void SetupLandscapeLayout()
        {
            if (LandscapeView != null)
            {
                Content = LandscapeView;
            }
            else
            {
                // If the Layout is null, we haven't assigned it yet, so set DisplayOrientation to unknown in order to avoid blocking setup.
                _lastKnownOrientation = DisplayOrientation.Unknown;
            }
        }

        protected virtual void SetupPortraitLayout()
        {
            if (PortraitView != null)
            {
                Content = PortraitView;
            }
            else
            {
                _lastKnownOrientation = DisplayOrientation.Unknown;
            }
        }
    }
}