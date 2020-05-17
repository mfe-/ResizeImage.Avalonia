using Get.the.solution.Image.Contract;
using Get.the.solution.Image.Manipulation.ServiceBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ResizeImage.Service
{
    public class LocalSettingsService : LocalSettingsBaseService, IDictionary<string, object>
    {
        public LocalSettingsService(ILoggerService loggerService) : base(loggerService)
        {
            AppSettings = new Dictionary<string, object>();
            ReadConfigFile();
            EnabledImageViewer = Values?[nameof(EnabledImageViewer)] == null ? false : Boolean.Parse(Values[nameof(EnabledImageViewer)].ToString());
            EnabledOpenSingleFileAfterResize = Values?[nameof(EnabledOpenSingleFileAfterResize)] == null ? true : Boolean.Parse(Values[nameof(EnabledOpenSingleFileAfterResize)].ToString());
            EnableAddImageToGallery = Values?[nameof(EnableAddImageToGallery)] == null ? true : Boolean.Parse(Values[nameof(EnableAddImageToGallery)].ToString());
            ShowSuccessMessage = Values?[nameof(ShowSuccessMessage)] == null ? true : Boolean.Parse(Values[nameof(ShowSuccessMessage)].ToString());
        }
        public FileInfo ConfigFile { get; set; }
        public void ReadConfigFile()
        {
            string executingApp = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            executingApp = executingApp.Replace("file:///", String.Empty);
            ConfigFile = new FileInfo($"{executingApp}.ini");
            if (ConfigFile.Exists)
            {
                string line;
                using (StreamReader fileStream = new StreamReader(ConfigFile.FullName))
                {
                    while ((line = fileStream.ReadLine()) != null)
                    {
                        var keyValue = line.Split(":");
                        string key = keyValue.FirstOrDefault();
                        string value = keyValue.LastOrDefault();
                        bool b;
                        int i;
                        if (Boolean.TryParse(value, out b))
                        {
                            AppSettings.Add(key, b);
                        }
                        else if (int.TryParse(value, out i))
                        {
                            AppSettings.Add(key, i);
                        }
                        else
                        {
                            AppSettings.Add(key, value);
                        }
                    }
                }
            }
            else
            {
                using (FileStream fileStream = new FileStream(ConfigFile.FullName,
                    FileMode.CreateNew, FileAccess.Write)) ;
            }
        }
        public void WriteConfig(string key, string settingsValue)
        {
            String content;
            using (StreamReader fileStream = new StreamReader(ConfigFile.FullName))
            {
                content = fileStream.ReadToEnd();
            }
            String newConfigKeyValue = $"{Environment.NewLine}{key}:{settingsValue}";
            if (!content.Contains(key))
            {
                StringBuilder stringBuilder = new StringBuilder(content);
                stringBuilder.Append(newConfigKeyValue);
                content = stringBuilder.ToString();
            }
            else
            {
                string tobeReplaced = String.Empty;
                foreach (var line in content.Split(Environment.NewLine))
                {
                    if (line.StartsWith(key))
                    {
                        tobeReplaced = $"{Environment.NewLine}{line}";
                        break;
                    }
                }
                content = content.Replace(tobeReplaced, newConfigKeyValue);
            }
            using (StreamWriter fileStream = new StreamWriter(ConfigFile.FullName))
            {
                fileStream.Write(content);
                fileStream.Flush();
            }

        }

        protected IDictionary<string, object> AppSettings;

        public object this[string key]
        {
            get
            {
                if (!AppSettings.ContainsKey(key))
                {
                    return null;
                }
                else
                {
                    object result = null;
                    AppSettings.TryGetValue(key, out result);
                    return result;
                }

            }
            set
            {
                String settingsValue = $"{value}";
                AppSettings[key] = value;

                WriteConfig(key, settingsValue);

            }
        }

        public override IDictionary<string, object> Values => this;

        #region IDictionary<string, object>
        public ICollection<string> Keys => throw new System.NotImplementedException();

        ICollection<object> IDictionary<string, object>.Values => throw new System.NotImplementedException();

        public int Count => throw new System.NotImplementedException();

        public bool IsReadOnly => throw new System.NotImplementedException();

        public void Add(string key, object value)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(string key, out object value)
        {
            throw new System.NotImplementedException();
        }

        public void Add(KeyValuePair<string, object> item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
