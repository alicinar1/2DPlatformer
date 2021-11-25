using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private CollectableScriptableObject collectableScriptableObject;
    //[SerializeField] private CoinSpawner coinSpawner;
    //[SerializeField] private ObjectPool;

    private void Awake()
    {
        SetProperties();
    }

    public void SetProperties()
    {
        this.name = collectableScriptableObject.NameOfObect;
        this.tag = collectableScriptableObject.TagOfObject;
        this.GetComponent <SpriteRenderer>().sprite = collectableScriptableObject.SpriteOfObject;
    }
    public void Animation()
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerEnter2D()
    {
        Debug.Log("Coin");
        this.gameObject.SetActive(false);
        Player.Instance.CollectedCoins += 1;
        //CoinSpawner.Instance.CurrentCoin += 1;
    }

    private void OnBecameInvisible()
    {
        //CoinSpawner.Instance.CurrentCoin += 1;
    }

}
