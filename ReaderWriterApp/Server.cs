using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderWriterApp
{
    public static class Server
    {
        private static int count;
        private static ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        public static void AddToCount(int value)
        {
            locker.EnterWriteLock();
            count += value;
            locker.ExitWriteLock();
        }

        public static int GetCount()
        {
            locker.EnterWriteLock();
            try
            {
                return count;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }
}
