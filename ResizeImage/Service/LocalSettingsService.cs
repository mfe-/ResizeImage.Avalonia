using Get.the.solution.Image.Contract;
using Get.the.solution.Image.Manipulation.ServiceBase;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ResizeImage.Service
{
    public class LocalSettingsService : LocalSettingsBaseService, IDictionary<string, object>
    {
        public LocalSettingsService(ILoggerService loggerService) : base(loggerService)
        {
            AppSettings = new Dictionary<string, object>();
            EnabledImageViewer = Values?[nameof(EnabledImageViewer)] == null ? false : Boolean.Parse(Values[nameof(EnabledImageViewer)].ToString());
            EnabledOpenSingleFileAfterResize = Values?[nameof(EnabledOpenSingleFileAfterResize)] == null ? true : Boolean.Parse(Values[nameof(EnabledOpenSingleFileAfterResize)].ToString());
            EnableAddImageToGallery = Values?[nameof(EnableAddImageToGallery)] == null ? true : Boolean.Parse(Values[nameof(EnableAddImageToGallery)].ToString());
            ShowSuccessMessage = Values?[nameof(ShowSuccessMessage)] == null ? true : Boolean.Parse(Values[nameof(ShowSuccessMessage)].ToString());
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
                AppSettings.TryAdd(key, settingsValue);
            }
        }
        public IDictionary<string, object> _Values;
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
