using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetUIText : MonoBehaviour
{
    [SerializeField] private TMP_Text tMPro;

    private void Update()
    {
        tMPro.text = "Coýns: " + Player.Instance.CollectedCoins;
    }
}
