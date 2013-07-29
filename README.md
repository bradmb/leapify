Leapify
=======

Leap Motion controller for Spotify

**What is it?**
Leapify is a small application that sits in your system tray and interacts with both the Leap Motion controller and Spotify, allowing you to control your music with *your hands*!

**How does it work?** You move your hands, it uses the built in gesture recognition of the Leap Motion SDK, and it tells Spotify to do something. It's pretty simple, but you definitely have to do some error checking/validation unless you want to fire off five different things at once.

**Where can I download it?** You can download the source code from this page if you want to compile and run (or contribute!) the latest version of the code. However, if you'd just like to run an installer and start using it, check out the release page for the latest compiled releases: https://github.com/bradmb/Leapify/releases

-------

#### The Controls

Before using the controls below, check out the settings window inside the application (right click on icon -> Configure). In there, you can see the default configuration and tweak it to best work for you.

Also, as a default, swipe and tap actions require that **only two fingers** are visible. If you show any more or less, it will ignore you. I've found it helps to prevent against accidental actions. The version I originally wrote in a half hour had a lot of accidental actions fire since it didn't have this protection.

**Swipe Left** -- Previous Track

**Swipe Right** -- Next Track

**Tap** -- Play/Pause

**Counterclockwise Circle** -- Volume Down

**Clockwise Circle** -- Volume Up

***Note for circles:*** Two hands must be visible to the Leap Motion controller. I did it this way so it doesn't accidentally trigger any swipe actions. My suggestion is to take one hand with the palm facing forward, then make a circle with the other hand (or a finger on the other hand)

-------

#### Disclaimer

**This is a work in progress.** This was written in less than two days, and will get better over time as I learn more about the Leap Motion controller (and clean up the code). Also, if it melts your computer or does anything that makes you unhappy -- not my fault. You're responsible for what you run on your system.

-------

#### Want to help?

See something you don't like in the code? Know of a better way to do it? *Please* submit an issue or a pull request! I welcome any chance to learn the error of my ways. :)
