using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private const int InitialCapacity = 16;
    private LinkedList<KeyValue<TKey, TValue>>[] slots;


    public HashTable()
        : this(InitialCapacity)
    {
    }

    public HashTable(int capacity)
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        this.Count = 0;
    }


    public int Capacity
    {
        get
        {
            return this.slots.Length;
        }
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            return this.Select(element => element.Key);
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            return this.Select(element => element.Value);
        }
    }

    public int Count { get; private set; }

    public TValue this[TKey key]
    {
        get
        {
            return this.Get(key);
        }

        set
        {
            var element = this.Find(key);
            if (element == null)
            {
                this.Add(key, value);
            }
            else
            {
                element.Value = value;
            }
        }
    }


    public void Add(TKey key, TValue value)
    {
        this.GrowIfNeeded();
        var slot = this.FindSlotNumber(key);
        if (this.slots[slot] == null)
        {
            this.slots[slot] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        if (this.slots[slot].Any(element => element.Key.Equals(key)))
        {
            throw new ArgumentException("Key existst " + key);
        }

        var pair = new KeyValue<TKey, TValue>(key, value);
        this.slots[slot].AddLast(pair);
        this.Count++;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        var element = this.Find(key);
        if (element == null)
        {
            this.Add(key, value);
            return true;
        }
        else
        {
            element.Value = value;
        }

        return false;
    }

    public TValue Get(TKey key)
    {
        var element = this.Find(key);
        if (element == null)
        {
            throw new KeyNotFoundException();
        }

        return element.Value;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var element = this.Find(key);
        if (element != null)
        {
            value = element.Value;
            return true;
        }

        value = default(TValue);
        return false;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int slot = this.FindSlotNumber(key);
        var elements = this.slots[slot];

        if (elements != null)
        {
            foreach (var element in elements)
            {
                if (element.Key.Equals(key))
                {
                    return element;
                }
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        var element = this.Find(key);
        if (element == null)
        {
            return false;
        }

        return true;
    }

    public bool Remove(TKey key)
    {
        var slot = this.FindSlotNumber(key);
        var elements = this.slots[slot];
        if (elements != null)
        {
            var currentElement = elements.First;
            while (currentElement != null)
            {
                if (currentElement.Value.Key.Equals(key))
                {
                    elements.Remove(currentElement);
                    this.Count--;
                    return true;
                }

                currentElement = currentElement.Next;
            }
        }

        return false;
    }

    public void Clear()
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
        this.Count = 0;
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var elements in this.slots)
        {
            if (elements != null)
            {
                foreach (var keyValue in elements)
                {
                    yield return keyValue;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private int FindSlotNumber(TKey key)
    {
        var slotNumber = Math.Abs(key.GetHashCode() % this.Capacity);
        return slotNumber;
    }

    private void GrowIfNeeded()
    {
        if (((float)this.Count + 1) / this.Capacity > 0.75)
        {
            this.Grow();
        }
    }

    private void Grow()
    {
        var oldSlots = this.slots;
        var oldCount = this.Count;
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[this.Capacity * 2];

        foreach (var elements in oldSlots)
        {
            if (elements != null)
            {
                foreach (var keyValue in elements)
                {
                    this.Add(keyValue.Key, keyValue.Value);
                }
            }
        }

        this.Count = oldCount;
    }
}
