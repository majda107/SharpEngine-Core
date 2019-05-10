using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Input;

namespace SharpEngine_Core.Processors
{
    abstract class AKeyboardProcessor
    {
        public List<Key> KeysDown { get; private set; }

        public AKeyboardProcessor()
        {
            this.KeysDown = new List<Key>();
        }

        public void AddKey(Key key)
        {
            if (!this.KeysDown.Contains(key))
            {
                this.KeysDown.Add(key);
            }
        }

        public void RemoveKey(Key key)
        {
            if(this.KeysDown.Contains(key))
            {
                this.KeysDown.Remove(key);
            }
        }
    }
}
