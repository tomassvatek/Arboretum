﻿namespace Arboretum.Common
{
    public class RequestHeaders
    {
        public RequestHeaders( string name, string value )
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
  
    }
}