using System.Collections.Generic;
using Gamearr.Api.V1.Albums;

namespace Gamearr.Api.V1.AlbumStudio
{
    public class AlbumStudioArtistResource
    {
        public int Id { get; set; }
        public bool? Monitored { get; set; }
        public List<AlbumResource> Albums { get; set; }
    }
}
