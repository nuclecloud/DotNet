using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Nucle.Cloud
{


    [Serializable]
    public class PresetModel
    {
        public string id;

        public string name;

        public string globalValue;

        public valueType valueType;

        public updateType updateType;

        public string creationDate;

        public string lastUpdate;
    }

    [Serializable]
    public class PresetsModel
    {
        public List<PresetModel> list;

        public int totalCount;
    }


    public enum valueType
    {
        Integer,
        Float,
        Bool,
        String,
        Text
    }

    public enum updateType
    {
        AlwaysUpdate,
        UpdateIfNewIsMax,
        UpdateIfNewIsMin,
        CreateNew
    }
}