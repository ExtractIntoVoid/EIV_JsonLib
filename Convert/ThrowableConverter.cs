﻿using EIV_JsonLib.Interfaces;
using EIV_JsonLib.Defaults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EIV_JsonLib.Convert;

public class ThrowableConverter : JsonConverter<IThrowable>
{
    public override IThrowable? ReadJson(JsonReader reader, Type objectType, IThrowable? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var item = new DefaultThrowable();
        var jsonObject = JObject.Load(reader);
        serializer.Populate(jsonObject.CreateReader(), item);
        return item;
    }

    public override void WriteJson(JsonWriter writer, IThrowable? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
