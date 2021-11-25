using System;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    [SerializeField] private PlayerScriptableObject playerScriptableObject;

    #region Variables
    private float playerHealth;
    private float speedMultiplier;
    private float jumpMultiplier;
    private float highGravity;
    private float lowGravity;
    private float maxSpeed;
    #endregion

    #region Condition Check variables
    [Header("Condition Checks")]
    [SerializeField] private bool isConnected;
    [SerializeField] private bool isFalling;
    [SerializeField] private bool isJumpable;
    [SerializeField] private bool isOnGround;
    [SerializeField] private bool isFacingRight = true;
    #endregion

    #region Events
    public static event Action OnConnectedChanged;
    public static event Action OnJumpableChanged;
    public static event Action OnFallingChanged;
    #endregion

    #region Properties
    public float PlayerHealth
    {
        get
        {
            return playerHealth;
        }
    }

    public float SpeedMultiplier
    {
        get
        {
            return speedMultiplier;
        }
    }

    public float JumpMultiplier
    {
        get
        {
            return jumpMultiplier;
        }
    }

    public float HighGravity
    {
        get
        {
            return highGravity;
        }
    }

    public float LowGravity
    {
        get
        {
            return lowGravity;
        }
    }

    public float MaxSpeed
    {
        get
        {
            return maxSpeed;
        }
    }

    public bool IsConnected
    {
        get
        {
            return isConnected;
        }

        set
        {
            isConnected = value;
            IsConnectedChanged();
        }
    }

    public bool IsFalling
    {
        get
        {
            return isFalling;
        }

        set
        {
            isFalling = value;
            IsFallingChanged();
        }
    }

    public bool IsJumpable
    {
        get
        {
            return isJumpable;
        }

        set
        {
            isJumpable = value;
            IsJumpableChanged();
        }
    }

    public bool IsOnGround
    {
        get
        {
            return isOnGround;
        }

        set
        {
            isOnGround = value;
        }
    }
    public bool IsFacingRight 
    {
        get
        {
            return isFacingRight;
        }

        set
        {
            isFacingRight = value;
        }
    }

    public int CollectedCoins { get; set; }
    #endregion

    #region EventMethods
    private void IsConnectedChanged()
    {
        OnConnectedChanged?.Invoke();
    }

    private void IsFallingChanged()
    {
        OnFallingChanged?.Invoke();
    }
    
    private void IsJumpableChanged()
    {
        OnJumpableChanged?.Invoke();
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        CameraMovement.Instance.SetTrauma(collision.relativeVelocity.magnitude);
    }

    private void Start()
    {
        SetNPCInfo(playerScriptableObject);
    }

    public void SetNPCInfo(PlayerScriptableObject playerScriptableObject)
    {
        transform.tag = playerScriptableObject.tagOfPlayer;
        transform.name = playerScriptableObject.nameOfPlayer;
        playerHealth = playerScriptableObject.health;
        speedMultiplier = playerScriptableObject.speedMultiplier;
        jumpMultiplier = playerScriptableObject.jumpMultiplier;
        highGravity = playerScriptableObject.highGravity;
        lowGravity = playerScriptableObject.lowGravity;
        maxSpeed = playerScriptableObject.maxSpeed;
    }

}
