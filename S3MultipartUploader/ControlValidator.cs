using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Concurrent;

namespace S3MultipartUploader {

    [DesignerCategory("Component")]
    public class ControlValidator : Component {

        private object _lock = new object();
        private ConcurrentDictionary<Control, bool> _validitySources = new ConcurrentDictionary<Control, bool>();

        public void MarkValidity(Control source, bool valid) {
            lock (_lock) {
                // Check validity state and add/update this validity source
                bool validBefore = _validitySources.TryGetValue(source, out validBefore);
                int countBefore = _validitySources.Count;
                int numInvalidBefore = _validitySources.Values.Count(v => !v);
                _validitySources.AddOrUpdate(source, valid, (ctrl, oldValid) => valid);

                // Raise an event if:
                //      This was the first validity source added
                //      This is now the only invalid source
                //      This was the last invalid source and it just became valid
                if ((countBefore == 0) ||
                    (numInvalidBefore == 0 && !valid) ||
                    (numInvalidBefore == 1 && !validBefore && valid))
                {
                    ValidityChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler ValidityChanged;
        public bool AllControlsValid {
            get {
                lock (_lock) return _validitySources.Values.All(v => v);
            }
        }
        public bool ControlValid(Control source) {
            lock (_lock) return _validitySources[source];
        }
        
    }

}
