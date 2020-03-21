Adventure Construction Set Viewer
Copyright 2016 Dan Boris (danlb_2000@yahoo.com)

License
--------------------
    Adventure Construction Set Viewer (ACS Viewer) is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ACS Viewer is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with ACS Viewer.  If not, see <http://www.gnu.org/licenses/>.

System Requirements
-------------------

   Windows XP or greater 
   Microsoft .NET Framework 4.0


Features
--------

	This program allows you to view the contents of the game files created with any version
	of Adventure Construction Set. The program also has a rudimentary play function that allows you to walk 
	through the game maps.

	System Notes:
	In the IBM PC/MS-DOS version of Adventure Construction Set, adventures were stored as
	a file named with ADVEN.FPY or ADVEN.HRD. Feel free to rename the file for collecting
	purposes, but keep the extension. ACS Viewer will treat all .fpy and .hrd files as a
	PC ACS adventures.

	In the Commodore 64 version of Adventure Construction Set, adventures took up the
	entire contents of a floppy disk. Commodore 64 floppy disks are represented for
	emulation purposes as D64 files. ACS Viewer will try to open any .d64 file as a
	Commodore 64 ACS adventure. Note that when using an emulator or disk viewing
	program on an ACS adventure .d64, it will appear to be empty.
	
	Note: Different Commodore 64 emulators have different ideas of how to represent
	the colors of a Commodore 64 and there are also PAL vs. NTSC differences. This
	program uses the palette used by the CCS64 emulator, but you might want to use
	a different set of colors. The VICE emulator comes with a set of .vpl files
	representing different palettes. The files can also be modified in a text
	editor to create exactly the colors you want. To use one of these files
	instead of the CCS64 palette, save it in the same directory as AcsViewer.exe
	under the name "palette.vpl". The next time you run ACS Viewer it will use
	the new palette when opening adventures for the Commodore 64.
	
	In the Apple II version of Adventure Construction Set, adventures took up the
	entire contents of a floppy disk. Apple II floppy disks are represented for
	emulation purposes as DSK files. ACS Viewer will try to open any .dsk file as an
	Apple II ACS adventure. Note that if you try using an emulator or disk viewing
	program on an ACS adventure .dsk, you will get an error message, as the disk
	is so full of information it doesn't have room for a directory.
	
	In the Commodore Amiga version of Adventure Construction Set, adventures were stored as
	a file named Adventure on the floppy disk. Amiga floppy disks are represented
	for emulation purposes as ADF files. ACS Viewer is bundled with a command-line tool
	called UAEUNP (Unified Amiga Emulator file UNPacker). This took was taken from the
	UAE emulator, distributed via the GNU General Public License.
	
	If you try to use ACS Viewer to open an .adf file, it will call UAEUNP behind the
	scenes to extract and then open the Adventure file that was inside it. Feel free to
	rename Adventure to	any name you like, just so long as the file has no
	extension - I suggest calling it something like Amgiga_AdventureName. Once the file
	has been extracted, you open it directly instead of accessing the .adf file again.
	

Source Code
-----------

	The source code for the project can be opened and compiled with Microsoft Visual Studio 2015. The source code 
	can be found here:
	
	https://github.com/danlb2000/ACSViewer
	

Revision Log
------------
	V1.0 - 11/25/2016 - First release, for PC and Commodore versions of game.
	V2.0 - 02/14/2020 - Added support for Apple and Amiga versions of game.

