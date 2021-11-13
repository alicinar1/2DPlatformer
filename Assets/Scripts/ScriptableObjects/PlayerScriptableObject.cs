using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player SO", menuName = "Player SO")]
public class PlayerScriptableObject : ScriptableObject
{
    [Header("General Informations")]
    public string tagOfPlayer;
    public string nameOfPlayer;

    [Header("Physical Conditions")]
    public float health;

    [Header("Physical Informations")]
    public float speedMultiplier;
    public float jumpMultiplier;
    public float highGravity;
    public float lowGravity = 1f;

    [Header("Phisical Limits")]
    public float maxSpeed;
}
