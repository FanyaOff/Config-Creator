# Config-Creator
A simple library for creating config files

There are two versions of this library:

* ConfigCreator (>NET 6.0)
* ConfigCreator.Framework (>NET.Framework 4.7.2)

# Documentation
**Methods:**

* **Config.CreateConfigFile(string configFileName, string configPath)**

This method creates a file with the items you added. Use only after the Config.Add method

_configFileName_ - Config name

_configPath_ - The path to the folder where the config will be located. Leave null if you want it to be saved in the same folder as the exe file

**Example:**
```csharp
using ConfigCreator;

Config.Add("ApiKey", null, null); // Adding an item to the config
Config.Add("File", "default", null);
Config.Add("Language", "RU", "Languages: EN, RU, UA");
Config.CreateConfigFile("appsettings", null); // Creating a config file
```

* **Config.Add(string configItem, string itemValue, string configItemComment)**

This method allows you to add an item to your config file, give it a comment and a default value

_configItem_ - The name of the item in the config, _example: [ConfigItem]_

_itemValue_ - The standard value for the item in the config file

_configItemComment_ - Comment on the item in the config file

**Example:**
```csharp
using ConfigCreator;

Config.Add("ApiKey", null, null); // Adding an item to the config
Config.Add("File", "default", null);
Config.Add("Language", "RU", "Languages: EN, RU, UA");
Config.CreateConfigFile("appsettings", null); // Creating a config file
```
**The contents of this config file:**

![image](https://user-images.githubusercontent.com/73064979/206867732-bed65030-4a6a-4c86-b3f1-a21e1b5a8a4e.png)

* **Config.Initialize(string configFileName, string configPath)**

This method initializes the configuration to memory. It is recommended to run it every time you start the program so that your application does not throw an exception

_configFileName_ - Config name

_configPath_ - The path to the folder where the configuration is located. The path to the folder where the configuration is located. If the configuration file is in the same folder as the exe file of your program, then leave _null_

```csharp
using ConfigCreator;

Config.Initialize("appsettings", null); // initializing config into memory
Console.WriteLine($"ApiKey: {Config.GetItem("ApiKey")}"); // display config value
```

* **Config.GetItem(string configItem)**

This method will help you get the value from the config file. _returns null if no value was found_

_configItem_ - Item in the config

**Example:**
```csharp
using ConfigCreator;

Config.Initialize("appsettings", null); // initializing config into memory
Console.WriteLine($"ApiKey: {Config.GetItem("ApiKey")}"); // display config value
```

* **Config.getConfigPath()**

Returns the path to the config after its initialization

# Program example
```csharp
using ConfigCreator;

Config.Add("ApiKey", null, null); // Adding items into config file
Config.Add("File", "default", null);
Config.Add("Language", "RU", "Languages: EN, RU, UA");
Config.CreateConfigFile("appsettings", null); // Creating config file
Config.Initialize("appsettings", null); // initializing config file into memory
Console.WriteLine($"Config path detected: {Config.getConfigPath()}");
if (Config.GetItem("ApiKey") == null)
{
    Console.WriteLine("ApiKey not found. Check if you have filled it out in the config");
    Console.ReadKey();
    return;
}
Console.WriteLine($"ApiKey: {Config.GetItem("ApiKey")}"); // displaying information
Console.WriteLine($"File: {Config.GetItem("File")}");
Console.WriteLine($"Language: {Config.GetItem("Language")}");
Console.ReadLine();
```
Output:

![image](https://user-images.githubusercontent.com/73064979/206868807-b8e3c3d8-2d83-4536-9f35-1d2d73bf1dc5.png)
