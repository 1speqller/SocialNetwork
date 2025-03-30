using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddView
    {
        FriendService friendService;
        FriendData friendData = new FriendData();
        public FriendAddView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            Console.Write("Введите email друга: ");
            friendData.FriendEmail = Console.ReadLine();
            friendData.UserEmail = user.Email;
            
            this.friendService.AddFriend(friendData);

            SuccessMessage.Show("Вы успешно добавили пользователя в друзья!!");
        }
    }
}
