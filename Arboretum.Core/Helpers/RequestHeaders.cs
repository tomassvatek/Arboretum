namespace Arboretum.Core.Helpers
{
    public class RequestHeaders
    {
        public RequestHeaders( string name, string value )
        {
            Name = name;
            Value = value;
        }

        public RequestHeaders( ) 
        {
        }

        public string Name { get; set; }
        public string Value { get; set; }
  
    }
}