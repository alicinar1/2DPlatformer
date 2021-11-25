using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoSingleton<CoinSpawner>
{
    [SerializeField] private ObjectPool coinObjectPool;
    [SerializeField] private Vector2[] positions;

    [SerializeField]private int currentCoin = 33;

    public int CurrentCoin { get { return currentCoin; } 
      set 
        { 
            value = currentCoin;
            CreateCoins();
        } }

    private void Start()
    {
        CreateCoins();
    }


    private void CreateCoins()
    {
        for (int i = 0; i < currentCoin; i++)
        {
            GameObject obj = coinObjectPool.GetObjectInPool();            
            obj.SetActive(true);
            obj.transform.position = positions[i];
        }
    }
}
