namespace ConfigCreator
{
    [Serializable]
    class NullListItemException : Exception
    {
        public NullListItemException()
            : base(String.Format("You have not added items to the config file")) { }
    }
    [Serializable]
    class ConfigFileNotFoundException : Exception
    {
        public ConfigFileNotFoundException()
            : base(String.Format("Config file don't found. Create it and try again")) { }
    }
    [Serializable]
    class ItemDontFoundException : Exception
    {
        public ItemDontFoundException()
            : base(String.Format("The item could not be found in the config. Are you sure you added it?")) { }
    }
    /// <summary>
    /// The main class for creating configs
    /// </summary>
    public class Config
    {
        static List<string> configItems { get; set; } = new();
        static string globalConfigPath { get; set; }
        /// <summary>
        /// Creates a config file
        /// </summary>
        /// <param name="configFileName">Config name</param>
        /// <param name="configPath">Custom path to the config. leave null if you want the config to be saved in the folder with the exe file</param>
        /// <exception cref="NullListItemException"></exception>
        public static void CreateConfigFile(string configFileName, string configPath)
        {
            string pathToConfig;
            if (configPath == null)
                pathToConfig = $"{configFileName}.ini";
            else
                pathToConfig = $"{configPath}\\{configFileName}.ini";

            if (File.Exists(pathToConfig))
                return;
            if (!File.Exists(pathToConfig))
                File.Create(pathToConfig).Close();
            if (configItems.Count == 0)
                throw new NullListItemException();

            StreamWriter sw = new(pathToConfig);
            foreach (var item in configItems)
                sw.Write($"{item}");
            sw.Close();
        }
        /// <summary>
        /// Adds an item to the config
        /// </summary>
        /// <param name="configItem">The config item you want to add</param>
        /// <param name="itemValue">The value in the config</param>
        /// <param name="configItemComment">leave null if you don't want to comment on the item in the config. ex:[ConfigItem] # Comment here</param>
        public static void Add(string configItem, string itemValue, string configItemComment)
        {
            if (configItemComment == null)
                configItems.Add($"[{configItem}]\n{itemValue}\n");
            else
                configItems.Add($"[{configItem}] # {configItemComment}\n{itemValue}\n");

        }
        /// <summary>
        /// This method gets the item you selected from the config
        /// </summary>
        /// <param name="configItem">The config item you want to find</param>
        /// <returns>Iten string</returns>
        /// <exception cref="ConfigFileNotFound"></exception>
        public static string GetItem(string configItem)
        {
            string pathToConfig;


            string item = null;
            int lineNumber = -1;
            if (globalConfigPath == null)
                throw new ConfigFileNotFoundException();
            string[] configLines = File.ReadAllLines(globalConfigPath);
            foreach (var line in configLines)
            {
                lineNumber++;
                if (!line.Contains(configItem))
                    continue;
                item = File.ReadLines(globalConfigPath).Skip(lineNumber + 1).First();
            }
            return item;
        }
        /// <summary>
        /// Getting config path
        /// </summary>
        /// <returns>config path</returns>
        public static string getConfigPath() => globalConfigPath;
        /// <summary>
        /// Removing Config File
        /// </summary>
        /// <param name="configFileName">The name of the config file you created</param>
        /// <param name="configPath">Leave null if you did not specify a custom path when creating the config using the CreateConfigFile method</param>
        public static void Initialize(string configFileName, string configPath)
        {
            string pathToConfig;
            if (configPath == null)
                pathToConfig = $"{configFileName}.ini";
            else
                pathToConfig = $"{configPath}\\{configFileName}.ini";
            if (!File.Exists(pathToConfig))
                throw new ConfigFileNotFoundException();

            globalConfigPath = pathToConfig;
        }
    }

}
