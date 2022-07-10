namespace DynamicSharding.Brokers;

public class UserBroker : IUserBroker
{
    private readonly NormalDbContext _dbContext;

    public UserBroker(NormalDbContext dbContext) => _dbContext = dbContext;

    public IQueryable<User> GetUsers() => _dbContext.Users;

    public int Insert(User data)
    {
        if (data is null) return 0;

        _dbContext.Users.Add(data);
        return _dbContext.SaveChanges();
    }

    public User GetUser(string id) => _dbContext.Users.FirstOrDefault(x => x.Id == id);
}
