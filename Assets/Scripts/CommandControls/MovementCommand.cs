using UnityEngine;

public class MoveRight : ICommand
{
    public void Execute()
    {
        Player.Instance.IsFacingRight = true;

        if (!Player.Instance.IsConnected)
        {
            Player.Instance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Player.Instance.SpeedMultiplier * Time.deltaTime, ForceMode2D.Force);
            if (Player.Instance.GetComponent<Rigidbody2D>().velocity.x > Player.Instance.MaxSpeed)
            {
                Player.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(Player.Instance.MaxSpeed, Player.Instance.GetComponent<Rigidbody2D>().velocity.y);
            }
            Debug.Log("Right");
        }
        else
        {
            return;
        }
    }
}

public class MoveLeft : ICommand
{
    public void Execute()
    {
        Player.Instance.IsFacingRight = false;

        if (!Player.Instance.IsConnected)
        {
            Player.Instance.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Player.Instance.SpeedMultiplier * Time.deltaTime, ForceMode2D.Force);
            if (Player.Instance.GetComponent<Rigidbody2D>().velocity.x < -Player.Instance.MaxSpeed)
            {
                Player.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(-Player.Instance.MaxSpeed, Player.Instance.GetComponent<Rigidbody2D>().velocity.y);

            }
            Debug.Log("Left");
        }
        else
        {
            return;
        }
    }
}

public class Jump : ICommand
{
    public void Execute()
    {
        if (Player.Instance.IsJumpable)
        {
            Player.Instance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Player.Instance.JumpMultiplier, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }
        else
        {
            return;
        }
    }
}
