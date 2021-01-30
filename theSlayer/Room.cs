using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theSlayer
{
    class Room
    {
        private RoomType type;
        private string description;

        public Room(string description, RoomType type)
        {
            this.description = description;
            this.type = type;
        }

        public string getDesc()
        { return description; }

        public RoomType getType()
        { return type; }
    }

    public enum RoomType
    { FLINT, EMPTY, STICK, OIL, DARK, FOUNTAIN }
}
