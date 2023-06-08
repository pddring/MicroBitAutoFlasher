# MicroBitAutoFlasher
This program was designed by P Dring at Fulford School in York.

We use micro:bits in Computing lessons and DT lessons. 
We tend to get students to code online (using create.withcode.uk, make code or the new online python editor). 

We used to get students to save a .hex file and copy it to their micro:bit. 
We'd often get students trying to open the hex files instead of copying them across, or just not copying them across at all and wondering why the code wasn't running on their physical micro:bit

Since Feb 2023 almost all attempts to copy the .hex file started failing. It seems that this is due to a weird quirk 
in a recent Windows update (more info: https://support.microbit.org/support/solutions/articles/19000145576-error-transferring-file-to-the-micro-bit-since-windows-update-in-february-2023)

The workaround suggested on that site suggested using WebUSB (sadly doesn't seem to work for us) or to use robocopy (which solves the problem, but students can't access the command line so this doesn't work for us either)

This program is designed to detect your downloads folder then scan it for any new .hex files. It will also scan to see if a micro:bit is detected.
If a new .hex file is detected and a micro:bit is plugged in, the program will use robocopy (robust copy - I didn't know that even existed until today :) to automatically copy it to the device.
Win win.

![image](https://github.com/pddring/MicroBitAutoFlasher/assets/760604/58e7c5c7-005c-4c1a-b27a-60919e752733)

When a new .hex file is detected the icon goes red until the file is copied successfully:
![image](https://github.com/pddring/MicroBitAutoFlasher/assets/760604/5c054d76-9eb2-4d33-8caf-546208f8a91f)


You can download the source code here (designed with C# in Visual Studio 2022) or you can download [an msi installer here](https://github.com/pddring/MicroBitAutoFlasher/raw/master/Installer/Microbit%20Auto%20Flash%20Installer.msi)

Hope it's useful :)
