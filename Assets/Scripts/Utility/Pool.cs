using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool
{
    public int nextID = 0;
    public Dictionary<int, object> objects = new Dictionary<int, object>();
    public Dictionary<object, int> objectKeyId = new Dictionary<object, int>();
    public HashSet<int> reclaimedIds = new HashSet<int>();

    public T GetAvailableObject<T>() where T : new()
    {
        if (reclaimedIds.Count != 0)
        {
            int id = GetAvailableID();
            reclaimedIds.Remove(id);
            return (T)objects[id];
        }

        return CreateObject<T>();
    }

    private T CreateObject<T>() where T : new()
    {
        Type type = typeof(T);

        T _object;

        int id = GetAvailableID();

        if (typeof(Component).IsAssignableFrom(type))
        {
            GameObject gameObject = new GameObject(type.ToString() + "_Object_" + id);
            Component component = gameObject.AddComponent(type);
            _object = (T)(object)component;
        }
        else
        {
            _object = new T();
        }

        objects.Add(id, _object);
        objectKeyId.Add(_object, id);
        reclaimedIds.Remove(id);

        return _object;
    }

    public void ReturnObject(int id)
    {
        if (objects.ContainsKey(id))
        {
            reclaimedIds.Add(id);
        }
        else Debug.LogError("This Id does not exist.");
    }

    public void ReturnObject(object _object)
    {
        if (objectKeyId.ContainsKey(_object))
        {
            int id = objectKeyId[_object];

            reclaimedIds.Add(id);
        }
        else Debug.LogError("This Id does not exist.");
    }

    private int GetAvailableID()
    {
        if (reclaimedIds.Count == 0)
        {
            nextID = objects.Count;
            return nextID;
        }
        else return reclaimedIds.First();
    }
}
