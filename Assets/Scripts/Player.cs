using UnityEngine;

public class Player : MonoSingleton<Player>
{
    [SerializeField] private PlayerScriptableObject playerScriptableObject;

    private float playerHealth;
    private float speedMultiplier;
    private float jumpMultiplier;
    private float highGravity;
    private float lowGravity;
    private float maxSpeed;

    [Header("Condition Checks")]
    [SerializeField] private bool isConnected;
    [SerializeField] private bool isFalling;
    [SerializeField] private bool isJumpable;
    [SerializeField] private bool isOnGround;

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
