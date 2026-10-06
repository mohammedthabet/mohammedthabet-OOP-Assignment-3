public class Store<T>
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public T? GetById(int id)
    {
        foreach (var item in _items)
        {
            if (item.Id == id)
                return item;
        }

        return default;
    }

    public List<T> GetAll()
    {
        return _items;
    }

    public void Remove(int id)
    {
        T? itemToRemove = default;

        foreach (var item in _items)
        {
            if (item.Id == id)
            {
                itemToRemove = item;
                break;
            }
        }

        if (itemToRemove is not null)
            _items.Remove(itemToRemove);
    }
}