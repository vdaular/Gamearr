import _ from 'lodash';
import { createSelector } from 'reselect';

function createAlbumSelector() {
  return createSelector(
    (state, { albumId }) => albumId,
    (state, { albumEntity = albumEntities.ALBUMS }) => _.get(state, albumEntity, { items: [] }),
    (albumId, albums) => {
      return _.find(albums.items, { id: albumId });
    }
  );
}

export default createAlbumSelector;
