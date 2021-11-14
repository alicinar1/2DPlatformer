using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask[] ground = new LayerMask[2];
    [SerializeField] private InputController inputController;
    [SerializeField] private SpringJointController springJointController;
    

    private Rigidbody2D playerRigidBody;

    private BoxCollider2D boxCollider;
    private bool isFacingRight = true;

    private float highGravity;
    private float lowGravity;
    private bool isConnected;
    private bool isJumpable;
    private bool isFalling;

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
        CheckJumpable();
        IsFalling();
        ManipulateDrag();
        IsMovingToRight();
        CheckConditions();
        BreakJointOnGround();
    }

    private void BreakJointOnGround()
    {
        if (isJumpable)
        {
            springJointController.BreakConnection();
        }        
    }

    private void CheckConditions()
    {
        isConnected = Player.Instance.IsConnected;
        isJumpable = Player.Instance.IsJumpable;
        isFalling = Player.Instance.IsFalling;
        isFacingRight = Player.Instance.IsFacingRight;
    }

    private void CheckJumpable()
    {
        Player.Instance.IsJumpable = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void Flip()
    {
        if (isFacingRight)
        {
            Player.Instance.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            Player.Instance.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        Debug.Log("Flip");
    }

    private void IsFalling()
    {
        if (playerRigidBody.velocity.y < 0)
        {
            Player.Instance.IsFalling = true;
        }
        else
        {
            Player.Instance.IsFalling = false;
        }
        CheckFalling();
    }

    private void CheckFalling()
    {
        if (isFalling && !isConnected)
        {
            SetGravityToHigh();
        }
        else
        {
            SetGravityToLow();
        }
    }

    public void SetGravityToHigh()
    {      
        playerRigidBody.gravityScale = highGravity;
    }

    public void SetGravityToLow()
    {
        playerRigidBody.gravityScale = lowGravity;
    }

    private void ManipulateDrag()
    {
        if (isConnected)
        {
            playerRigidBody.drag = 0f;
            playerRigidBody.angularDrag = 0f;
        }
        else
        {
            playerRigidBody.drag = 0.4f;
            playerRigidBody.angularDrag = 0.05f;
        }
    }

    public void BoostSwing(GameObject player)
    {
        if (isFacingRight)
        {
            playerRigidBody.velocity += new Vector2(5, 0);
        }
        else
        {
            playerRigidBody.velocity += new Vector2(-5, 0);
        }

    }

    private void IsMovingToRight()
    {
        if (playerRigidBody.velocity.x > 0)
        {
            Player.Instance.IsFacingRight = true;
        }
        else
        {
            Player.Instance.IsFacingRight = false;
        }

    }
}


//Old movement scripts
//public void MoveRight()
//{
//    isFacingRight = true;

//    if (!isConnected)
//    {
//        playerRigidBody.AddForce(Vector2.right * speedMultiplier * Time.deltaTime, ForceMode2D.Force);
//        if (playerRigidBody.velocity.x > maxSpeed)
//        {
//            playerRigidBody.velocity = new Vector2(maxSpeed, playerRigidBody.velocity.y);
//        }
//        Flip();
//        Debug.Log("Right");
//    }
//    else
//    {
//        return;
//    }

//}

//public void MoveLeft()
//{
//    isFacingRight = false;

//    if (!isConnected)
//    {
//        playerRigidBody.AddForce(Vector2.left * speedMultiplier * Time.deltaTime, ForceMode2D.Force);
//        if (playerRigidBody.velocity.x < -maxSpeed)
//        {
//            playerRigidBody.velocity = new Vector2(-maxSpeed, playerRigidBody.velocity.y);

//        }
//        Flip();
//        Debug.Log("Left");
//    }
//    else
//    {
//        return;
//    }
//}

//public void Jump()
//{
//    if (isJumpable)
//    {
//        playerRigidBody.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
//        Debug.Log("Jump");
//    }
//    else
//    {
//        return;
//    }
//}
