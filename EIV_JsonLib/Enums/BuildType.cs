namespace EIV_JsonLib;

/// <summary>
/// Type of build currently used.
/// </summary>
public enum BuildType : byte
{
    /// <summary>
    /// Cannot determine what build we using.
    /// </summary>
    None,
    /// <summary>
    /// Represents a game, combination of <see cref="Server"/> and <see cref="Client"/>.
    /// </summary>
    Game,
    /// <summary>
    /// Represents a server instance that manages clients.
    /// </summary>
    Server,
    /// <summary>
    /// Represents a client that interacts with the server.
    /// </summary>
    Client,
}
