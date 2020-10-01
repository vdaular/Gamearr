using System.Collections.Generic;
using NzbDrone.Core.MediaFiles;
using Gamearr.Http;
using Gamearr.Http.REST;

namespace Gamearr.Api.V1.Tracks
{
    public class RenameTrackModule : GamearrRestModule<RenameTrackResource>
    {
        private readonly IRenameTrackFileService _renameTrackFileService;

        public RenameTrackModule(IRenameTrackFileService renameTrackFileService)
            : base("rename")
        {
            _renameTrackFileService = renameTrackFileService;

            GetResourceAll = GetTracks;
        }

        private List<RenameTrackResource> GetTracks()
        {
            int artistId;

            if (Request.Query.ArtistId.HasValue)
            {
                artistId = (int)Request.Query.ArtistId;
            }

            else
            {
                throw new BadRequestException("artistId is missing");
            }

            if (Request.Query.albumId.HasValue)
            {
                var albumId = (int)Request.Query.albumId;
                return _renameTrackFileService.GetRenamePreviews(artistId, albumId).ToResource();
            }

            return _renameTrackFileService.GetRenamePreviews(artistId).ToResource();
        }
    }
}
