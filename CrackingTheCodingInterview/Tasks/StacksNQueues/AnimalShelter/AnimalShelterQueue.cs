using System;
using DataStructures;
using DataStructures.MyDoublyLinkedList;

namespace Tasks.StacksNQueues.AnimalShelter
{
    //#6 Animal Shelter
    public class AnimalShelterQueue
    {
        private MyDoublyLinkedList<Cat> _cats;
        private MyDoublyLinkedList<Dog> _dogs;

        public int Count => _cats.Count + _dogs.Count;
        private int _order;
        public AnimalShelterQueue()
        {
            _cats = new MyDoublyLinkedList<Cat>();
            _dogs = new MyDoublyLinkedList<Dog>();
        }

        public void Enqueue(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException();

            animal.Order = _order++;
            if (animal is Dog dog)
                _dogs.AddFirst(new MyDoublyLinkedListNode<Dog>(dog));
            if (animal is Cat cat)
                _cats.AddFirst(new MyDoublyLinkedListNode<Cat>(cat));
        }

        public Animal DequeueAny()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            if (_dogs.Count == 0)
                return DequeueCat();
            if (_cats.Count == 0)
                return DequeueDog();

            if (_cats.Tail.Data.Order > _dogs.Tail.Data.Order)
                return DequeueDog();
            return DequeueCat();
        }

        public Dog DequeueDog()
        {
            if (_dogs.Count == 0)
                throw new InvalidOperationException();

            var dog = _dogs.Tail.Data;
            _dogs.RemoveLast();
            return dog;
        }

        public Cat DequeueCat()
        {
            if (_cats.Count == 0)
                throw new InvalidOperationException();

            var cat = _cats.Tail.Data;
            _cats.RemoveLast();
            return cat;
        }
    }
}
