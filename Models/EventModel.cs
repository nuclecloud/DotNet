using System;
using System.Collections.Generic;

namespace Nucle.Cloud.Models
{
    public class EventModel
    {
        public DateTime date;
        public int count;
    }

    [Serializable]
    public class EventsModel
    {
        public List<EventModel> list;
        public int totalCount;
    }
}

