# EvE ESI Tool

## Description

This tool will do all of the work for you in downloading data from the EvE Swagger Interface.

[ESI.NET](https://github.com/seraphx2/ESI.NET) by [https://github.com/seraphx2](seraphx2) is used to assist with accessing the EvE Swagger Interface.

## Setting up for first use

Go to https://developers.eveonline.com/ - log in, create a new application, name it whatever you wish.
Choose 'Authentication & API Access' add *ALL* the scopes (this will be variable in the future) and set the callback url to https://localhost/callback/

Confirm, then view application and you'll find the items you need to copy into the console to set up the data.

If you have concerns about the data being entered `ConfigDataConsoleEntry` in `AppSettings.cs` is where the data entry occurs.  `Authenticator.cs` is where the information gets used to authorise the connection to the EvE Swagger Interface.  This will be subject to changes in the future to appear like many other applications that access the Eve Swagger Interface.

## Usage in your application

Either play in the program.cs itself or in your application add `using EvEESITool;` and instantiate `Data esiData = new Data()`.

The ESI data is grouped under common sense, so anything relating to the character is under `Data.CharacterData` etc.

## Future changes

The next update is to change all of the setting up process so anyone using this code has an easier time.

## Comments, suggestions etc

Message me here, raise an issue, contact me ingame as `Danelle Martos`.  If you use this tool I would be greatly interested in how you use it.  If you use this tool or any part of its code please add credit to me into your application and maybe send me some isk?