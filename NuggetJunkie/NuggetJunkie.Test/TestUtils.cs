using Newtonsoft.Json;

namespace NuggetJunkie.Test
{
    public static class TestUtils
    {
        public static string ToJson(this object obj)
             => JsonConvert.SerializeObject(obj).Replace('"', '\'');
    }
}