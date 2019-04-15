# Robo-sumo-unity
A 2-player Android/touch-based game built in Unity3D

Google Play store link:
https://play.google.com/store/apps/details?id=com.DavidDickBall.ChickenFokkers
When building from Unity, call this BotSumo  and make sure checkbox on PaidVersion in scene "menu" is unchecked. 
Package has to be com.DavidDickBall.ChickenFokkers



# note to self - how to add new bot
Copy an existing character, replace the VFX. Change the "Player character" name. Save in "Resources" folder. 
In PlayerSelectScript, create new elseif in showOnlyP1Character() & showOnlyP2Character()
Create new isXUnlocked variable, and set to PlayerPref in Start()
In unlockSelectedBot() create new elseif for new variable
In playerSelect scene, place p1 & p2 in place. Increment the array on "SceneController" and drag the object from the scene into the array. 
Add entry to public var playerCharacters at top of playerSelectScript
You can test the character by setting the default character in GameControllerScript by changing var defaultPlayer, and then in LoadPlayer(), change "playerToLoad" too.


# Deploy for iOS 
Target SDK - "Device SDK" (or similator if you want to test this in xcode)
Landscape left
Set signing team ID to NSSAF7Q7FV
Set bundle to com.DavidDickBall.ChickenFokkers
Create xcode project by building from unity
In xcode go to product > Archive
If it complains about team not selected go to project > general tab and look under the "signing" heading, this might become unselected. 
Go to https://appstoreconnect.apple.com/login > My Apps and create a new version (with text for each language)
It will ask about Advertising Identifier, click yes, then yes for "Serve advertisements" & no for "Attribute this app installation to a previously served advertisement"
Then submit 