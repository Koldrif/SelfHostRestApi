namespace ApiWithAsp;

public class TestItem
{
    // TODO: Add interface IComparable for better logging
    public TestItem()
    {
        Name = "Empty";
        Id = -1;
    }
    public string Name { get; set; }
    public long? Id { get; set; }

    public override string ToString()
    {
        return $"[ Name: {Name} , Id: {Id} ]";
    }
}