using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotNRandomizerLauncher
{
    [Serializable]
    public class RandomizerException : Exception
    {
        public RandomizerException() : base() { }
        public RandomizerException(string message) : base(message) { }
        public RandomizerException(string message, Exception inner) : base(message, inner) { }
    }
}
