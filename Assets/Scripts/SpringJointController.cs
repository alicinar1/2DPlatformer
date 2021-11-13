using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJointController : MonoBehaviour
{
    [SerializeField] private Player player;
    private void Update()
    {
        LowLightOtherLinks();
    }

    public void SetConnectedRigidBody(GameObject gameObject)
    {
        SpringJoint2D springJoint = gameObject.GetComponent<SpringJoint2D>();
        springJoint.enabled = true;
        springJoint.connectedBody = GetClosestLink().GetComponent<Rigidbody2D>();
        player.IsConnected = true;
        Debug.Log("Setted");
    }

    public void BreakConnection(GameObject gameObject)
    {
        SpringJoint2D springJoint = gameObject.GetComponent<SpringJoint2D>();
        springJoint.enabled = false;
        springJoint.connectedBody = null;
        player.IsConnected = false;
        Debug.Log("Breaked");
    }

    private Link GetClosestLink()
    {
        float distanceOfClosestLink = float.MaxValue;
        Link closestLink = null;

        foreach (Link currentLink in FindAllLinks())
        {
            float linkDistance = (currentLink.transform.position - player.gameObject.transform.position).sqrMagnitude;
            if (linkDistance < distanceOfClosestLink)
            {
                distanceOfClosestLink = linkDistance;
                closestLink = currentLink;
            }
        }

        return closestLink;
    }

    private Link[] FindAllLinks()
    {
        Link[] allLinks = GameObject.FindObjectsOfType<Link>();

        return allLinks;
    }

    private void HighlightClosestLink(Link closestLink)
    {
        Color highlightedColor = closestLink.GetComponent<SpriteRenderer>().color;
        highlightedColor.a = 1;
        closestLink.GetComponent<SpriteRenderer>().color = highlightedColor;
    }

    private void LowLightOtherLinks()
    {
        foreach (Link link in FindAllLinks())
        {
            Color highlightedColor = link.GetComponent<SpriteRenderer>().color;
            highlightedColor.a = 0.5f;
            link.GetComponent<SpriteRenderer>().color = highlightedColor;
        }

        HighlightClosestLink(GetClosestLink());
    }
}
