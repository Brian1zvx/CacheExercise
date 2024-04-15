
using System.Collections.Concurrent;

namespace CacheExercise
{
    public class GenericCache
    {
        private int _cacheSize;
        private ConcurrentDictionary<int, object> _objectCache;
        private Queue<int> _ids;
        
        public GenericCache(int cacheSize) { 
            _ids = new Queue<int>(cacheSize);
            _objectCache = new ConcurrentDictionary<int, object>();
            _cacheSize = cacheSize;
        }

        public object? Add(int id, object value)
        {
            var removedObject = new object();
            if (_objectCache.TryAdd(id, value)) // Adds new item provided no value already exists at that Id. 
            {
                if (_ids.Count == _cacheSize)
                {
                    var oldestObject = _ids.Dequeue();
                    if (!_objectCache.TryRemove(oldestObject, out removedObject))
                    {
                        _ids.Enqueue(oldestObject); //Re-add back into queue before throwing expection
                        throw new InvalidOperationException("Removal of oldest object from the cache failed unexpectedly");
                    };
                }
                else
                {
                    removedObject = null;
                }

                _ids.Enqueue(id);
                return removedObject;
            }
            else
            {
                // Potentially add logging here and just return null depending on overall design
                throw new ArgumentException("Object already in the cache with that Id");
            }
        }

        public void Clear()
        {
            _objectCache.Clear();
        }

        public object Get(int id)
        {
            return _objectCache[id];
        }

        public void Remove(int id) //Should be used sparingly as a queue generally works on FIFO
        {
            if (!_objectCache.TryRemove(id, out var removedObject))
            {
                throw new InvalidOperationException($"Removal of object at id: {id} from the queue failed unexpectedly");
            };
            _ids = new Queue<int>(_ids.Where(x => x != id));
        }

    }
}
