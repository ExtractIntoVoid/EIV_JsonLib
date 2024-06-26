﻿using EIV_JsonLib.Interfaces;
using EIV_JsonLib.Defaults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EIV_JsonLib.Convert;

public class RigConverter : JsonConverter<IRig>
{
    public override IRig? ReadJson(JsonReader reader, Type objectType, IRig? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var item = new DefaultRig();
        var jsonObject = JObject.Load(reader);
        serializer.Populate(jsonObject.CreateReader(), item);
        return item;
    }

    public override void WriteJson(JsonWriter writer, IRig? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
