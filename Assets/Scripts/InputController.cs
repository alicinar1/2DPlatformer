using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoSingleton<InputController>
{
    //[Header("Externals")]
    //[SerializeField] private SpringJointController springJoint;
    //[SerializeField] private MovementController movementController;
    ICommand rightArrow, leftArrow, upArrow;
    IAnimator jump, run, grab;

    private void Start()
    {
        rightArrow = new MoveRight();
        leftArrow = new MoveLeft();
        upArrow = new Jump();

        jump = new JumpAnimation();
        run = new RunAnimation();
        grab = new GrabAnimation();
    }

    private void Update()
    {
        CheckInput();
    }

    public void CheckInput()
    {
        run.StartAnimation();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightArrow.Execute();
            run.StartAnimation();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftArrow.Execute();
            run.StartAnimation();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upArrow.Execute();
            jump.StartAnimation();
        }

        if (Input.GetKeyDown("space"))
        {
            if (!Player.Instance.IsConnected)
            {
                SpringJointController.Instance.SetConnectedRigidBody();
                grab.StartAnimation();
            }
            else if (Player.Instance.IsConnected)
            {
                SpringJointController.Instance.BreakConnection();
                grab.StopAnimation();
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
