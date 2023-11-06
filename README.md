# Serial_Terminal_plus

### Serial terminal app for Windows PC with custom buttons  
You can use this app instead of the terminal emulator "Tera Term".

* You can register frequently used transmission character strings in the button and send the character string by clicking the button.
* You can register a character string for each button by pressing SHIFT + click.
* The number of buttons that can be registered is 36.
* You can add a timestamp to the beginning of the line when receiving.
* The transmitted string can be included in the received content as a local echo.
* You can save the received contents to a text file.

### Convenient usage

* This app was created for communication between Windows PC and Microbit.
* This is useful for Microbit program developers to predetermine multiple commands and have Microbit perform the default behavior for those commands. It will be like a remote control operation.
* You can use the app not only with Microbit but also with other microcontroller systems.

### How to download

* Open the URL [https://github.com/healthywalk/Serial_Terminal_plus/](https://github.com/healthywalk/Serial_Terminal_plus/)
* Select "Download Zip" from the green button labeled "code".
* "Serial_Terminal_plus-main.zip" will be downloaded, so unzip it.
* You will find "Serial_Terminal_plus.exe" in Serial_Terminal_plus-main \ Serial_Terminal_plus \ bin \ Release.
* You can put "Serial_Terminal_plus.exe" in a convenient place and start it by double-clicking.

### How to use

* Connect the Microbit and your Windows PC with a USB cable in the same way as when creating a program with MakeCode.
* If an application that performs serial communication such as MakeCode is open, close it.
* On the Microbit, run a program that uses serial transmission and serial reception.
* Open "Serial Terminal plus".
* Check the serial port and other settings and press "Connect".
* Enter an appropriate character string (alphanumeric characters) in "Text to Send" and press the "Send" button to send the character string to Microbit.
* "Text Received" displays the received string from the Microbit is displayed.
* When you press the "Save" button, you can save the contents of "Text Received" at that time in a text file.
* To register a character string in a custom button, Shift + Click the button you want to register. Up to 36 can be used.
* To exit, press the "Disconnect" button and then the exit button on the upper right.
# Serial_Terminal_plus
