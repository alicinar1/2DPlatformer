using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoSingleton<MovementController>
{
    [SerializeField] private LayerMask jumpableGround;

    private Rigidbody2D playerRigidBody;
    private BoxCollider2D boxCollider;

    private float highGravity;
    private float lowGravity;

    private void Start()
    {
        SetPlayerProperties();
    }

    public void SetPlayerProperties()
    {
        playerRigidBody = Player.Instance.GetComponent<Rigidbody2D>();
        boxCollider = Player.Instance.GetComponent<BoxCollider2D>();
        highGravity = Player.Instance.HighGravity;
        lowGravity = Player.Instance.LowGravity;
    }

    private void Update()
    {
        CheckIsJumpable();
        CheckIsFalling();
    }
    #region CheckInstantConditions
    private void CheckIsJumpable()
    {
        Player.Instance.IsJumpable = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void CheckIsFalling()
    {
        if (playerRigidBody.velocity.y < 0)
        {
            Player.Instance.IsFalling = true;
        }
        else
        {
            Player.Instance.IsFalling = false;
        }
    }
    #endregion
    #region SetPhysicalConditions
    public void SetGravityToHigh()
    {
        if (!Player.Instance.IsJumpable)
        {
            playerRigidBody.gravityScale = highGravity;
        }
    }

    public void SetGravityToLow()
    {
        playerRigidBody.gravityScale = lowGravity;
    }

    public void SetHighDrag()
    {
        playerRigidBody.drag = 0.7f;
        playerRigidBody.angularDrag = 0.05f;
    }

    public void SetLowDrag()
    {
        playerRigidBody.drag = 0f;
        playerRigidBody.angularDrag = 0f;
    }
    #endregion

    public void Flip()
    {
        if (Player.Instance.IsFacingRight)
        {
            Player.Instance.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            Player.Instance.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        Debug.Log("Flip");
    }
         

    public void BoostSwing()
    {
        if (Player.Instance.IsFacingRight && Player.Instance.IsConnected)
        {
            playerRigidBody.velocity += new Vector2(5, 0);
        }
        else if (!Player.Instance.IsFacingRight && Player.Instance.IsConnected)
        {
            playerRigidBody.velocity += new Vector2(-5, 0);
        }  
    }
}


