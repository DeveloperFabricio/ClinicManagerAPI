namespace ClinicManagerAPI.DTO_s
{
    public class AttachmentCreateDTO
    {
        public required string Type { get; set; }
        public required string FileName { get; set; }
        public required byte[] FileData { get; set; }
    }
}
