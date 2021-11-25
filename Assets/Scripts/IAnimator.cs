using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationControl : MonoBehaviour
{
    public void CheckVariables()
    {
        Player.Instance.GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(Player.Instance.GetComponent<Rigidbody2D>().velocity.x));
        Player.Instance.GetComponent<Animator>().SetFloat("VerticalSpeed", Player.Instance.GetComponent<Rigidbody2D>().velocity.y);
        Player.Instance.GetComponent<Animator>().SetBool("IsOnGround", Player.Instance.IsJumpable);
        Player.Instance.GetComponent<Animator>().SetBool("IsConnected", Player.Instance.IsConnected);
    }
    public void JumpAnimation()
    {
        Player.Instance.GetComponent<Animator>().SetTrigger("Jump");
    }

    public void GrabAnimation()
    {
        Player.Instance.GetComponent<Animator>().SetTrigger("Grab");
        Debug.Log("Grab");
    }
}

