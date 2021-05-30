using System;
using System.Collections.Generic;
using System.Text;

namespace Seed.Services.Models
{
    public class ContentHandler<T>
    {
        public T PropertyToReturn { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}
