RimWorld Mod Listing Generator
=================================

I enjoy playing with a lot of mods (as many do, these days) and wanted to find a way to package the mods along with ModsConfig.xml to preserve load order.

This app started out as a really quick Ruby script for my own lackluster Twitch ambitions.

I shared it in a thread on /r/rimworld, and was encouraged to bring it to a usable form as something the community might enjoy.

Without further ado...

What You Need
---------------------------------
Hopefully, just the release ZIP and some mods installed in the game. It's written in C# on GTK+.

I haven't signed the code, so Windows will likely be none to happy with you for trying to run it. I promise I won't (intentionally) break your computer.

It was developed on Visual Studio Community in OS X, but I haven't quite worked out how to package up the Mac and Linux builds. In the meantime, you can run it directly from source in Visual Studio on any platform.

What It Does
---------------------------------
The app will read your ModsConfig.xml file and, in order, try to track down the mods directories listed.

First it will look in the RimWorld/Mods/ directory, and then the Steam Workshop mods directory.

Without selecting any additional checkboxes, the app will write an Output/index.html file with links to the mods (assuming they come from the Workshop and not the Ludeon forums; better link support TBD.)

Optionally, you can have it package up all of the mods into a zipfile in the Output directory.

If you're really brave, you can:
* enter a named profile to access Amazon Web Services
* provide an existing private S3 bucket address
* provide an existing Cloudfront Distribution identifier (which should be serving up the S3 bucket contents)

This last bit is a bit advanced for the amount of free time I have to get this out the door at the moment, but the TL;DR is that you can host the mod list and zipfile in a cheap and scalable way.

Questions? Comments? Suggestions?
---------------------------------
I'm all ears!