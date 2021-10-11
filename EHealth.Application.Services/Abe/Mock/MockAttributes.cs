using System.Collections.Generic;
using EHealth.Application.Services.Abe.Base;

namespace EHealth.Application.Services.Abe.Mock
{
    public class MockAttributes : IAttributes, IAccessPolicy
    {
        private List<string> _attributes;
        
        public MockAttributes()
        {
            _attributes = new List<string>();
        }

        public MockAttributes(string attributes)
        {
            _attributes = new List<string>();
            _attributes.AddRange(attributes.Split(' '));
        }

        public MockAttributes(string[] attributes)
        {
            _attributes = new List<string>();
            _attributes.AddRange(attributes);
        }

        public string Get()
        {
            return string.Join(" ", _attributes);
        }

        public string AndGate()
        {
            return string.Join(" and ", _attributes);
        }
    }
}