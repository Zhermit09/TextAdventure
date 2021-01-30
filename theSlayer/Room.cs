using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theSlayer
{
    class Room
    {
        private string id;
        private RoomType type;
        private string description;

        public Room(string id, string description, RoomType type)
        {
            this.id = id;
            this.description = description;
            this.type = type;
        }
        public string getID()
        { return id; }

        public string getDesc()
        { return description; }

        public RoomType getType()
        { return type; }
    }

    public enum RoomType
    { FLINT, EMPTY, STICK, OIL, DARK, FOUNTAIN }
}
