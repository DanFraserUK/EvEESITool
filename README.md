# EvE ESI Tool

## Description

This tool will do all of the work for you in downloading data from the EvE Swagger Interface.

[EvEESITool](https://github.com/seraphx2/EvEESITool) by [https://github.com/seraphx2](seraphx2) is used to assist with accessing the EvE Swagger Interface which has been integrated into the solution because of changes required.

## Setting up for first use

Go to https://developers.eveonline.com/ - log in, create a new application, name it whatever you wish.
Choose 'Authentication & API Access' add *ALL* the scopes (this will be variable in the future) and set the callback url to https://localhost/callback/

Confirm, then view application and you'll find the items you need.

There are two ways to input the data to the program.

Option one is to create a file called config.txt in the same directory as the EvEESITool.dll and paste the following text with the details changed to the items found previously.

    {
        "EsiUrl": "https://esi.evetech.net/",
        "DataSource": Tranquility,
        "ClientId": "<YOUR CLIENT ID>",
        "SecretKey": ",YOUR SECRET KEY",
        "CallbackUrl": "https://localhost/callback/",
        "UserAgent": "YOUR EMAIL"
    }

Option two, if no config.txt exists the dll will ask you if you are running a console application.

Once these are entered, be warned that on first run of the dll it needs to download a lot of data!  Once the static data export is downloaded the program will open your default web browser to ask for authorization.  As experienced with many other applications choose your character and scroll down then click authorize.  Copy the url (all of it) and paste into the console.  From that point onwards no further input is needed.  The tool will download any data available and save it to disk.  It will also auto-update the data once an hour.

If you have concerns about the data being entered `ConfigDataConsoleEntry` in `AppSettings.cs` is where the data entry occurs.  `Authenticator.cs` is where the information gets used to authorise the connection to the EvE Swagger Interface.  This will be subject to changes in the future to appear like many other applications that access the Eve Swagger Interface.

## Usage in your application

Either play in the program.cs in the example project or in your application add `using EvEESITool;` and instantiate `Data esiData = new Data()` (of course name esiData whatever you wish).

    Data esiData = new Data();
    
    // examples
    int characterID = esiData.Character.CharacterID;
    
    SkillDetails skills = esiData.Character.Skills;
    
    var i = esiData.Public.Industry.GetFacilities();
    
    ESI.NET.Models.Alliance.Alliance a = esiData.Alliance.GetAlliance(esiData.Corporation.AllianceHistory[1].AllianceId);
    
    foreach (ESI.NET.Models.Corporation.Facility f in esiData.Corporation.Facilities)
    {
    	Console.WriteLine(esiData.Universe.GetStructure(f.FacilityId).Name + ", " 
    	+ esiData.SDE.SolarSystems.Search(f.SystemId).SolarSystemName + ", "
    	+ esiData.SDE.InvTypes.Search(f.TypeId).TypeName);
    }

The ESI data is grouped under common sense, so anything relating to the character is under `Data.CharacterData` etc.

Because the dll downloads data and saves to disk, do not use subfolders in your application called Data and SDE to prevent the accidental overwiting of necessary files.

## Future changes

- Create an easier, quicker setup
- Complete method ranges for accessing ESI data - if not functionality
- Restructure to rely on Owner Hashes
- Expand for multiple characters


## Comments, suggestions etc

Message me here, raise an issue, contact me ingame as `Danelle Martos`.  If you use this tool I would be greatly interested in how you use it.  If you use this tool or any part of its code please add credit to me into your application and maybe send me some isk?