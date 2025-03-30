using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public void AddFriend(FriendData friendData)
        {
            if (!new EmailAddressAttribute().IsValid(friendData.UserEmail) &&
                !new EmailAddressAttribute().IsValid(friendData.FriendEmail))
                throw new ArgumentNullException();

            if (userRepository.FindByEmail(friendData.UserEmail) == null &&
                userRepository.FindByEmail(friendData.FriendEmail) == null)
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            { 
                user_id = userRepository.FindByEmail(friendData.UserEmail).id,
                friend_id = userRepository.FindByEmail(friendData.FriendEmail).id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        public List<FriendEntity> GetFriends(User user)
        {
            return friendRepository.FindAllByUserId(user.Id).ToList();
        }
    }
}
