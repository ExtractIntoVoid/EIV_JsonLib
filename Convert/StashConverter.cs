﻿using EIV_JsonLib.Interfaces;
using EIV_JsonLib.Defaults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EIV_JsonLib.Convert;

public class StashConverter : JsonConverter<IStash>
{
    public override IStash? ReadJson(JsonReader reader, Type objectType, IStash? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var item = new DefaultStash();
        var jsonObject = JObject.Load(reader);
        serializer.Populate(jsonObject.CreateReader(), item);
        return item;
    }

    public override void WriteJson(JsonWriter writer, IStash? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
