﻿using System.Text.Json.Serialization;

namespace BcGov.Malt.Web.Models.SharePoint
{
    public class SharepointUser
    {
        [JsonPropertyName("d")]
        public SharepointUserData Data { get; set; }
    }

    public class SharepointUserData
    {
        [JsonPropertyName("results")]
        public SharepointUserResult[] Results { get; set; }
    }

    public class SharepointUserResult
    {
        [JsonIgnore]
        public SharepointUserMetadata __metadata { get; set; }

        [JsonIgnore]
        public SharepointUserGroups Groups { get; set; }

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        public bool IsHiddenInUI { get; set; }
        public string LoginName { get; set; }
        public string Title { get; set; }
        public int PrincipalType { get; set; }
        public string Email { get; set; }
        public bool IsShareByEmailGuestUser { get; set; }
        public bool IsSiteAdmin { get; set; }
        public Userid UserId { get; set; }
    }

    public class SharepointUserMetadata
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("uri")]
        public string uri { get; set; }

        [JsonPropertyName("id")]
        public string type { get; set; }
    }

    public class SharepointUserGroups
    {
        public SharepointUserDeferred deferred { get; set; }
    }

    public class SharepointUserDeferred
    {
        public string uri { get; set; }
    }

    public class SharepointUserid
    {
        public SharepointUseridMetadata metadata { get; set; }
        public string NameId { get; set; }
        public string NameIdIssuer { get; set; }
    }

    public class SharepointUseridMetadata
    {
        public string type { get; set; }
    }

}
