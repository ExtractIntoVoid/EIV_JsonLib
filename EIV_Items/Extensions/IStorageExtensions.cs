using EIV_Items.Core;
using EIV_Items.Interfaces;

namespace EIV_Items.Extensions;

/// <summary>
/// Provides an extension for <see cref="IStorage"/> items.
/// </summary>
public static class IStorageExtensions
{
    /// <summary>
    /// Checks whenever <paramref name="item"/> can be added to <paramref name="storage"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="CoreItem"/> type.</typeparam>
    /// <param name="storage">The storage.</param>
    /// <param name="item">The item.</param>
    /// <returns><see langword="true"/> if can be added; otherwise <see langword="false"/>.</returns>
    public static bool CanAddItem<T>(this IStorage storage, T item)
        where T : CoreItem
    {
        if (storage == null || item == null)
        {
            return false;
        }

        if (storage.IsFull())
        {
            return false;
        }

        if (storage.GetCurrentVolume() + item.Volume >= storage.MaxVolume)
        {
            return false;
        }

        if (storage.GetCurrentWeight() + item.Weight >= storage.MaxWeight)
        {
            return false;
        }

        if (storage is ICompatible storeCompatible && storeCompatible.IsCompatible(item))
        {
            return true;
        }

        return true;
    }

    /// <summary>
    /// Tries to add <paramref name="item"/> into <paramref name="storage"/>.
    /// </summary>
    /// <typeparam name="T">Any <see cref="CoreItem"/> type.</typeparam>
    /// <param name="storage">The storage.</param>
    /// <param name="item">The item.</param>
    /// <returns><see langword="true"/> if success; otherwise <see langword="false"/>.</returns>
    public static bool TryAddItemStorage<T>(this IStorage storage, T item)
        where T : CoreItem
    {
        if (storage == null || item == null)
        {
            return false;
        }

        if (!storage.CanAddItem(item))
        {
            return false;
        }

        storage.Items.Add(item);
        return true;
    }

    /// <summary>
    /// Tries to add <paramref name="item"/> into <paramref name="storage"/>.
    /// </summary>
    /// <param name="storage">The storage.</param>
    /// <param name="item">The item.</param>
    /// <returns><see langword="true"/> if success; otherwise <see langword="false"/>.</returns>
    public static bool TryAddItemStorage(this IStorage storage, CoreItem item)
    {
        if (storage == null || item == null)
        {
            return false;
        }

        if (!storage.CanAddItem(item))
        {
            return false;
        }

        storage.Items.Add(item);
        return true;
    }

    /// <summary>
    /// Tries to add <paramref name="items"/> into <paramref name="storage"/>.
    /// </summary>
    /// <param name="storage">The storage.</param>
    /// <param name="items">The items.</param>
    /// <returns><see langword="true"/> if success; otherwise <see langword="false"/>.</returns>
    public static bool TryAddItems(this IStorage storage, params CoreItem[] items)
    {
        if (items == null)
        {
            return false;
        }

        foreach (CoreItem item in items)
        {
            if (!storage.TryAddItemStorage(item))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Checks whenever the <paramref name="storage"/> is full.
    /// </summary>
    /// <param name="storage">The storage.</param>
    /// <returns><see langword="true"/> if full; otherwise <see langword="false"/>.</returns>
    public static bool IsFull(this IStorage storage)
    {
        if (storage == null)
        {
            return true;
        }

        return (storage.Items.Count == storage.MaxSize) || ((storage.GetCurrentVolume() >= storage.MaxVolume) && (storage.GetCurrentWeight() >= storage.MaxWeight));
    }

    /// <summary>
    /// Gets the current weight of the items in <paramref name="storage"/>.
    /// </summary>
    /// <param name="storage">The storage.</param>
    /// <returns>The current weight.</returns>
    public static double GetCurrentWeight(this IStorage storage)
    {
        if (storage == null)
        {
            return 0;
        }

        if (storage.Items.Count == 0)
        {
            return 0;
        }

        return storage.Items.Sum(x => x.Weight);
    }

    /// <summary>
    /// Gets the current volume of the items in <paramref name="storage"/>.
    /// </summary>
    /// <param name="storage">The storage.</param>
    /// <returns>The current volume.</returns>
    public static double GetCurrentVolume(this IStorage storage)
    {
        if (storage == null)
        {
            return 0;
        }

        if (storage.Items.Count == 0)
        {
            return 0;
        }

        return storage.Items.Sum(x => x.Volume);
    }
}
