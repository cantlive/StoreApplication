namespace StoreApplication.LoadData
{
    public class ProductLoader
    {
        private JsonSerializer<Product> _jsonService = new();

        public List<Product> GetProducts(string fileName)
        {
            return _jsonService.LoadData(fileName);
        }

        public void SaveProducts(List<Product> products, string fileName)
        {
            _jsonService.SaveData(products, fileName);
        }
    }
}
