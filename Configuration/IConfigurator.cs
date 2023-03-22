namespace Configuration;

public interface IConfigurator
{
    void Set(string key, object value);
    TKey Get<TKey>(string key);
}