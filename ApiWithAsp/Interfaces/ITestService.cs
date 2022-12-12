namespace ApiWithAsp.Interfaces;

public interface ITestService
{
    TestItem Get(long id);
    TestItem Get(string Name);
    void Delete(long id);
    TestItem Save(TestItem item);
}