using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    private Dictionary<Type, Pool> pools = new Dictionary<Type, Pool>();

    public T GetAvailableObject<T>() where T : new()
    {
        Type type = typeof(T);

        Pool pool = GetPool(type);

        T _object = pool.GetAvailableObject<T>();

        if (typeof(Component).IsAssignableFrom(type))
        {
            DontDestroyOnLoad(((Component)(object)_object).gameObject);
        }

        return _object;
    }

    private Pool GetPool(Type type)
    {
        if (pools.ContainsKey(type))
        {
            return pools[type];
        }
        else
        {
            Pool pool = new Pool();
            pools.Add(type, pool);

            return pool;
        }
    }

    public void ReturnObject<T>(int id)
    {
        Type type = typeof(T);

        if (pools.ContainsKey(type))
        {
            Pool pool = pools[type];

            pool.ReturnObject(id);
        }
        else Debug.Log("This type of pool does not exist.");
    }

    public void ReturnObject(object _object)
    {
        Type type = _object.GetType();

        if (pools.ContainsKey(type))
        {
            Pool pool = pools[type];

            pool.ReturnObject(_object);
        }
        else Debug.Log("This type of pool does not exist.");
    }

    private int GetAvailableID(Pool pool)
    {
        if (pool.reclaimedIds.Count == 0) return pool.nextID++;
        else
        {
            int id = pool.reclaimedIds.First();
            pool.reclaimedIds.Remove(id);
            return id;
        }
    }
}