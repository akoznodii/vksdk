using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using VK.Collections;
using VK.Xml;

namespace VK.Audios
{
    public class AudiosMethods
    {
        private readonly VkClient _vkClient;

        public AudiosMethods(VkClient vkClient)
        {
            _vkClient = vkClient;
        }

        public VkCollection<Audio> GetAudio(long ownerId = 0, long albumId = 0, OwnerType ownerType = OwnerType.User, ICollection<long> ids = null, int count = 0, int offset = 0)
        {
            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioGet);

            if (ownerId != 0)
            {
                requestBuilder.PutParameter(VkConstants.OwnerId, ownerId.ToOwnerId(ownerType));
            }

            if (albumId > 0)
            {
                requestBuilder.PutParameter(VkConstants.AlbumId, albumId);
            }

            if (ids != null && !ids.Any())
            {
                requestBuilder.PutParameter(VkConstants.AudioIds, ids);
            }

            if (count > 0)
            {
                requestBuilder.PutParameter(VkConstants.Count, count);
            }

            if (offset > 0)
            {
                requestBuilder.PutParameter(VkConstants.Offset, offset);
            }

            var document = _vkClient.ExecuteRequest(requestBuilder);

            var responseCount = document.Root.GetInt32(VkConstants.Count);

            var audios = document.Root
                                 .GetDescendants(VkConstants.AudioType)
                                 .Select(GetAudio)
                                 .ToVkCollection();

            audios.Offset = offset;
            audios.ResponseCount = responseCount;

            return audios;
        }

        public int GetCount(long ownerId, OwnerType ownerType)
        {
            if (ownerId == 0)
            {
                throw new ArgumentException(VkLocalization.InvalidInputParameters, "ownerId");
            }

            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioGetCount)
                                          .PutParameter(VkConstants.OwnerId, ownerId.ToOwnerId(ownerType));

            var document = _vkClient.ExecuteRequest(requestBuilder);

            return document.Root.GetInt32();
        }

        public VkCollection<Audio> GetRecommendations(long audioId, long ownerId, OwnerType ownerType, int count = 0, int offset = 0, bool shuffle = false)
        {
            return GetRecommendations(string.Join("_", ownerId.ToOwnerId(ownerType), audioId), 0, count, offset, shuffle);
        }

        public VkCollection<Audio> GetRecommendations(long userId, int count = 0, int offset = 0, bool shuffle = false)
        {
            return GetRecommendations(null, userId, count, offset, shuffle);
        }

        public VkCollection<Audio> GetRecommendations(string targetAudio = null, long userId = 0, int count = 0, int offset = 0, bool shuffle = false)
        {
            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioGetRecommendations);

            if (!string.IsNullOrEmpty(targetAudio))
            {
                requestBuilder.PutParameter(VkConstants.TargetAudio, targetAudio);
            }

            if (userId > 0)
            {
                requestBuilder.PutParameter(VkConstants.UserId, userId);
            }

            if (count > 0)
            {
                requestBuilder.PutParameter(VkConstants.Count, count);
            }

            if (offset > 0)
            {
                requestBuilder.PutParameter(VkConstants.Offset, offset);
            }

            requestBuilder.PutParameter(VkConstants.Shuffle, shuffle);

            var document = _vkClient.ExecuteRequest(requestBuilder);

            var responseCount = document.Root.GetInt32(VkConstants.Count);

            var collection = document.Root
                                     .GetDescendants(VkConstants.AudioType)
                                     .Select(GetAudio)
                                     .ToVkCollection();

            collection.ResponseCount = responseCount;
            collection.Offset = offset;

            return collection;
        }

        public VkCollection<Audio> GetPopular(int genreId = Genre.None, int count = 0, int offset = 0, bool onlyForeign = false)
        {
            var reqeustBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioGetPopular);

            if (genreId != Genre.None)
            {
                reqeustBuilder.PutParameter(VkConstants.GenreId, genreId);
            }

            if (count > 0)
            {
                reqeustBuilder.PutParameter(VkConstants.Count, count);
            }

            if (offset > 0)
            {
                reqeustBuilder.PutParameter(VkConstants.Offset, offset);
            }

            reqeustBuilder.PutParameter(VkConstants.OnlyEnglish, onlyForeign);

            var document = _vkClient.ExecuteRequest(reqeustBuilder);

            var responseCount = document.Root.FindInt32(VkConstants.Count);

            var audios = document.Root
                           .GetDescendants(VkConstants.AudioType)
                           .Select(GetAudio)
                           .ToVkCollection();

            audios.Offset = offset;

            //HACK: In this version getPopular method doesn't return items count
            audios.ResponseCount = audios.Count > 0 && responseCount == 0 ? 400 : responseCount;

            return audios;
        }

        public VkCollection<Audio> Search(string query, bool autoComplete = false, bool lyrics = false, bool performerOnly = false, int sort = SortType.Popularity, bool searchOwn = false, int count = 0, int offset = 0)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException("query");
            }

            var reqeustBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioSearch);

            reqeustBuilder.PutParameter(VkConstants.Query, Uri.EscapeUriString(query))
                          .PutParameter(VkConstants.AutoComplete, autoComplete)
                          .PutParameter(VkConstants.LyricsType, lyrics)
                          .PutParameter(VkConstants.PerformerOnly, performerOnly)
                          .PutParameter(VkConstants.Sort, sort)
                          .PutParameter(VkConstants.SearchOwn, searchOwn);

            if (count > 0)
            {
                reqeustBuilder.PutParameter(VkConstants.Count, count);
            }

            if (offset > 0)
            {
                reqeustBuilder.PutParameter(VkConstants.Offset, offset);
            }

            var document = _vkClient.ExecuteRequest(reqeustBuilder);

            var responseCount = document.Root.FindInt32(VkConstants.Count);

            var audios = document.Root
                           .GetDescendants(VkConstants.AudioType)
                           .Select(GetAudio)
                           .ToVkCollection();

            audios.Offset = offset;

            audios.ResponseCount = responseCount;

            return audios;
        }

        public VkCollection<Album> GetAlbums(long ownerId = 0, OwnerType ownerType = OwnerType.User, int count = 0, int offset = 0)
        {
            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioGetAlbums);

            if (ownerId != 0)
            {
                requestBuilder.PutParameter(VkConstants.OwnerId, ownerId.ToOwnerId(ownerType));
            }

            if (count > 0)
            {
                requestBuilder.PutParameter(VkConstants.Count, count);
            }

            if (offset > 0)
            {
                requestBuilder.PutParameter(VkConstants.Offset, offset);
            }

            var document = _vkClient.ExecuteRequest(requestBuilder);

            var responseCount = document.Root.GetInt32(VkConstants.Count);

            var albums = document.Root
                                 .GetDescendants(VkConstants.AlbumType)
                                 .Select(GetAlbum)
                                 .ToVkCollection();

            albums.Offset = offset;
            albums.ResponseCount = responseCount;

            return albums;
        }

        public Lyrics GetLyrics(long lyricsId)
        {
            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioGetLyrics).PutParameter(VkConstants.LyricsId, lyricsId);

            var root = _vkClient.ExecuteRequest(requestBuilder).Root;

            return GetLyrics(root);
        }

        public long Add(long audioId, long ownerId, OwnerType ownerType, long groupId = 0)
        {
            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioAdd)
                                        .PutParameter(VkConstants.AudioId, audioId)
                                        .PutParameter(VkConstants.OwnerId, ownerId.ToOwnerId(ownerType));

            if (groupId != 0)
            {
                requestBuilder.PutParameter(VkConstants.GroupId, groupId);
            }

            var document = _vkClient.ExecuteRequest(requestBuilder);

            return document.Root.GetInt64();
        }

        public bool Remove(long audioId, long ownerId, OwnerType ownerType)
        {
            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioDelete)
                                        .PutParameter(VkConstants.AudioId, audioId)
                                        .PutParameter(VkConstants.OwnerId, ownerId.ToOwnerId(ownerType));

            var document = _vkClient.ExecuteRequest(requestBuilder);

            return document.Root.GetBoolean();
        }

        public bool MoveToAlbum(long audioId, long albumId, long groupId = 0)
        {
            return MoveToAlbum(Enumerable.Repeat(audioId, 1), albumId, groupId);
        }

        public bool MoveToAlbum(IEnumerable<long> audioIds, long albumId, long groupId = 0)
        {
            if (audioIds == null)
            {
                throw new ArgumentNullException("audioIds");
            }

            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioMoveToAlbum)
                                        .PutParameter(VkConstants.AlbumId, albumId)
                                        .PutParameter(VkConstants.AudioIds, audioIds);

            if (groupId > 0)
            {
                requestBuilder.PutParameter(VkConstants.GroupId, groupId);
            }

            var document = _vkClient.ExecuteRequest(requestBuilder);

            return document.Root.GetBoolean();
        }

        public long SetBroadcast(long audioId, long ownerId, OwnerType ownerType)
        {
            var result = SetBroadcast(audioId, ownerId, ownerType, null);

            return result.First().Item1;
        }

        public ICollection<Tuple<long, OwnerType>> SetBroadcast(long audioId, long ownerId, OwnerType ownerType, ICollection<Tuple<long, OwnerType>> targets)
        {
            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.AudioSetBroadcast);

            if (audioId != 0)
            {
                requestBuilder.PutParameter(VkConstants.AudioType, string.Format(CultureInfo.InvariantCulture, "{0}_{1}", ownerId.ToOwnerId(ownerType), audioId));
            }

            if (targets != null && targets.Any())
            {
                requestBuilder.PutParameter(VkConstants.TargetIds, string.Join(",", targets.Select(t => t.Item1.ToOwnerId(t.Item2))));
            }

            var document = _vkClient.ExecuteRequest(requestBuilder);

            return document.Root.Descendants().Select(GetIds).ToArray();
        }

        private static Audio GetAudio(XElement element)
        {
            var ownerId = element.GetInt64(VkConstants.OwnerId);
            var ownerType = ownerId.GetOwnerType();

            var audio = new Audio()
            {
                Id = element.GetInt64(VkConstants.Id),
                Artist = element.GetString(VkConstants.Artist),
                Title = element.GetString(VkConstants.Title),
                Duration = element.GetDouble(VkConstants.Duration),
                Url = element.GetString(VkConstants.Url),
                AlbumId = element.FindInt64(VkConstants.AlbumId),
                LyricsId = element.FindInt64(VkConstants.LyricsId),
                GenreId = element.FindInt32(VkConstants.GenreType),
                OwnerId = ownerId > 0 ? ownerId : -1 * ownerId,
                OwnerType = ownerType,
            };

            return audio;
        }

        private static Album GetAlbum(XElement element)
        {
            var ownerId = element.GetInt64(VkConstants.OwnerId);
            var ownerType = ownerId.GetOwnerType();

            var album = new Album()
            {
                Id = element.GetInt64(VkConstants.Id),
                Title = element.GetString(VkConstants.Title),
                OwnerId = ownerId > 0 ? ownerId : -1 * ownerId,
                OwnerType = ownerType,
            };

            return album;
        }

        private static Lyrics GetLyrics(XElement element)
        {
            return new Lyrics
            {
                Id = element.GetInt64(VkConstants.LyricsId),
                Text = element.GetString(VkConstants.LyricsText)
            };
        }

        private static Tuple<long, OwnerType> GetIds(XElement element)
        {
            var id = element.GetInt64();
            var ownerType = OwnerType.User;

            if (id < 0)
            {
                id *= -1;
                ownerType = OwnerType.Group;
            }

            return new Tuple<long, OwnerType>(id, ownerType);
        }
    }
}
