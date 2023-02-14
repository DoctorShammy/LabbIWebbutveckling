using System;
using System.Text.Json.Serialization;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using LIW.Membership2.API.Util;

namespace LIW.Membership2.API.Util
{
    public static class JsonUtility
    {
        public static T RemoveLoops<T>(T obj)
        {
            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            return JsonSerializer.Deserialize<T>(json);
        }
    }

}