namespace VK.Audios
{
    public class Album
    {
        public long Id { get; set; }

        public long OwnerId { get; set; }

        public string Title { get; set; }

        public OwnerType OwnerType { get; set; }
    }
}
