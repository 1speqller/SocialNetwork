using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            return Query<FriendEntity>(@"select * from Friends where UserId = :UserId", new { user_id = userId });
        }

        public int Create(FriendEntity friendEntity)
        {
            return Execute(@"insert into Friends (UserId,FriendId) values (:UserId,:FriendId)", friendEntity);
        }

        public int Delete(int id)
        {
            return Execute(@"delete from Friends where Id = :Id_p", new { id_p = id });
        }

    }
    public interface IFriendRepository
    {
        int Create(FriendEntity friendEntity);
        IEnumerable<FriendEntity> FindAllByUserId(int userId);
        int Delete(int id);
    }
}
