using Newtonsoft.Json;
using System.IO;
using Windows.Storage;

namespace StoreApplication.Core
{
    /// <summary>
    /// Provides methods to serialize and deserialize generic data objects to and from JSON format.
    /// </summary>
    /// <typeparam name="T">Data</typeparam>
    public class JsonSerializer<T>
    {
        /// <summary>
        /// Load deserialized List of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <exception cref="FileNotFoundException"/>
        /// <exception cref="AggregateException"/>
        /// <returns>Deserialized List of <typeparamref name="T"/>.</returns>
        public List<T> LoadData(string fileName)
        {
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile file = localFolder.GetFileAsync(fileName).GetResults();
                string json = File.ReadAllText(file.Path);
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (FileNotFoundException)
            {
                return [];
            }
            catch (AggregateException)
            {
                return [];
            }
        }

        /// <summary>
        /// Save serialized List of <typeparamref name="T"/> in <paramref name="fileName"/>.
        /// </summary>
        /// <param name="data">List of <typeparamref name="T"/></param>
        /// <param name="fileName">File name</param>
        public void SaveData(List<T> data, string fileName)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting).GetResults();
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(file.Path, json);
        }
    }
}