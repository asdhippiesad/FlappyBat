using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour, IResettable where T : MonoBehaviour
{
    [SerializeField] private T _prefabs;
    [SerializeField] private Transform _container;

    private Queue<T> _pool;

    public IEnumerable<T> PoolObject { get; private set; }

    private void Awake()
    {
        _pool = new Queue<T>();
        PoolObject = _pool;
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            T newObject = Instantiate(_prefabs, _container);
            return newObject;
        }

        return _pool.Dequeue();
    }

    public void ReturnObject(T newObject)
    {
        newObject.gameObject.SetActive(false);
        _pool.Enqueue(newObject);
    }

    public void Reset()
    {
        foreach (var objectSpawn in _pool)
        {
            Destroy(objectSpawn);
        }

        _pool.Clear();
    }
}