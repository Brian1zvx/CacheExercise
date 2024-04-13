
namespace CacheExercise
{
    public class GenericCache
    {
        private Dictionary<int, object> _objectCache;
        private Queue<int> _ids;
        private int _cacheSize;
        public GenericCache(int cacheSize) { 
            _ids = new Queue<int>(cacheSize);
            _objectCache = new Dictionary<int, object>(cacheSize);
            _cacheSize = cacheSize;
        }

        public object Add(int id, object value)
        {
            var removedObject = new object();
            if(_objectCache.Count == _cacheSize) {
                var oldestObject = _ids.Dequeue();
                removedObject = _objectCache[oldestObject];
                _objectCache.Remove(oldestObject);
            }
            else
            {
                removedObject = null;
            }
            _objectCache.Add(id, value);
            _ids.Enqueue(id);
            return removedObject;
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
            _objectCache.Remove(id);
            _ids = new Queue<int>(_ids.Where(x => x != id));
        }

    }
}
