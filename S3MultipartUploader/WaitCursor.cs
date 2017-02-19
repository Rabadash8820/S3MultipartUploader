using System;
using System.Windows.Forms;

namespace S3MultipartUploader {

    public class WaitCursor : IDisposable {

        private static int _numWaitCalls = 0;
        private static object _waitLock = new object();

        public WaitCursor() {
            deltaWaitingCalls(1);
        }
        public void Dispose() {
            deltaWaitingCalls(-1);
        }

        private static void deltaWaitingCalls(int delta) {
            lock (_waitLock) {
                _numWaitCalls = Math.Max(0, _numWaitCalls + delta);
                Application.UseWaitCursor = (_numWaitCalls > 0);
            }
        }

    }

}
