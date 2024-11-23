using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class GunMod : ItemBase
{
    public List<string> GunSupport { get; set; } = [];
    public List<string> RequiredGunTags { get; set; } = [];
}
