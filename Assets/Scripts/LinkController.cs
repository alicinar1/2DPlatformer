using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkController : MonoSingleton<LinkController>
{
    [SerializeField] private Sprite greenSprite;
    [SerializeField] private Sprite redSprite;

    private Link[] allLinks;

    private void Start()
    {
        FindAllLinks();
    }

    private void Update()
    {
        LowLightOtherLinks();
        //ChangeLinkColor();
    }

    private void FindAllLinks()
    {
        allLinks = GameObject.FindObjectsOfType<Link>();
    }

    public Link GetClosestLink()
    {
        float distanceOfClosestLink = float.MaxValue;
        Link closestLink = null;

        foreach (Link currentLink in allLinks)
        {
            float linkDistance = (currentLink.transform.position - Player.Instance.transform.position).sqrMagnitude;
            if (linkDistance < distanceOfClosestLink)
            {
                distanceOfClosestLink = linkDistance;
                closestLink = currentLink;
            }
        }

        return closestLink;
    }

    private void HighlightClosestLink(Link closestLink)
    {
        Color highlightedColor = closestLink.GetComponent<SpriteRenderer>().color;
        highlightedColor.a = 1;
        closestLink.GetComponent<SpriteRenderer>().color = highlightedColor;
    }

    private void LowLightOtherLinks()
    {
        foreach (Link link in allLinks)
        {
            Color highlightedColor = link.GetComponent<SpriteRenderer>().color;
            highlightedColor.a = 0.5f;
            link.GetComponent<SpriteRenderer>().color = highlightedColor;
        }

        HighlightClosestLink(GetClosestLink());
    }

    //public void ChangeLinkColor()
    //{
    //    if (Player.Instance.IsConnected)
    //    {
    //    }
    //    else
    //    {
    //    }
    //}

    public void SetGreenTexture()
    {
        GetClosestLink().GetComponent<SpriteRenderer>().sprite = greenSprite;

    }

    public void SetRedTexture()
    {
        GetClosestLink().GetComponent<SpriteRenderer>().sprite = redSprite;

    }
}
