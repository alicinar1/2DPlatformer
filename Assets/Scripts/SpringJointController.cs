using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJointController : MonoSingleton<SpringJointController>
{    
    public void SetConnectedRigidBody()
    {
        Player.Instance.GetComponent<SpringJoint2D>().enabled = true;
        Player.Instance.GetComponent<SpringJoint2D>().connectedBody = LinkController.Instance.GetClosestLink().GetComponent<Rigidbody2D>();
        Player.Instance.IsConnected = true;
        //Player.Instance.GetComponent<DistanceJoint2D>().enabled = true;
        //Player.Instance.GetComponent<DistanceJoint2D>().connectedBody = LinkController.Instance.GetClosestLink().GetComponent<Rigidbody2D>();
        RopeControlller.Instance.DrawRope(LinkController.Instance.GetClosestLink().transform.position);
    }

    public void BreakConnection()
    {
        SpringJoint2D springJoint = Player.Instance.GetComponent<SpringJoint2D>();
        springJoint.enabled = false;
        springJoint.connectedBody = null;
        Player.Instance.IsConnected = false;
        RopeControlller.Instance.DeleteRope();
        //Player.Instance.GetComponent<DistanceJoint2D>().enabled = false;
        //Player.Instance.GetComponent<DistanceJoint2D>().connectedBody = null;
    }
}
