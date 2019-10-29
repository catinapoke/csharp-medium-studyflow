using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSolving
{
    // Сделайте консольную программу, через которую можно запускать команды.Например:
    // 1. Создать счёт в системе
    // 2. Перевести деньги с одного счёта на другой
    // 3. Закрыть счёт
    // Команды должны запускать через простой консольный интерфейс(просто вводится название команды).
    // Важной особенностью является спец.команда - undo.Она отменяет команду.Вызов двух undo
    // подряд отменит две предыдущие команды.

    class BankSystem
    {
        List<Account> accounts;
        IBankCommand[] commands;

        bool TryAddUser(Account account)
        {
            if (hasAccount(account.Id))
                return false;

            accounts.Add(account);
            return true;
        }

        bool hasAccount(int id)
        {
            return (accounts.FirstOrDefault((Account account) => (account.Id == id))) != null;
        }

        Account TryGetAccount(int id)
        {
            Account account = accounts.FirstOrDefault((Account _account) => (_account.Id == id));
            if (account == null)
                throw new ArgumentNullException();
            return account;
        }
    }

    class Account
    {
        int _id;
        int _money;

        public int Id { get => _id; private set => _id = value; }
        public int Money { get => _money; private set => _money = value; }

        Account(int id, int money = 0)
        {
            if (money < 0)
                throw new ArgumentOutOfRangeException("money");
            if (id < 0)
                throw new ArgumentOutOfRangeException("id");

            _id = id;
            _money = money;
        }

        void Transfer(Account receiver, int amount)
        {
            if (amount > _money || amount < 0)
                throw new ArgumentOutOfRangeException("amount");

            receiver._money += amount;
            _money -= amount;
        }
    }

    interface IBankCommand
    {
        void Do(List<Account> accounts);
        void Undo();
    }

    class CreateAccount : IBankCommand
    {
        List<Account> _accounts;
        public void Do(List<Account> accounts)
        {
            _accounts = accounts;
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }

    class Tranfer : IBankCommand
    {
        public void Do(List<Account> accounts)
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }

    class CloseAccount : IBankCommand
    {
        public void Do(List<Account> accounts)
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
