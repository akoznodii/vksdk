using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK
{
    public static class VkConstants
    {
        #region User properties

        public const string UserType = "user";
        public const string UserIds = "user_ids";
        public const string UserId = "user_id";
        public const string FirstName = "first_name";
        public const string LastName = "last_name";
        public const string Online = "online";

        public const string Nickname = "nick_name";
        public const string Sex = "sex";
        public const string Birthdate = "bdate";
        public const string City = "city";
        public const string Country = "country";
        public const string TimeZone = "timezone";
        public const string Relation = "relation";
        public const string LastSeen = "last_seen";
        public const string CanWritePrivateMessage = "can_write_private_message";
        public const string CanSeeAllPosts = "can_see_all_posts";
        public const string CanPost = "can_post";

        public const string Domain = "domain";
        public const string HasMobile = "has_mobile";
        public const string Mobile = "mobile";
        public const string Rate = "rate";
        public const string Contacts = "contacts";
        public const string Education = "education";
        public const string Universities = "universities";
        public const string FacultyName = "faculty_name";
        public const string Graduation = "graduation";

        public const string UniversityName = "photo";
        public const string Faculty = "online";

        public const string Nominative = "nom";
        public const string Genitive = "gen";
        public const string Dative = "dat";
        public const string Accusative = "acc";
        public const string Instrumental = "ins";
        public const string Prepositional = "abl";

        public const string Hints = "hints";

        public const string FriendsGet = "friends.get";
        public const string FriendsGetAppUsers = "friends.getAppUsers";
        public const string FriendsGetOnline = "friends.getOnline";
        public const string FriendsGetMutual = "friends.getMutual";
        public const string FriendsAreFriends = "friends.areFriends";

        public const string IsAppUser = "isAppUser";
        public const string UsersGet = "users.get";
        public const string UsersSearch = "users.search";
        public const string GetUserSettings = "getUserSettings";
        public const string LikesGetList = "likes.getList";

        public const string NameCase = "name_case";
        public const string Fields = "fields";
        public const string Order = "order";
        public const string TargetUid = "target_uid";
        public const string SourceUid = "source_uid";
        public const string Status = "status";
        public const string FriendStatus = "friend_status";

        public const string Random = "random";
        #endregion

        #region List properties

        public const string ListType = "list";
        public const string ListId = "lid";

        #endregion

        #region Audio constants

        public const string AudioType = "audio";
        public const string AudioIds = "audio_ids";
        public const string AudioId = "audio_id";
        public const string AlbumId = "album_id";
        public const string OwnerId = "owner_id";
        public const string Artist = "artist";
        public const string Title = "title";
        public const string Duration = "duration";
        public const string Url = "url";
        public const string TargetAudio = "target_audio";
        public const string OnlyEnglish = "only_eng";
        public const string GenreId = "genre_id";
        public const string GenreType = "genre";

        public const string AlbumType = "album";
        public const string PerformerOnly = "performer_only";
        public const string SearchOwn = "search_own";

        public const string Audios = "audios";
        public const string AudioGet = "audio.get";
        public const string AudioGetById = "audio.getById";
        public const string AudioGetLyrics = "audio.getLyrics";
        public const string AudioGetCount = "audio.getCount";
        public const string AudioSearch = "audio.search";
        public const string AudioAdd = "audio.add";
        public const string AudioDelete = "audio.delete";
        public const string AudioEdit = "audio.edit";
        public const string AudioRestore = "audio.restore";
        public const string AudioReorder = "audio.reorder";
        public const string AudioGetUploadServer = "audio.getUploadServer";
        public const string AudioSave = "audio.save";
        public const string AudioGetRecommendations = "audio.getRecommendations";
        public const string AudioGetPopular = "audio.getPopular";

        public const string AudioGetAlbums = "audio.getAlbums";
        public const string AudioAddAlbum = "audio.addAlbum";
        public const string AudioEditAlbum = "audio.editAlbum";
        public const string AudioDeleteAlbum = "audio.deleteAlbum";
        public const string AudioMoveToAlbum = "audio.moveToAlbum";

        #endregion

        #region Lyrics properties

        public const string LyricsType = "lyrics";
        public const string LyricsId = "lyrics_id";
        public const string LyricsText = "text";

        #endregion

        #region GroupType properties

        public const string Group = "group";
        public const string Page = "page";
        public const string Event = "event";
        public const string IsAdmin = "is_admin";
        public const string IsClosed = "is_closed";
        public const string IsMember = "is_member";
        public const string Groups = "groups";
        public const string Publics = "publics";
        public const string Events = "events";
        public const string Admin = "admin";
        public const string Editor = "editor";
        public const string Moderator = "moder";

        public const string GroupId = "group_id";
        public const string Place = "place";
        public const string Description = "description";
        public const string WikiPage = "wiki_page";
        public const string MembersCount = "members_count";
        public const string Counters = "counters";
        public const string StartDate = "start_date";
        public const string FinishDate = "finish_date";
        public const string Activity = "activity";
        public const string Links = "links";
        public const string FixedPost = "fixed_post";
        public const string Verified = "verified";
        public const string Site = "site";
        public const string CanCreateTopic = "can_create_topic";

        public const string GroupsGet = "groups.get";
        public const string GroupsGetById = "groups.getById";
        public const string GroupsIsMember = "groups.isMember";
        public const string GroupsGetMembers = "groups.getMembers";
        public const string GroupsSearch = "groups.search";

        #endregion

        #region Response constants

        public const string ResponseType = "response";
        public const string ErrorInResponse = "err";
        public const string ErrorType = "error";
        public const string ErrorCode = "error_code";
        public const string ErrorMessage = "error_msg";
        public const string ErrorReason = "error_reason";
        public const string ErrorDescription = "error_description";

        #endregion

        #region Auth constants

        public const string ApplicationId = "client_id";
        public const string RedirectUri = "redirect_uri";
        public const string ScopeMode = "scope";
        public const string DisplayName = "display";
        public const string ResponseTypeParameter = "response_type";
        public const string Token = "token";
        public const string AccessToken = "access_token";
        public const string ExpiresIn = "expires_in";
        public const string AuthUserId = "user_id";
        public const string Authorize = "authorize";

        #endregion

        #region Common constants

        public const string Version = "v";
        public const string Method = "method";
        public const string Id = "id";

        public const string Offset = "offset";
        public const string Count = "count";
        public const string Shuffle = "shuffle";
        public const string OwnerIdParameter = "oid";
        public const string UploadUrl = "upload_url";
        public const string AutoComplete = "auto_complete";
        public const string NoSearch = "no_search";
        public const string Query = "q";
        public const string Sort = "sort";
        public const string Before = "before";
        public const string After = "after";
        public const string Server = "server";
        public const string Settings = "settings";
        public const string Hash = "hash";
        public const string Extended = "extended";
        public const string Filter = "filters";
        public const string Type = "type";
        public const string Name = "name";
        public const string ScreenName = "screen_name";

        public const string Photo50 = "photo_50";
        public const string Photo100 = "photo_100";
        public const string Photo200 = "photo_200";
        public const string Photo200Original = "photo_200_orig";

        #endregion

        #region Captcha constants
        public const string CaptchaSid = "captcha_sid";
        public const string CaptchaImage = "captcha_img";
        public const string CaptchaKey = "captcha_key";
        #endregion

        #region Stats constants
        public const string StatsTrackVisitor = "stats.trackVisitor";
        #endregion
    }
}
