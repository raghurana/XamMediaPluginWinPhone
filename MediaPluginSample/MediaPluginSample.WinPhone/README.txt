

Bhavik, Dishant

As you can see we are using the Xam.Plugin.Media in this demo application. 
https://github.com/jamesmontemagno/Xamarin.Plugins/tree/master/Media
This plugin is the latest reincarcenation of the Xamarin.Mobile Component that we are using in the Actus app.
So I recommend adding the package from Nuget in all projects and remove Xamarin.Mobile. there may be breaking changes but hopefully should be easy to fix. 
On ios and android it should work very similar to xamarin.mobile without too much changes, but it is slightly broken on win phone 8
The workaround is to reference Plugin.Media from an external directory and not use the nuget package dll. 
You can copy the dependencies/WindowsPhoneMediaPicker from this solution and paste in libs\wp81 for Actus. Then change reference of Plugin.Media on wp 8 to this new libs location.
ios and android should work with nuget package dll. So dont worry about that. 
If this is done correctly the camera should work from the app. 
Also note in App.Xaml.cs needs to be added to Actus Win Phone 8 project

 protected override void OnActivated(IActivatedEventArgs args)
        {
            MediaImplementation.OnFilesPicked(args);
        }

We should be able to use this code for selecting pics from gallery as well and hopefully remove some of the plumbing 
code we've written to make this work and simplify the attachments page. 

Let me know if you have any issues.


