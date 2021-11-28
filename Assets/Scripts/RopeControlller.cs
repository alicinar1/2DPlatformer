using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeControlller : MonoSingleton<RopeControlller>
{
    Vector3 actieveLinkPos;
    [SerializeField] Transform playerHandsRight;
    [SerializeField] Transform playerHandsLeft;

    public void DrawRope(Vector3 linkPos)
    {        
        Player.Instance.GetComponent<LineRenderer>().enabled = true;
        actieveLinkPos = linkPos;
        Debug.Log("Rope");
    }

    public void DeleteRope()
    {
        Player.Instance.GetComponent<LineRenderer>().enabled = false;
    }

    private void Update()
    {
        Player.Instance.GetComponent<LineRenderer>().SetPosition(0, actieveLinkPos);
        if (Player.Instance.IsFacingRight)
        {
            Player.Instance.GetComponent<LineRenderer>().SetPosition(1, playerHandsRight.position);

        }
        else
        {
            Player.Instance.GetComponent<LineRenderer>().SetPosition(1, playerHandsLeft.position);
        }
    }
}
