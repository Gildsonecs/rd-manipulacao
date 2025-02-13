namespace RdManipulation.Domain.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Channel { get; set; } 
        public string? Duration { get; set; }
        public DateTime PublishedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
