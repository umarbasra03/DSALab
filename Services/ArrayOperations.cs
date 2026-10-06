using System.Collections.Generic;

namespace DSALab.Services
{
    public class ArrayOperations
    {
        private readonly int[] _arr;
        private int _size;

        public int Capacity { get; }

        public int Size => _size;

        public ArrayOperations(int capacity = 15)
        {
            Capacity = capacity;
            _arr = new int[capacity];
            _size = 0;
        }

        // Traverse
        public int[] Snapshot()
        {
            int[] copy = new int[_size];

            System.Array.Copy(
                _arr,
                copy,
                _size
            );

            return copy;
        }

        // ================= TASK 01 =================

        // Insert at End
        public bool InsertAtEnd(int value)
        {
            if (_size >= Capacity)
                return false;

            _arr[_size++] = value;

            return true;
        }

        // Insert at Beginning
        public bool InsertAtBeginning(int value)
        {
            if (_size >= Capacity)
                return false;

            for (int i = _size; i > 0; i--)
            {
                _arr[i] = _arr[i - 1];
            }

            _arr[0] = value;

            _size++;

            return true;
        }

        // ================= TASK 02 =================

        // Insert at Position
        public (bool ok, string msg) InsertAtPosition(
            int pos,
            int value)
        {
            if (_size >= Capacity)
                return (false, "Array is full.");

            if (pos < 0 || pos > _size)
                return (false, "Invalid position.");

            for (int i = _size; i > pos; i--)
            {
                _arr[i] = _arr[i - 1];
            }

            _arr[pos] = value;

            _size++;

            return (true, "Inserted successfully.");
        }

        // Delete at Position
        public (bool ok, string msg) DeleteAtPosition(int pos)
        {
            if (_size == 0)
                return (false, "Array is empty.");

            if (pos < 0 || pos >= _size)
                return (false, "Invalid position.");

            for (int i = pos; i < _size - 1; i++)
            {
                _arr[i] = _arr[i + 1];
            }

            _size--;

            return (true, "Deleted successfully.");
        }

        // Delete from End
        public bool DeleteFromEnd()
        {
            if (_size == 0)
                return false;

            _size--;

            return true;
        }

        // ================= TASK 03 =================

        // Update
        public bool UpdateAtPosition(
            int pos,
            int newValue)
        {
            if (pos < 0 || pos >= _size)
                return false;

            _arr[pos] = newValue;

            return true;
        }

        // Linear Search
        public int LinearSearch(int key)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_arr[i] == key)
                    return i;
            }

            return -1;
        }

        // ================= TASK 04 =================

        // Delete from Beginning
        public bool DeleteFromBeginning()
        {
            if (_size == 0)
                return false;

            for (int i = 0; i < _size - 1; i++)
            {
                _arr[i] = _arr[i + 1];
            }

            _size--;

            return true;
        }

        // Bonus: Search All Occurrences
        public List<int> LinearSearchAll(int key)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < _size; i++)
            {
                if (_arr[i] == key)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        // Helper method
        public void Seed(params int[] values)
        {
            foreach (int value in values)
            {
                if (_size >= Capacity)
                    break;

                _arr[_size++] = value;
            }
        }
    }
}