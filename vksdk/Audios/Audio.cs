using System;

namespace VK.Audios
{
    public class Audio
    {
        public long Id { get; set; }

        public long OwnerId { get; set; }

        public long LyricsId { get; set; }

        public long AlbumId { get; set; }

        public string Artist { get; set; }

        public string Title { get; set; }

        public double Duration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "As design")]
        public string Url { get; set; }

        public int GenreId { get; set; }

        public OwnerType OwnerType { get; set; }
    }
}
