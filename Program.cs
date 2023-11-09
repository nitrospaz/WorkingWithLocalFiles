using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesFiles = FindFiles(storesDirectory);
var salesTotal = CalculateSalesTotal(salesFiles);

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
bool doesDirectoryExist = Directory.Exists(salesTotalDir);

if (!doesDirectoryExist){
    try{
        Console.WriteLine("Creating salesTotalDir directory");
        Directory.CreateDirectory(salesTotalDir);
        Console.WriteLine($"Writing to salesTotalDir{Path.DirectorySeparatorChar}totals.txt");
        File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");
    }catch(Exception ex){
        Console.WriteLine($"Failed to create directory or file: {ex.Message}");
    }

}else{
    try{
        Console.WriteLine("SalesTotalDir directory already exists");
        Console.WriteLine($"Writing to salesTotalDir{Path.DirectorySeparatorChar}totals.txt");
        File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");
    }
    catch(Exception ex){
        Console.WriteLine($"Failed to add to directory or file: {ex.Message}");
    }
}


IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);

        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}

record SalesData (double Total);


// Directory.EnumerateDirectories and Directory.EnumerateFiles accept a parameter that allows you to specify a search condition for names to return, and a parameter to recursively traverse all child directories.
// System.Environment.SpecialFolder is an enumeration that lets you access system-defined folders, such as the desktop or user profile, in a cross-platform manner without having to memorize the exact path for each operating system.
// If you need to parse other file types, check out the packages on nuget.org. For example, you can use the CsvHelper package for .csv files.


// // Path builds and parses strings
// Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
// Console.WriteLine(Path.Combine("stores","201"));
// // returns:
// // stores\201 on Windows
// //
// // stores/201 on macOS

// Console.WriteLine(Path.GetExtension("sales.json")); // outputs: .json


// string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
// FileInfo info = new FileInfo(fileName);
// Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more


// Console.WriteLine(Directory.GetCurrentDirectory());

// string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
// Console.WriteLine(docPath);

// Console.WriteLine($"Number of files found: {salesFiles.Count()}");
