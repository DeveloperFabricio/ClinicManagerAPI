namespace ClinicManagerAPI.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public required string Type { get; set; } 
        public required string FileName { get; set; }
        public required byte[] FileData { get; set; }
    }
}
