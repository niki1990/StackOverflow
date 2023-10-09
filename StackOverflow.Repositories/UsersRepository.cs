using System;
using System.Collections.Generic;
using System.Linq;
using StackOverFlowProject.DomainModel;

namespace StackOverflow.Repositories
{

    public interface IUsersRepository
    {
        void InsertUser(User u);
        void UpdateUserDetails(User u);
        void UpdateUserPassword(User u);
        void DeleteUser(int uid);
        List<User> GetUsers();
        User GetUsersByEmailAndPassword(string Email, string Password);
        User GetUsersByEmail(string Email);
        User GetUsersByUserID(int UserID);
        int GetLatestUserID();
    }
    public class UsersRepository : IUsersRepository
    {
        StackOverflowDataDbContext stackOverflowDataDbContext;
        public UsersRepository()
        {
            stackOverflowDataDbContext = new StackOverflowDataDbContext();
        }
        public void DeleteUser(int uid)
        {
            User user = stackOverflowDataDbContext.Users.Where(temp => temp.UserID == uid).FirstOrDefault();
            stackOverflowDataDbContext.Users.Remove(user);
            stackOverflowDataDbContext.SaveChanges();
        }

        public int GetLatestUserID()
        {
           int UserID=stackOverflowDataDbContext.Users.Select(x => x.UserID).Max();
            return UserID;
        }

        public List<User> GetUsers()
        {
            List<User> users = stackOverflowDataDbContext.Users.Where(temp => temp.IsAdmin==false).ToList();
            return users;
        }

        public User GetUsersByEmail(string Email)
        {
            User user = stackOverflowDataDbContext.Users.Where(temp => temp.Email == Email ).FirstOrDefault();
            return user;
        }

        public User GetUsersByEmailAndPassword(string Email, string Password)
        {
            User user = stackOverflowDataDbContext.Users.Where(temp => temp.Email == Email && temp.PasswordHash==Password).FirstOrDefault();
            return user;
        }

        public User GetUsersByUserID(int UserID)
        {
            User users = stackOverflowDataDbContext.Users.Where(temp => temp.UserID == UserID).FirstOrDefault(); 
            return users;
        }

        public void InsertUser(User u)
        {
            stackOverflowDataDbContext.Users.Add(u);
            stackOverflowDataDbContext.SaveChanges();
        }

        public void UpdateUserDetails(User u)
        {
            User user= stackOverflowDataDbContext.Users.Where(temp=>temp.UserID==u.UserID).FirstOrDefault();
            if (user != null)
            {
                user.Mobile = u.Mobile;
                user.Name = u.Name;
                stackOverflowDataDbContext.SaveChanges();
            }
        }

        public void UpdateUserPassword(User u)
        {
            User user = stackOverflowDataDbContext.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if (user != null)
            {
                user.PasswordHash = u.PasswordHash;
                stackOverflowDataDbContext.SaveChanges();
            }
        }
    }
}
