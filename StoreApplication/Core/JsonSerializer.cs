using Newtonsoft.Json;
using System.IO;
using Windows.Storage;

namespace StoreApplication.Core
{
    public class JsonSerializer<T>
    {
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

        public void SaveData(List<T> data, string fileName)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting).GetResults();
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(file.Path, json);
        }
    }
}