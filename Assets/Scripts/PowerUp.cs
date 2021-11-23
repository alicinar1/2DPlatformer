using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, ICollectable
{
    [SerializeField] CollectableScriptableObject collectableScriptableObject;

    private void Start()
    {
        SetProperties();
    }

    public void SetProperties()
    {
        this.name = collectableScriptableObject.NameOfObect;
        this.tag = collectableScriptableObject.TagOfObject;
        this.GetComponent<SpriteRenderer>().sprite = collectableScriptableObject.SpriteOfObject;
    }

    public void Animation()
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerEnter2D()
    {
        throw new System.NotImplementedException();
    }

}
