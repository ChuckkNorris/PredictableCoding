using System;

namespace NamingIsHard_Code.IntentfulNamingDemo
{
    public abstract class ApiController
    {
        public object Request { get; set; }
    }

    internal class HttpGetAttribute : Attribute
    {
    }
}