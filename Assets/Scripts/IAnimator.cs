using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimator
{
    public void StartAnimation();
    public void StopAnimation();
}

public class RunAnimation : IAnimator
{
    public void StartAnimation()
    {
        Player.Instance.GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(Player.Instance.GetComponent<Rigidbody2D>().velocity.x));
        Player.Instance.GetComponent<Animator>().SetBool("IsOnGround", Player.Instance.IsJumpable);
    }

    public void StopAnimation()
    {
        
    }
}

public class JumpAnimation : IAnimator
{
    public void StartAnimation()
    {
        Player.Instance.GetComponent<Animator>().SetTrigger("Jump");
    }

    public void StopAnimation()
    {
        
    }
}

public class GrabAnimation : IAnimator
{
    public void StartAnimation()
    {
        Player.Instance.GetComponent<Animator>().SetBool("IsConnected", true);
    }

    public void StopAnimation()
    {
        Player.Instance.GetComponent<Animator>().SetBool("IsConnected", false);
    }
}
