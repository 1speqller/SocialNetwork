using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public int Create(UserEntity userEntity)
        {
            return Execute(@"insert into Users (FirstName,LastName,Password,Email) 
                             values (:FirstName,:LastName,:Password,:Email)", userEntity);
        }

        public IEnumerable<UserEntity> FindAll()
        {
            return Query<UserEntity>("select * from Users");
        }

        public UserEntity FindByEmail(string email)
        {
            return QueryFirstOrDefault<UserEntity>("select * from Users where Email = :Email_p", new { email_p = email });
        }

        public UserEntity FindById(int id)
        {
            return QueryFirstOrDefault<UserEntity>("select * from Users where Id = :Id_p", new { id_p = id });
        }

        public int Update(UserEntity userEntity)
        {
            return Execute(@"update Users set FirstName = :FirstName, LastName = :LastName, Password = :Password, Email = :Email,
                             Photo = :Photo, FavoriteMove = :FavoriteMovie, FavoriteBook = :FavoriteBook where Id = :Id", userEntity);
        }

        public int DeleteById(int id)
        {
            return Execute("delete from Users where Id = :Id_p", new { id_p = id });
        }
    }

    public interface IUserRepository
    {
        int Create(UserEntity userEntity);
        UserEntity FindByEmail(string email);
        IEnumerable<UserEntity> FindAll();
        UserEntity FindById(int id);
        int Update(UserEntity userEntity);
        int DeleteById(int id);
    }
}
