namespace Configuration;

public class Configurator : IConfigurator
{
    private readonly Dictionary<string, object> _items;

    public Configurator()
    {
        _items = new Dictionary<string, object>();
    }

    public void Set(string key, object value)
    {
        _items[key] = value;
    }

    public TKey Get<TKey>(string key)
    {
        return (TKey)_items[key];
    }
}