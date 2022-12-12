namespace ApiWithAsp.DataBase;

public static class UserDb
{
    private static long maxId = 0;
    private static Dictionary<long?, string> users = new();

    public static TestItem GetUserByName(string name)
    {
        foreach (var id in users.Keys)
        {
            if (users[id] == name)
                return new TestItem() { Id = id, Name = name };
        }

        return null;
    }

    public static TestItem GetUserById(long? id)
    {
        return users.ContainsKey(id) ? 
            new TestItem() {Id = id, Name = users[id]}
            :
            null;
    }

    public static TestItem AddUser(TestItem user)
    {
        TestItem newUser = new();
        if (users.ContainsKey(user.Id))
        {
            maxId++;
            newUser.Id = maxId;
            newUser.Name = user.Name;
        }
        else
        {
            maxId = (long)user.Id;
            newUser.Id = user.Id;
            newUser.Name = user.Name;
        }

        if (!users.TryAdd(newUser.Id, newUser.Name))
        {
            throw new Exception("Unable to add new user");
        }
        return newUser;
    }

    public static void RemoveUser(long id)
    {
        users.Remove(id);
    }
}