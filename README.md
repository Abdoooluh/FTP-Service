>> FTP Service Installation Guide

This service will act as an automated routine, to transfer all the contents from a local folder to a remote ftp server after a fixed interval. It will not copy files that are already present at the remote server, and if any file is deleted from the local folder AFTER it has already been transmitted to the remote server, such files will not be deleted from the server.


Before installation, there is a brief set up. Follow the instructions:

- Find the file named "App.config" in the root folder of the service (called 'FTP Service') and open it (right click on the file > open with another app > notepad)
- Update the "value" field of lines 4-10 according to the instructions (instructions are given in the form  <!-- instruction --> at the end of each line)
- Close the notepad and click on "save" to save the changes to the App.config file


Now that the initial set up is done, it is time to install the service.
- Go to start menu and type 'cmd'
- Right click on "Command Prompt" and click on "Run as Administrator" and then click on "Yes" on the pop-up prompt window
- Copy (without the quotes "") the subsequent line in front of the arrow -> "cd C:\Windows\Microsoft.NET\Framework\v4.0.30319"
- Paste this line into the Command Prompt (ctrl + v) and press Enter
- Now in your file explorer, go to the parent directory folder where you have placed the 'FTP Service' folder
- Click on the address bar and copy the address of the folder containing your 'FTP Service' folder (this should be the parent folder of FTP Service, not FTP Service itself)
- Paste the address that you just copied in the subsequent line in front of the arrow, replacing the text that says '<your address here>' -> InstallUtil.exe "<your address here>\FTP Service\FTP Service\bin\Debug\FTP Service.exe"
- Copy the above line (modified with your address, complete with the "")
- Paste this line into the Command Prompt and press Enter
- Your Command Prompt should take a few seconds to install the service, and then show a line confirming successful installation of the service




Now it's time to start the service that you just installed:
- Press Windows+R to open Run window
- Type in "Services.msc" to open the services menu
- Scroll down to "FTP Service"
- Right-click on "FTP Service" and then click on "Start Service"

Now the service should be up and running! 

If you want to uninstall the service:
- Go to start menu and type 'cmd'
- Right click on "Command Prompt" and click on "Run as Administrator" and then click on "Yes" on the pop-up prompt window
- Copy (without the quotes "") the subsequent line in front of the arrow -> "cd C:\Windows\Microsoft.NET\Framework\v4.0.30319"
- Repeat the process in the installation phase to find the address of the folder containing the 'FTP Service' folder and copy its address
- Paste the address that you just copied in the subsequent line in front of the arrow, replacing the text that says '<your address here>' -> InstallUtil.exe -u "<your address here>\FTP Service\FTP Service\bin\Debug\FTP Service.exe"
- Copy this modified line, and paste it into the Command Prompt and press Enter
- The service should be uninstalled and you will be told the same by the Command Prompt window


Some additional info:
- The service maintains execution logs in "FTP Service\FTP Service\bin\Debug\Logs" folder - These logs are named after each day the service was executed, and they also contain the time stamps for every instance of service start, data upload, and service termination,
- The service can be set to start automatically - for this, in the 'Services.msc' window, right click on the 'FTP Service' > properties >  Startup Type > Automatic. This will cause the service to start automatically on system startup and eliminate the need for manually starting it every time.

-- Created by Abdullah
github -> https://github.com/Abdoooluh/FTP-Service
