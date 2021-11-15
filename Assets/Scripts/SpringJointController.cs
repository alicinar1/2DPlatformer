using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJointController : MonoBehaviour
{
    [SerializeField] private LinkController linkController;
    //private SpringJoint2D springJoint = new SpringJoint2D();

    //private void Start()
    //{
    //    SpringJoint2D springJoint = Player.Instance.GetComponent<SpringJoint2D>();
    //    springJoint.enabled = true;
    //}
    public void SetConnectedRigidBody()
    {
        SpringJoint2D springJoint = Player.Instance.GetComponent<SpringJoint2D>();
        springJoint.enabled = true;
        springJoint.connectedBody = linkController.GetClosestLink().GetComponent<Rigidbody2D>();
        //Player.Instance.GetComponent<SpringJoint2D>().connectedBody = springJoint.connectedBody;
        Player.Instance.IsConnected = true;
        Debug.Log("Setted");
    }

    public void BreakConnection()
    {
        SpringJoint2D springJoint = Player.Instance.GetComponent<SpringJoint2D>();
        springJoint.enabled = false;
        springJoint.connectedBody = null;
        Player.Instance.IsConnected = false;
        //Player.Instance.GetComponent<SpringJoint2D>().connectedBody = springJoint.connectedBody;
        Debug.Log("Breaked");
    }
}
