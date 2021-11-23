using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform parentObject;
    [SerializeField] private int objectCount;
    

    Queue<GameObject> objectsInPool;

    private void Awake()
    {
        CreateObjects();
    }

    private void CreateObjects()
    {
        objectsInPool = new Queue<GameObject>();
        for (int i = 0; i < objectCount; i++)
        {
            GameObject obj = Instantiate(objectPrefab, Vector3.zero, Quaternion.identity, parentObject);
            obj.SetActive(true);
            objectsInPool.Enqueue(obj);
        }
    }

    public GameObject GetObjectInPool()
    {
        GameObject obj = objectsInPool.Dequeue();
        obj.SetActive(true);
        objectsInPool.Enqueue(obj);

        return obj;
    }

}
