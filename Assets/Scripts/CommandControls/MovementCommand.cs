using System;
using UnityEngine;

#region MoveRightClass
public class MoveRight : ICommand
{
    public void Execute()
    {
        SetIsFacingRight();
        if (!Player.Instance.IsConnected) 
        {
            Player.Instance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Player.Instance.SpeedMultiplier * Time.deltaTime, ForceMode2D.Force);
            if (Player.Instance.GetComponent<Rigidbody2D>().velocity.magnitude > Player.Instance.MaxSpeed)
            {
                Player.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(Player.Instance.MaxSpeed, Player.Instance.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }

    private void SetIsFacingRight()
    {
        if (!Player.Instance.IsFacingRight)
        {
            Player.Instance.IsFacingRight = true;
            if (!Player.Instance.IsConnected)
            {
                Player.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, Player.Instance.GetComponent<Rigidbody2D>().velocity.y);
            }
            MovementController.Instance.Flip();
        }
    }
}
#endregion

#region MoveLeftClass
public class MoveLeft : ICommand
{
    public void Execute()
    {
        SetIsFacingRight();

        if (!Player.Instance.IsConnected)
        {
            Player.Instance.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Player.Instance.SpeedMultiplier * Time.deltaTime, ForceMode2D.Force);
            if (Player.Instance.GetComponent<Rigidbody2D>().velocity.x < -Player.Instance.MaxSpeed)
            {
                Player.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(-Player.Instance.MaxSpeed, Player.Instance.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }

    private void SetIsFacingRight()
    {
        if (Player.Instance.IsFacingRight)
        {
            Player.Instance.IsFacingRight = false;
            if (!Player.Instance.IsConnected)
            {
                Player.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.1f, Player.Instance.GetComponent<Rigidbody2D>().velocity.y);
            }
            MovementController.Instance.Flip();
        }
    }
}
#endregion

#region JumpClass
public class Jump : ICommand
{
    public void Execute()
    {
        if (Player.Instance.IsJumpable)
        {
            Player.Instance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Player.Instance.JumpMultiplier, ForceMode2D.Impulse);
            SoundEffectController.Instance.JumpSoundEffect();
        }
        else
        {
            return;
        }
    }
}

    #endregion
