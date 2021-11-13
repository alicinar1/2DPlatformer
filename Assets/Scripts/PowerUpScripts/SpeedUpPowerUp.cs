using UnityEngine;
using UnityEngine.UI;

public class SpeedUpPowerUp : MonoSingleton<SpeedUpPowerUp>, IPowerUpController
{
    [SerializeField] private float speedLimit = 50f;
    private int powerUpCount = 0;
    public int PowerUpCount
    {
        get
        {
            return powerUpCount;
        }

        set
        {
            if (value == -1)
            {
                powerUpCount -= 1;
            }
            else if (value == 1)
            {
                powerUpCount += 1;
            }
        }
    }

    public void ExecutePowerUp(GameObject player)
    {
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();
        if (rigidbody2D.velocity.magnitude < speedLimit)
        {
            player.GetComponent<Rigidbody2D>().velocity += rigidbody2D.velocity;
        }
        else
        {
            return;
        }

    }

    public void SetButtonActieve(Button button)
    {
        button.interactable = true;
    }

    public void SetButtonInactieve(Button button)
    {
        button.interactable = false;
    }
}
