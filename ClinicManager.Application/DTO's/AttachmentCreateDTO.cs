namespace ClinicManagerAPI.DTO_s
{
    public class AttachmentCreateDTO
    {
        public AttachmentCreateDTO(string type, string fileName, byte[] fileData)
        {
            Type = type;
            FileName = fileName;
            FileData = fileData;
        }

        public required string Type { get; set; }
        public required string FileName { get; set; }
        public required byte[] FileData { get; set; }
    }
}
