namespace EIV_JsonLib.Lobby;

public enum ClientSocketEnum
{
    /// <summary>
    /// Custom message for lobby related plugins.
    /// </summary>
    Custom = -1,
    /// <summary>
    /// Nothing, only used to skip messages
    /// </summary>
    None,
    /// <summary>
    /// Basic response for socket.
    /// </summary>
    SocketResponse,
    /// <summary>
    /// User request to join a map. Create or Join.
    /// </summary>
    MatchmakeCheck,
    /// <summary>
    /// Sent to users when the game started.
    /// </summary>
    GameStart,
    /// <summary>
    /// Create a Group.
    /// </summary>
    GroupCreate,
    /// <summary>
    /// Delete a Group.
    /// </summary>
    GroupDelete,
    /// <summary>
    /// Update a group. This mean join, leave, set other as manager.
    /// </summary>
    GroupUpdate,
    /// <summary>
    /// Invite send to desired player.
    /// </summary>
    GroupInvite,
    /// <summary>
    /// Respond of the Invitee.
    /// </summary>
    GroupInviteResponse,
    /// <summary>
    /// Kick desired player. (Has Reason too)
    /// </summary>
    GroupKick,
    /// <summary>
    /// Search for friend name
    /// </summary>
    FriendSearch,
    /// <summary>
    /// Response to <see cref="FriendSearch"/>
    /// </summary>
    FriendSearchResponse,
    /// <summary>
    /// Adding / Removing a friend invite
    /// </summary>
    FriendAddOrRemove,
    /// <summary>
    /// Accepting or Denying a friend request
    /// </summary>
    FriendRequest,
    /// <summary>
    /// Adding, removing users in the blocklist.
    /// </summary>
    BlockListUpdate,
    /// <summary>
    /// Moving any item to its place.
    /// </summary>
    MoveItemAction,
    /// <summary>
    /// Consume the item.
    /// </summary>
    ConsumeItemAction,
    /// <summary>
    /// Discard the item.
    /// </summary>
    DiscardItemAction,
    // More soon

}
