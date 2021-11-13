using UnityEngine;
using UnityEngine.UI;

public class SlowDownPowerUp : MonoSingleton<SlowDownPowerUp>, IPowerUpController
{
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
        player.GetComponent<Rigidbody2D>().velocity -= (rigidbody2D.velocity / 2);
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
