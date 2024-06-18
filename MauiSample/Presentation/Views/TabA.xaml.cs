﻿using MauiSample.Presentation.CustomViews;
using Sharpnado.Tabs;
using Sharpnado.TaskLoaderView;

namespace MauiSample.Presentation.Views;

public partial class TabA : OrientationContentView
{
    public TabA()
    {
        InitializeComponent();
        PortraitView = PortraitStackLayout;
        LandscapeView = LandscapeStackLayout;
    }

    private async Task TakeScreenshot()
    {
        var screenshot = await Screenshot.CaptureAsync();
        var stream = await screenshot.OpenReadAsync();

        var image = new Image
            {
                Margin = new Thickness(0, 20, 0, 0),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Aspect=Aspect.AspectFit,
                Rotation = -90,
                Source = ImageSource.FromStream(() => stream),
            };
        
        //ScreenshotContainer.Content = image;
    }
}