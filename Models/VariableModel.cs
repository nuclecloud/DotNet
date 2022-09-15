using System;
using System.Collections;
using System.Collections.Generic;

namespace Nucle.Cloud
{

    [Serializable]
    public class VariableModel
    {
        public string id;
        public string userId;
        public string value;
        public string lastUpdate;
    }

    [Serializable]
    public class VariablesModel
    {
        public List<VariableModel> list;
        public int totalCount;
    }
}
