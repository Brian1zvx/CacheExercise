using NUnit.Framework;

namespace CacheExercise
{
    
    [TestFixture]
    public class CacheExerciseTests
    {            
        [Test]
        public void Add_AddsObject_When_Called()
        {
            var testCache = new GenericCache(5);
            var removedValue = testCache.Add(1, "ObjectOne");
            
            var value = testCache.Get(1);
            
            Assert.That(removedValue, Is.Null);
            Assert.That(value, Is.EqualTo("ObjectOne"));

        }

        [Test]
        public void Add_RemovesOldest_When_CacheIsFull()
        {
            var testCache = new GenericCache(1);
            var firstVal = "ObjectOne";
            var removedValue = testCache.Add(1, firstVal);
            
            Assert.That(removedValue, Is.Null);
            var secondVal = "ObjectTwo";
            removedValue = testCache.Add(2, secondVal);

            Assert.That(removedValue, Is.Not.Null);
            Assert.That(removedValue, Is.EqualTo(firstVal));
            Assert.Throws<KeyNotFoundException>(() => testCache.Get(1));
     
            var value = testCache.Get(2);
            Assert.That(value, Is.EqualTo(secondVal)); 

        }

        [Test]
        public void Remove_RemovesValueAtId_When_Called()
        {
            var testCache = new GenericCache(3);
            var firstVal = "ObjectOne";
            var removedValue = testCache.Add(1, firstVal);

            var secondVal = "ObjectTwo";
            removedValue = testCache.Add(2, secondVal);

            var thirdVal = "ObjectThree";
            removedValue = testCache.Add(3, thirdVal);

            testCache.Remove(2);
            Assert.Throws<KeyNotFoundException>(() => testCache.Get(2));
            Assert.That(testCache.Get(1), Is.EqualTo(firstVal));
            Assert.That(testCache.Get(3), Is.EqualTo(thirdVal));

        }

        [Test]
        public void Clear_MakesTheCacheEmpty()
        {
            var testCache = new GenericCache(3);
            var firstVal = "ObjectOne";
            var removedValue = testCache.Add(1, firstVal);

            var secondVal = "ObjectTwo";
            removedValue = testCache.Add(2, secondVal);

            testCache.Clear();

            Assert.Throws<KeyNotFoundException>(() => testCache.Get(1));
            Assert.Throws<KeyNotFoundException>(() => testCache.Get(2));
        }

    }
}
