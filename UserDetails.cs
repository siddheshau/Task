using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInformationSystem
{
    /// <summary>
    /// This class will contain user details which will
    /// take part in interaction.
    /// </summary>
    public class UserDetails
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }

        public UserDetails(int userid, int id, string title, bool completed)
        {
            this.UserId = userid;
            this.Id = id;
            this.Title = title;
            this.Completed = completed;
        }

        public override string ToString()
        {
            return "User ID: "+UserId + " "+"Unique ID: " + Id;
        }
    }
}
