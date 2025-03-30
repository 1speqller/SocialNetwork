using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendListView
    {
        UserService userService;
        FriendService friendService;
        public FriendListView(UserService userService, FriendService friendService)
        {
            this.userService = userService;
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            foreach (var friend in this.friendService.GetFriends(user))
            {
                Console.WriteLine($"{this.userService.FindById(friend.friend_id).FirstName} {this.userService.FindById(friend.friend_id).LastName}");
            }

            Console.WriteLine();
        }
    }
}