using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictableCoding.Collections
{
    public class WhichToChoose : IDisposable
    {
        Dictionary<string, Guid> _veryLargeDictionary = new Dictionary<string, Guid>();
        List<string> _veryLargeList = new List<string>();

        public WhichToChoose()
        {
            Init();
        }

        public Guid DictionaryLookup()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            // O(1) operation
            var result = _veryLargeDictionary["M390876"];

            sw.Stop();
            System.Diagnostics.Trace.WriteLine($"Searching the large dictionary by index took {sw.Elapsed.TotalMilliseconds:N} ms --> {result}");

            return result;
        }

        public string ListSearch()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            // O(n) operation
            var result = _veryLargeList.FirstOrDefault(i => i == "M502984");

            sw.Stop();
            System.Diagnostics.Trace.WriteLine($"Searching the large list by query took {sw.Elapsed.TotalMilliseconds:N} ms --> {result}");

            return result;
        }

        private void Init()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                for (int x = 1; x <= 1000000; x++)
                {
                    string key = $"{c}{x}";
                    _veryLargeDictionary.Add(key, Guid.NewGuid());
                    _veryLargeList.Add(key);
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _veryLargeList.Clear();
                    _veryLargeList.TrimExcess();
                    _veryLargeList = null;

                    _veryLargeDictionary.Clear();
                    _veryLargeDictionary = null;
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
