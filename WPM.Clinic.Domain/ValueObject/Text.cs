using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPM.Clinic.Domain.ValueObject
{
    public record Text
    {
        public string Value { get; init; }

        public Text(string value)
        {
            validate(value);

            this.Value = value;
        }


        private void validate(string value)
        {
            if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException("value", "Text is not valid"); }
            if (value.Length > 500) { throw new ArgumentException("Text is too long"); }
        }

        public static implicit operator Text(string value) { return new Text(value); }
    }
}
