MarsRovers
~~~~~~~~~~~~~~~~~
FENG Zhichao
flankerfc@gmail.com
2010/01/07
~~~~~~~~~~~~~~~~~

MarsRovers is implemented using C# and tested using NUnit.
src\MarsRovers-VS2008.sln is the solution file for Microsoft Visual Studio 2008.
src\MarsRovers\MarsRovers.csproj is the main project file.
src\MarsRoversTests\MarsRoversTests.csproj is the testing project file using NUnit.

~~~~~~~~~~~~~~~~~

MarsRovers.csproj

MarsRovers is a executable windows console program. The output is "MarsRovers.exe".
To test it using the supplied data just use the "demoInput.txt" file.
In windows console:
    MarsRovers.exe < demoInput.txt
Or you can run MarsRovers.exe directly and input the supplied data in the console.

src\MarsRovers\Command\* : commands to control rovers.
src\MarsRovers\Nasa\Rover.cs : represent a robotic rover.
src\MarsRovers\Nasa\NasaMission.cs : represent a whole nasa mission.
src\MarsRovers\ConsoleMissionController.cs : control NasaMission with input/output.
src\MarsRovers\Program.cs : program entry.

~~~~~~~~~~~~~~~~~

MarsRoversTests.csproj

MarsRoversTests and "src\MarsRoversTests.nunit" file is for NUnit to test the source code.

src\MarsRoversTests\CommandTests.cs : testing commands.
src\MarsRoversTests\NasaMissionTests.cs : testing nasa mission.
src\MarsRoversTests\MissionControllerTests.cs : testing the whole program with demo data.

~~~~~~~~~~~~~~~~~
THANKS.
~~~~~~~~~~~~~~~~~

