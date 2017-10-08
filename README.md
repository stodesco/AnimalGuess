# AnimalGuess
Animal Guess Game

Follow the instructions to get the code running on any .net core supported environment:

* install .net core 2.0
* clone this repository into a local directory
* run `dot net restore` on a command line in the directory
* run `dotnet ef database update`
* run `dotnet run`
* Browse the address [http://localhost:5000/](http://localhost:5000/)

### Notes:

This has been implement in .net core on a mac using the .net core cli to scaffold the project. I used then visual studio for mac to edit the files. The project uses ASP.NET MVC with razor views and SQLite as a simple standalone DB. The DB is accessed via Entity Framework Core. 

I chose the technologies mainly to keep the challenge interesting and learn something new.

There are plenty of limitations: The game is really kept 'state less'. Adding state would be necessary to give a better game play experience. 

### Limitations:

* No unit tests added yet
* Minimum styling
* No seperation of a data access layer/repository
