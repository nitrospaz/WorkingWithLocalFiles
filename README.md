
# Parsing Json from local files 

This project finds local files and parses the json in them to calculate totals.

Made with .NET 9 cross platform compatible console app.

## Features
- Cross-platform compatibility (Windows, Linux, macOS).
- Self-contained executable for easy distribution.
- Single file publish option for easy deployment.
- Parses JSON files from local directories.
- Calculates total daily sales for all stores.
- Writes the result to a text file.

## Getting Started

### Usage
- Place your daily sales.json files in the `stores` folder under the appropriate store.
- Make sure the `stores` folder is in the same directory as the executable.
- Run the application.
- The application will parse the JSON files, and calculate the total daily sales for all the stores.
- The result is written to a totals.txt file in the `salesTotalDir` folder.

### Prerequisites
- .NET 9 SDK
- IDE
- Basic knowledge of C# and JSON

### Running the Project
- clone repo
- run dotnet restore to install dependencies
- run dotnet build to build the project
- the stores folder should contain the daily sales.json files and be located in the same directory as the exe for the project
	- sometimes it will and sometimes it will not find the stores folder that is located with the code
- run dotnet run to execute the project
- the output will be created in the salesTotalDir folder, the salesTotalDir folder will be created if it does not exist.

### Gotachas
- The project is designed to work with JSON files that have a specific structure. Ensure that your JSON files match the expected format.
- The project assumes that the JSON files are located in the `stores` folder. If you change the folder structure, you may need to update the code accordingly.
- if there is no stores folder or the folder is empty, the program will throw an error. Make sure to create the stores folder and place your daily sales.json files in it.
- If you run the project from the developer powershell in Visual Studio, you may need to run the command `dotnet restore` to install the dependencies before running the project.
- If you run the project from the developer powershell in Visual Studio, sometimes it will and sometimes it will not find the stores folder that is located with the code. 
	- Make sure the stores folder is in the same directory as the project exe file for consistent operation.

## Publishing the Project
- to publish the project run:
	- dotnet publish -c Release -r <RID> --self-contained true /p:PublishSingleFile=true -o ./publish
- Replace <RID> with the Runtime Identifier for your target platform:
	- win-x64 for Windows 64-bit
	- linux-x64 for Linux 64-bit
	- osx-x64 for macOS 64-bit
- Example for Windows:
	- dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true -o ./publish
- This will create a self-contained executable in the publish folder that can be run on the target platform without needing to install .NET separately.

