using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collectable Object", menuName = "Collectable Object")]
public class CollectableScriptableObject : ScriptableObject
{
    [SerializeField] private string nameOfObject;
    [SerializeField] private string tagOfObject;
    [SerializeField] private Sprite spriteOfObject;
 
    public string NameOfObect { get { return nameOfObject; } }
    public string TagOfObject { get { return tagOfObject; } }
    public Sprite SpriteOfObject { get { return spriteOfObject; } }
}
