Task2. Game "Life"   [![AppVeyor build status](https://ci.appveyor.com/api/projects/status/github/siandreev/megafon_5G?branch=master&svg=true)](https://ci.appveyor.com/project/siandreev/megafon_5G/branch/master)
-----------------



The Conway's Game of Life is a cellular automaton invented by mathematician John Conway in 1970. The implementation of this automaton is similar to the development of a population of primitive organisms. The laws of the “game” are reflected in many theories from various fields of science: from quantum physics and bacteriology to cybernetics and astronomy.

#### Rules
* The scene of the game is a cell field. The user himself indicates his size using combobox.
* Each cell can have two states: full (alive), empty (dead).
* Each cell has neighbors -8 neighboring cells.
* In an empty cell, next to which there are exactly three filled cells, life is born.
* If the filled cell has three or two filled neighbors, then it continues to be filled.
* Otherwise, if there are less than two or more than three neighbors, the cell dies (“from loneliness” or “from overpopulation”).

How to install and run
----------------------

You can only install and run the application on the Windows operating system, because it was created with .NET Framework.
The executable file is located at LifeTask/bin/Debug/LifeTask.exe

How to play
-----------

Select the field size in the pop-up menu. Then press start. If necessary, by pressing the reset button you can start a new game on a field of the same size.

Unit tests
----------

The application successfully passes all unit test.
