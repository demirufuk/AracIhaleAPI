using System.Collections.Generic;

namespace Data.Models
{
    public class Utility
    {
    }

    public class Entity<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public dynamic Result { get; set; }
    }

    public class EntityList<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<T> Result { get; set; }
    }
}