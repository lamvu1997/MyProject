using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace WebSite2
{
    public class RoomProvider
    {
        public List<Room> getNameOfAllRoom()
        {
            DataAccess access = new DataAccess();
            List<Room> lcat = new List<Room>();
            DataTable dt = access.getNameOfAllRoom();
            foreach (DataRow dr in dt.Rows)
                lcat.Add(new Room(dr["Room"].ToString()));
            return lcat;
        }
    }

    public class Room
    {
        public string name { get; set; }
        public Room(string s)
        {
            name = s;
        }
    }
}