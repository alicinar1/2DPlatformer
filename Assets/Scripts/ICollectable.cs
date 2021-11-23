using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    public void Animation();
    public void OnTriggerEnter2D();
    public void SetProperties();

    //public void OnBecameInvisible(GameObject gameObject);

}
