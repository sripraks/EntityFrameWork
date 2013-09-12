using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamiteStore.DBObjectState
{
        public interface IObjectWithState
        {
            State State { get; set; }
        }
        public enum State
        {
            Added,
            Unchanged,
            Modified,
            Deleted
        }
}
