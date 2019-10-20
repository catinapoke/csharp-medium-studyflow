using System;
using System.Collections.Generic;

//  Через объект этого класса UsersHolder мы можем:
//  1)Получить пользователя по имени
//  2)Получить пользователя по Id
//  3)Получить всех пользователей
//  4)Получить пользователей у которых зарплата больше N
//  5)Получить пользователей у которых зарплата меньше N
//  6)Получить пользователей у которых зарплата от N1 до N2
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
            _name = name;
            _salary = salary;
            _id = id;
        }

        public static User CreateNewUser(int id, string name, int salary)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("id");
            if (name == null)
                throw new ArgumentOutOfRangeException("name");
            if (salary < 0)
                throw new ArgumentOutOfRangeException("salary");
            return new User(id, name, salary);
        }
    }

    internal class UsersHolder
    {
        private List<User> _users;
        public UsersHolder()
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
            return _users.FindAll(delegate (User user) { return user.Salary > salary; });
        }

        public List<User> GetUsersWithSalaryLess(int salary)
        {
            return _users.FindAll(delegate (User user) { return user.Salary < salary; });
        }

        public List<User> GetUsersWithSalaryBetween(int minSalary, int maxSalary)
        {
            return _users.FindAll(delegate (User user) { return user.Salary >= minSalary && user.Salary <= maxSalary; });
        }

        private bool TryFindUserByNameOrId(int id, string name)
        {
            return _users.Find(delegate (User user) { return (user.Id == id || user.Name == name); }) != null;
        }

    }
}