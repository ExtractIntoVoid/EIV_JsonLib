using EIV_Items.Core;

namespace EIV_Items.Interfaces;

/// <summary>
/// An interface for checking whenever a <see cref="CoreItem"/> is compatible with this item.
/// </summary>
public interface ICompatible
{
    /// <summary>
    /// Checks whenever <paramref name="item"/> is compatible with this item.
    /// </summary>
    /// <param name="item">The item to check.</param>
    /// <returns><see langword="true"/> if compatible; otherwise <see langword="false"/>.</returns>
    public bool IsCompatible(CoreItem item);
}
