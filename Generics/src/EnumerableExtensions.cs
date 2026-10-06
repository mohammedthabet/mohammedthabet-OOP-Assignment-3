public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(
        this IEnumerable<T> source,
        int pageNumber,
        int pageSize)
    {
        if (pageNumber <= 0)
            throw new ArgumentOutOfRangeException(nameof(pageNumber));

        if (pageSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(pageSize));

        var skip = (pageNumber - 1) * pageSize;
        var index = 0;
        var returned = 0;

        foreach (var item in source)
        {
            if (index < skip)
            {
                index++;
                continue;
            }

            if (returned == pageSize)
                yield break;

            yield return item;

            index++;
            returned++;
        }
    }

    public static T? FindById<T>(
        this IEnumerable<T> source,
        int id)
        where T : IHasId
    {
        foreach (var item in source)
        {
            if (item.Id == id)
                return item;
        }

        return default;
    }

    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(
        this IEnumerable<T> source)
        where T : IHasId
    {
        var dictionary = new Dictionary<int, T>();

        foreach (var item in source)
        {
            dictionary.Add(item.Id, item);
        }

        return dictionary;
    }
}