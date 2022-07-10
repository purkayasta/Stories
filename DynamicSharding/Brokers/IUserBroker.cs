using System;

namespace DynamicSharding.Brokers;

public interface IUserBroker
{
    int Insert(User data);
    IQueryable<User> GetUsers();
    User GetUser(string id);
}
