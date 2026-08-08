using System.Collections.Generic;
using System.Linq;
using IT_ELECTIVE_2_MIDTERM_EXAM_SET_8_Garcia_Lorainne.Models;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_SET_8_Garcia_Lorainne.Repositories
{
    public class UserRepository
    {
        private static List<User> users = new List<User>();

        public void Add(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
        }

        public User GetByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }

        public bool Exists(string username)
        {
            return users.Any(u => u.Username == username);
        }
    }
}
