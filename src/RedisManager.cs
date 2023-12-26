using StackExchange.Redis;

public class RedisManager
{
    private readonly ConnectionMultiplexer connectionMultiplexer;
    private readonly IDatabase database;

    public RedisManager()
    {
        // Redis bağlantı bilgilerini burada belirtin
        string redisConnectionString = "localhost:6379";
        connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
        database = connectionMultiplexer.GetDatabase();
    }

    public IDatabase GetDatabase()
    {
        return database;
    }
}
