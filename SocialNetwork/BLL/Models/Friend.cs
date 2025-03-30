using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string FriendEmail { get; set; }

        public Friend(int id, string userEmail, string friendEmail)
        {
            Id = id;
            UserEmail = userEmail;
            FriendEmail = friendEmail;
        }
    }
}