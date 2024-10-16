namespace Syphex.Domain.Entities;

public class Exchanger : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Ticker> Tickers { get; set; } = new List<Ticker>();

    private Exchanger(string name)
    {
        Name = name;
    }

    public static Exchanger Create(string name)
    {
        return new Exchanger(name);
    }
}
