namespace BackendTest.DAL.Models
{
    public class Image
    {
        public string FilePath { get; private set; }

        public Image(string filePath)
        {
            FilePath = filePath;
        }

        public override string ToString()
        {
            return $"Image: {FilePath}";
        }
    }
}
