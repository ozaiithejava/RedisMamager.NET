# RedisMamagerDOTET
a basic redismanager in dotnet


## Setup:
```markdown
dotnet add package StackExchange.Redis
```

## Usage:
```csharp
using System;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        RedisManager redisManager = new RedisManager();
        
        // Örnek kullanım:
        UserManager userManager = new UserManager(redisManager);
        UserSchema newUser = new UserSchema
        {
            Id = 1,
            Username = "john_doe",
            Password = "hashed_password",
            LastLoginIP = "192.168.0.1",
            Hwid = "user_hwid"
        };

        // Kullanıcıyı ekle
        userManager.AddUser(newUser);

        // Kullanıcıyı ID ile getir
        UserSchema retrievedUser = userManager.GetUserById(1);
        Console.WriteLine($"Retrieved User: {JsonConvert.SerializeObject(retrievedUser)}");
    }
}
```
