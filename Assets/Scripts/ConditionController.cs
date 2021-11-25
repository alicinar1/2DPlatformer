using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionController : MonoBehaviour
{
    void Start()
    {
        Player.OnConnectedChanged += ChangeConnectionActions;
        Player.OnFallingChanged += ChangeFallingActions;
        Player.OnJumpableChanged += ChangeJumpableActions;
    }

    public void ChangeConnectionActions()
    {
        if (Player.Instance.IsConnected)
        {
            MovementController.Instance.BoostSwing();
            MovementController.Instance.SetGravityToLow();
            MovementController.Instance.SetLowDrag();
            LinkController.Instance.SetRedTexture();
        }
        else
        {
            MovementController.Instance.SetGravityToLow();
            MovementController.Instance.SetHighDrag();
            LinkController.Instance.SetGreenTexture();
        }
    }

    public void ChangeFallingActions()
    {
        if (Player.Instance.IsFalling && !Player.Instance.IsConnected)
        {
            MovementController.Instance.SetGravityToHigh();
        }
        else
        {
            MovementController.Instance.SetGravityToLow();
        }
    }

    public void ChangeJumpableActions()
    {
        if (Player.Instance.IsJumpable)
        {
            SpringJointController.Instance.BreakConnection();
            ParticleEffectSystem.Instance.StartJumpParticle();
        }
        else
        {
            ParticleEffectSystem.Instance.StartJumpParticle();
        }
    }
}
