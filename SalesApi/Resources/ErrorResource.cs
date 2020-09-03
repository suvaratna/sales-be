using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Resources
{
    public class ErrorResource
    {
        public bool Success => false;
        public List<string> Messages { get; private set; }
        public object Data { get; set; }

        public ErrorResource(List<string> messages)
        {
            this.Messages = messages ?? new List<string>();
        }

        public ErrorResource(string message)
        {
            this.Messages = new List<string>();

            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Messages.Add(message);
            }
        }
    }

    public class ResponseResource<T>
    {
        public bool Success { get; private set; }
        public List<string> Messages { get; private set; }
        public T Resource { get; private set; }

        public ResponseResource(T resource)
        {
            Success = true;
            Resource = resource;
            this.Messages = new List<string>();
        }

        public ResponseResource(string message)
        {
            Success = false;
            Resource = default;
            this.Messages = new List<string>();
            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Messages.Add(message);
            }
        }
        public ResponseResource(string message, bool success = false)
        {
            Success = true;
            Resource = default;
            this.Messages = new List<string>();
            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Messages.Add(message);
            }
        }
        public ResponseResource(T resource, string message, bool success = false)
        {
            Success = true;
            Resource = resource;
            this.Messages = new List<string>();
            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Messages.Add(message);
            }
        }
    }
}
