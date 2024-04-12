
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

        public void Add(int id, object value)
        {
            if(_objectCache.Count == _cacheSize) {
                //TODO Handle removal of least recently used. Pop it out and continue
            }
            //TODO add new value with id as key
        }

    }
}
