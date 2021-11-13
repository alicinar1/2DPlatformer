using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [Header("Externals")]
    [SerializeField] private SpringJointController springJoint;
    [SerializeField] private MovementController movementController;

    private void Update()
    {
        CheckInput();
    }

    public void CheckInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movementController.MoveRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementController.MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movementController.Jump();
        }

        if (Input.GetKeyDown("space"))
        {
            if (!Player.Instance.IsConnected)
            {
                springJoint.SetConnectedRigidBody(Player.Instance.gameObject);
            }
            else if (Player.Instance.IsConnected)
            {
                springJoint.BreakConnection(Player.Instance.gameObject);
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
