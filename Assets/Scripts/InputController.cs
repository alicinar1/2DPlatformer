using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoSingleton<InputController>
{
    //[Header("Externals")]
    //[SerializeField] private SpringJointController springJoint;
    //[SerializeField] private MovementController movementController;
    ICommand rightArrow, leftArrow, upArrow;
    AnimationControl jump, anim;

    private void Start()
    {
        rightArrow = new MoveRight();
        leftArrow = new MoveLeft();
        upArrow = new Jump();

        anim = new AnimationControl();
    }

    private void Update()
    {
        CheckInput();
        anim.CheckVariables();
    }

    public void CheckInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightArrow.Execute();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftArrow.Execute();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upArrow.Execute();
            anim.JumpAnimation();
        }

        if (Input.GetKeyDown("space"))
        {
            if (!Player.Instance.IsConnected)
            {
                SpringJointController.Instance.SetConnectedRigidBody();
                anim.GrabAnimation();
            }
            else if (Player.Instance.IsConnected)
            {
                SpringJointController.Instance.BreakConnection();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && Player.Instance.IsConnected)
        {
            ShortenRopePowerUp.Instance.ExecutePowerUp(Player.Instance.gameObject);
            ShortenRopePowerUp.Instance.PowerUpCount = -1;
        }

        if (Input.GetKeyDown(KeyCode.W) && Player.Instance.IsConnected)
        {
            LengthenRopePowerUp.Instance.ExecutePowerUp(Player.Instance.gameObject);
            LengthenRopePowerUp.Instance.PowerUpCount = -1;
        }

        if (Input.GetKeyDown(KeyCode.E) && Player.Instance.IsConnected)
        {
            SpeedUpPowerUp.Instance.ExecutePowerUp(Player.Instance.gameObject);
            SpeedUpPowerUp.Instance.PowerUpCount = -1;
        }

        if (Input.GetKeyDown(KeyCode.R) && Player.Instance.IsConnected)
        {
            SlowDownPowerUp.Instance.ExecutePowerUp(Player.Instance.gameObject);
            SlowDownPowerUp.Instance.PowerUpCount = -1;
        }
    }
}
