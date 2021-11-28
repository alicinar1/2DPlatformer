using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Link link;
    private void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, playerHand.position);
        lineRenderer.SetPosition(1, link.transform.position);
    }
}
