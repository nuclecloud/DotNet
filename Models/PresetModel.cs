
using System;
using System.Collections.Generic;

namespace Nucle.Cloud
{
    [Serializable]
    public class PresetModel
    {
        public string id;

        public string name;

        public string globalValue;

        public string valueType;

        public string updateType;

        public string creationDate;

        public string lastUpdate;
    }

    [Serializable]
    public class PresetsModel
    {
        public List<PresetModel> list;

        public int totalCount;
    }
}