using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "Power Up")]
public class PowerUpScriptableObject : ScriptableObject
{
    public string nameOfPO;
    public string typeOfPO;
    public string tagOfPO;
    public Color spriteColor;
}
