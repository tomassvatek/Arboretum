namespace Arboretum.Core
{
    public class RequestHeader
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public RequestHeader( string key, string value )
        {
            Key = key;
            Value = value;
        }
    }
}