using Newtonsoft.Json;

public class UserManager
{
    private readonly RedisManager redisManager;
    private const string UserKeyPrefix = "user:";

    public UserManager(RedisManager redisManager)
    {
        this.redisManager = redisManager;
    }

    public void AddUser(UserSchema user)
    {
        string userKey = GetUserKey(user.Id);
        string serializedUser = JsonConvert.SerializeObject(user);
        redisManager.GetDatabase().StringSet(userKey, serializedUser);
    }

    public UserSchema GetUserById(int userId)
    {
        string userKey = GetUserKey(userId);
        string serializedUser = redisManager.GetDatabase().StringGet(userKey);
        return JsonConvert.DeserializeObject<UserSchema>(serializedUser);
    }

    private string GetUserKey(int userId)
    {
        return $"{UserKeyPrefix}{userId}";
    }
}
