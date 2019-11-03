using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskSolving
{
    internal class BankSystem
    {
        private List<Account> accounts;
        private Stack<BankCommand> commands;

        public bool TryAddUser(Account account)
        {
            if (hasAccount(account.Id))
                return false;

            accounts.Add(account);
            return true;
        }

        public bool hasAccount(int id)
        {
            return (accounts.FirstOrDefault((Account account) => (account.Id == id))) != null;
        }

        public bool TryGetAccount(int id, out Account account)
        {
            account = accounts.FirstOrDefault((Account _account) => (_account.Id == id));
            if (account == null)
                return false;
            return true;
        }

        public void Undo()
        {
            BankCommand lastCommand = commands.Pop();
            lastCommand.Undo();
        }

        public bool TryCreateAccount(int id, int money)
        {
            try
            {
                commands.Push(new CreateAccount(accounts, new Account(id, money)));
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public bool TryMakeTranfer(int id1, int id2, int ammount)
        {
            Account firstAccount = accounts.Find(account => account.Id == id1);
            Account secondAccount = accounts.Find(account => account.Id == id2);

            if (firstAccount == null || secondAccount == null)
                return false;

            commands.Push(new Tranfer(firstAccount, secondAccount, ammount));
            return true;
        }

        public bool TryCloseAccount(int id)
        {
            Account _account = accounts.Find(account => account.Id == id);
            if (_account == null)
                return false;

            commands.Push(new CloseAccount(accounts, _account));
            return true;
        }

    }

    internal class Account
    {
        private int _id;
        private int _money;

        public int Id { get => _id; private set => _id = value; }
        public int Money { get => _money; private set => _money = value; }

        public Account(int id, int money = 0)
        {
            if (money < 0)
                throw new ArgumentOutOfRangeException("money");
            if (id < 0)
                throw new ArgumentOutOfRangeException("id");

            _id = id;
            _money = money;
        }

        public static void Transfer(Account sender, Account receiver, int amount)
        {
            if (amount > sender._money || amount < 0)
                throw new ArgumentOutOfRangeException("amount");

            receiver._money += amount;
            sender._money -= amount;
        }
    }

    internal abstract class BankCommand
    {
        private List<Account> _accounts;
        protected bool _isActive;
        public bool IsActive { get => _isActive; }

        public BankCommand()
        {
            _isActive = true;
        }

        public void Undo()
        {
            if (_isActive)
            {
                CancelAction();
                _isActive = false;
            }
            else
                throw new InvalidOperationException();
        }

        protected abstract void CancelAction();
    }

    internal class CreateAccount : BankCommand
    {
        private List<Account> _accounts;
        private Account _createdAccount;

        public CreateAccount(List<Account> accounts, Account account) : base()
        {
            _accounts = accounts;
            _createdAccount = account;
            _accounts.Add(_createdAccount);
        }

        protected override void CancelAction()
        {
            _accounts.Remove(_createdAccount);
        }
    }

    internal class Tranfer : BankCommand
    {
        private Account _sender;
        private Account _receiver;
        private int _ammount;

        public Tranfer(Account sender, Account receiver, int ammount) : base()
        {
            _sender = sender;
            _receiver = receiver;
            _ammount = ammount;
            Account.Transfer(sender, receiver, ammount);
        }

        protected override void CancelAction()
        {
            Account.Transfer(_receiver, _sender, _ammount);
        }
    }

    internal class CloseAccount : BankCommand
    {
        private List<Account> _accounts;
        private Account _closedAccount;
        public CloseAccount(List<Account> accounts, Account account)
        {
            _accounts = accounts;
            _closedAccount = account;

            if (_accounts.Find((Account) => Account == account) != null)
                accounts.Remove(_closedAccount);
            else
                throw new ArgumentException("account");
        }

        protected override void CancelAction()
        {
            _accounts.Add(_closedAccount);
        }
    }
}