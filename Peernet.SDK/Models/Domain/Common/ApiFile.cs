﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Peernet.SDK.Models.Domain.Common
{
    public class ApiFile
    {
        public string Id { get; set; }

        public byte[] Hash { get; set; }

        public LowLevelFileType Type { get; set; }

        public HighLevelFileType Format { get; set; }

        public long Size { get; set; }

        public string Folder { get; set; } = "";

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public byte[] NodeId { get; set; }

        public List<ApiFileMetadata> MetaData { get; set; }

        [JsonIgnore]
        public int SharedByCount =>
            MetaData?.FirstOrDefault(md => md.Type == MetadataType.TagSharedByCount)?.Number ?? 0;

        [JsonIgnore]
        public string SharedByGeoIP =>
            MetaData?.FirstOrDefault(md => md.Type == MetadataType.TagSharedByGeoIP)?.Text;
    }
}