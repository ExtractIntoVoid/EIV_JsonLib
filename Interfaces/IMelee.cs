﻿using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(MeleeFormatter))]
public interface IMelee : IUsable, IDamageDealer
{

}
