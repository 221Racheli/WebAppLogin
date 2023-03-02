using entities;
using Repository;
using System.Text.Json;
using Zxcvbn;


namespace Service
{
    public class UserService
    {
        UserRepository repository = new UserRepository();
        public User login(User user)
        {
            return repository.foundUser(user);
        }

        public User register(User user)
        {
            if(!repository.existUserName(user.email))
            {
                return repository.addUser(user);
            }
            return null;
        }

        public void update(User user,int id)
        {
            repository.updateUser(user, id);
        }

        public User getbyId(int id)
        {
            return repository.getUser(id);
        }

        
       
    }
}