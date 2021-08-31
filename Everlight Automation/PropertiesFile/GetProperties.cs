using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Everlight_Automation.PropertiesFile
{
    public class GetProperties
    {
        protected static Dictionary<String, String> _configProperties;
        
        protected void LoadPropertiesFromFile()
        {
            string[] configFiles = Directory.GetFiles(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "/Configuration/");

            foreach (var configProp in configFiles)
            {
                try
                {
                    if (configProp.Contains("config"))
                    {
                        _configProperties = new Dictionary<string, string>();
                        var envProperties = File.ReadAllLines(Path.GetDirectoryName(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "/Configuration/") + "/config" + ".properties");
                        foreach (var prop in envProperties)
                        {
                            var keyValue = prop.Split(new[] { '=' }, 2);
                            if (_configProperties.ContainsKey(keyValue[0]))
                            {
                                throw new Exception("an item with the same key already exists in the dictionary : " + keyValue);
                            }
                            else
                                _configProperties.Add(keyValue[0].Trim(), keyValue[1].Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Arguments exception found and ignored : " + ex.Message);

                    continue;
                }
            }
        }
    }
}
