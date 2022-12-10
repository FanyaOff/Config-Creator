# Config-Creator
Простая библиотека для создания конфига

Есть две версии конфига:

* [ConfigCreator](https://www.nuget.org/packages/ConfigCreator) (>NET 6.0)
* [ConfigCreator.Framework](https://www.nuget.org/packages/ConfigCreator.Framework) (>NET.Framework 4.7.2)

# Установка
```
NuGet\Install-Package ConfigCreator -Version 1.0.0
```
или
```
NuGet\Install-Package ConfigCreator.Framework -Version 1.0.0
```

# Документация
**Методы:**

* **Config.CreateConfigFile(string configFileName, string configPath)**

Этот метод создает файл с добавленными вами элементами. Используйте только после добавления элементов методом Config.Add()

_configFileName_ - Имя конфигурации

_configPath_ - путь к папке, в которой будет находиться конфигурация. Оставьте значение null, если вы хотите, чтобы оно было сохранено в той же папке, что и exe-файл

**Пример:**
```csharp
using ConfigCreator;

Config.Add("ApiKey", null, null); // Добавляем элементы в конфиг
Config.Add("File", "default", null);
Config.Add("Language", "RU", "Languages: EN, RU, UA");
Config.CreateConfigFile("appsettings", null); // Создаёи конфиг файл с этими элементами
```

* **Config.Add(string configItem, string itemValue, string configItemComment)**

Этот метод позволяет вам добавить элемент в свой конфигурационный файл, дать ему комментарий и значение по умолчанию

_configItem_ - имя элемента в конфигурации, _пример: [ConfigItem]_

_itemValue_ - стандартное значение для элемента в файле конфигурации

_configItemComment_ - комментарий к элементу в файле конфигурации

**Пример:**
```csharp
using ConfigCreator;

Config.Add("ApiKey", null, null); // Добавляем элементы в конфиг
Config.Add("File", "default", null);
Config.Add("Language", "RU", "Languages: EN, RU, UA");
Config.CreateConfigFile("appsettings", null); // Создаёи конфиг файл с этими элементами
```
**Содержимоe выходного конфиг-файла:**

![image](https://user-images.githubusercontent.com/73064979/206867732-bed65030-4a6a-4c86-b3f1-a21e1b5a8a4e.png)

* **Config.Initialize(string configFileName, string configPath)**

Этот метод инициализирует конфигурацию в памяти. Рекомендуется выполнять его каждый раз, когда вы запускаете программу, чтобы ваше приложение не выдавало исключение при использовании Config.getConfigPath() или Config.GetItem()

_configFileName_ - Имя конфигурации

_configPath_ - путь к папке, в которой находится конфигурация. Путь к папке, в которой находится конфигурация. Если файл конфигурации находится в той же папке, что и exe-файл вашей программы, то оставьте 

**Пример:**
```csharp
using ConfigCreator;

Config.Initialize("appsettings", null); // Инициализируем конфиг в память
Console.WriteLine($"ApiKey: {Config.GetItem("ApiKey")}"); // выводим значения из конфига
```

* **Config.GetItem(string configItem)**

Этот метод поможет вам получить значение из конфигурационного файла. _ возвращает значение null, если значение не было найдено_

_configItem_ - элемент в конфигурации

**Пример:**
```csharp
using ConfigCreator;

Config.Initialize("appsettings", null); // Инициализируем конфиг в память
Console.WriteLine($"ApiKey: {Config.GetItem("ApiKey")}"); // выводим значения из конфига
```

* **Config.getConfigPath()**

Возвращает путь к конфигурации после ее инициализации

# Пример программы
```csharp
using ConfigCreator;

Config.Add("ApiKey", null, null); // Добавляем файлы в конфиг
Config.Add("File", "default", null);
Config.Add("Language", "RU", "Languages: EN, RU, UA");
Config.CreateConfigFile("appsettings", null); // Создаём конфиг
Config.Initialize("appsettings", null); // Инициализируем его в память
Console.WriteLine($"Config path detected: {Config.getConfigPath()}");
if (Config.GetItem("ApiKey") == null)
{
    Console.WriteLine("ApiKey not found. Check if you have filled it out in the config");
    Console.ReadKey();
    return;
}
Console.WriteLine($"ApiKey: {Config.GetItem("ApiKey")}"); // Выводим информацию
Console.WriteLine($"File: {Config.GetItem("File")}");
Console.WriteLine($"Language: {Config.GetItem("Language")}");
Console.ReadLine();
```
Итоговый вывод:

![image](https://user-images.githubusercontent.com/73064979/206868807-b8e3c3d8-2d83-4536-9f35-1d2d73bf1dc5.png)
