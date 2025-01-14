# DangerZoneHackerTracker

## What it does
* Alerts you when joining a Danger Zone match if any of the other players are part of your cheaters database
* Gives an one-click method for alerting the rest of the server that cheaters are present in your game
* Provides a UI for adding newly-discovered cheaters to your cheaters database
* Automatically flushes cached memory between maps to avoid crashes

## Initial setup
* Install runtime dependencies:
  * .Net Runtime 6: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-6.0.5-windows-x64-installer
* Add `-netconport 2121` to your CS:GO launch options. This allows DangerZoneHackerTracker to send & receive text from CS:GO's console

## How to use
* Launch CS:GO and `DangerZoneHackerTracker.exe`
* Queue for Danger Zone and join a game
* When connected to a server, the Hacker Tracker will scan the list of players in your server and alert you with a sound and toast notification if any are part of your hackers database
* If you have a known cheater in your server, you will see an *Alert Server* button next to their name in the players list. Clicking this will let the other players in your server know about the presence of the cheater
* _Optional_: you can import the included `exported_cheaters` JSON file to initialize your cheater list with one curated by myself. Otherwise you will need to add new cheaters to your local database as you encounter them

## Adding Cheaters
* Through the DangerZoneHackerTracker UI: from the **Add** menu, you can bulk add cheaters by providing a list of Steam profile URLs, or add a single cheater which allows you to specify cheat types and other information
* When connected to a server, you can add a player directly from the player's list
* Import a `.json` or `.sq3` database previously exported from another DangerZoneHackerTracker instance

## Other useful console commands
* `cl_sanitize_muted_players 0`: disables the sanitized name that is given to automuted players by default. This allows you to see muted players' true names which is useful for identifying them or communicating to others who you are talking about. Since this setting doesn't stick between launches of CS:GO you must put it in your `autoexec.cfg`

## Building
* You will need Visual Studio Community/Professional/Enterprise: [download here](https://visualstudio.microsoft.com/vs/community/)
* Open [DangerZoneHackerTracker.csproj](https://github.com/tlewis/DangerZoneHackerTracker/blob/main/DangerZoneHackerTracker.csproj) with Visual Studio
* Build the **DangerZoneHackerTracker** project
* The executable and runtime dependencies will be in `bin/<config>/.net6.0-windows`
* The project is configured to perform strong name signing on the final executable using a signing key not checked into the repository. You can either reconfigure the project to use a key of your own or disable the strong name signing in the project's settings under **Build -> Strong Naming**

## Ideas for future improvement
* Add ability to use a remote SQL database of cheaters that can be shared between multiple users or the entire community
* Misc UI improvements
  * Sortable columns for the hacker list
  * Filter/search for the hacker list
* Do you have thoughts on how to make this more useful? Please let me know in the project's Issues

## Project History
* Originally developed by KidFearless: https://github.com/kidfearless/DangerZoneHackerTracker
* Forked here to continue development and make improvements/feature enhancements as needed
