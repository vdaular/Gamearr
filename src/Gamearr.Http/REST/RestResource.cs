﻿using Newtonsoft.Json;

namespace Gamearr.Http.REST
{
    public abstract class RestResource
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonIgnore]
        public virtual string ResourceName => GetType().Name.ToLowerInvariant().Replace("resource", "");
    }
}