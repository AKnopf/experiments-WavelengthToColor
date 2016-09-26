# experiments-WavelengthToColor

## description

I did a short experiment several years back on Wavelengths in 2008 with colors and wavelengths. I was working for Beckman Coulter on their latest Flow Cytometer, which involved working with dozens of lasers of different wavelengths. These lasers would be reflected and filtered to obtain different wavelengths and this needed to be displayed to the user in an intuitive UI.
Back then, I wrote a little Windows application that would convert the wavelength to RGB colors, for my reference.
I figured I could take the same approach and make it a Silverlight application and here it is… As you can see from the code I am using a PolyBezierSegment and modifying the location of the three points of each wave when the trackbar slider is moved.
The corresponding wavelength in nano meters corresponds to the actual color of the light wavelength.

The watermarked curves mark the margins of the visible spectrum. Go ahead and move the slider below:

## usage
You must have a browser that is capable of displaying Silverlight content. Unfortunately, Chrome is not one of them. 

Clone and browse to the **Silverlight_WavelengthToColor.Web** folder and view **Silverlight_WavelengthToColorTestPage.html** in your browser

If you are interested in the source code, browse the **Silverlight_WavelengthToColor_Source** folder.

You'll get to see something like this: 

![619nm](https://i.imgur.com/5t4e2Di.png) ![456nm](http://i.imgur.com/VC0KIvO.png)
