using System;
using System.Collections.Generic;

namespace TaskSolving
{
    internal class User
    {
        private int _id;
        private string _name;
        private int _salary;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Salary { get => _salary; set => _salary = value; }

        private User(int id, string name, int salary)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("id");
            if (name == null)
                throw new ArgumentNullException("name");
            if (salary < 0)
                throw new ArgumentOutOfRangeException("salary");

            _name = name;
            _salary = salary;
            _id = id;
        }
    }

    internal class UsersStorage
    {
        private List<User> _users;

        public UsersStorage()
        {
            _users = new List<User>();
        }

        public bool TryAddUser(User user)
        {
            if (TryFindUserByNameOrId(user.Id, user.Name))
                return false;

            _users.Add(user);
            return true;
        }

        public User TryGetUser(string name)
        {
            return _users.Find(delegate (User user) { return user.Name == name; });
        }

        public User TryGetUser(int id)
        {
            return _users.Find(delegate (User user) { return user.Id == id; });
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public List<User> GetUsersWithSalaryMore(int salary)
        {
            return _users.FindAll((User user) => user.Salary > salary);
        }

        public List<User> GetUsersWithSalaryLess(int salary)
        {
            return _users.FindAll((User user) => user.Salary < salary);
        }

        public List<User> GetUsersWithSalaryBetween(int minSalary, int maxSalary)
        {
            return _users.FindAll((User user) => user.Salary >= minSalary && user.Salary <= maxSalary);
        }

        private bool TryFindUserByNameOrId(int id, string name)
        {
            return _users.Find((User user) => (user.Id == id || user.Name == name)) != null;
        }
    }
}