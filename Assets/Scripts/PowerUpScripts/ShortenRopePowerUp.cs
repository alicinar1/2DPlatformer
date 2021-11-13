using UnityEngine;
using UnityEngine.UI;

public class ShortenRopePowerUp : MonoSingleton<ShortenRopePowerUp>, IPowerUpController
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
        SpringJoint2D springJoint = player.GetComponent<SpringJoint2D>();
        player.GetComponent<SpringJoint2D>().distance = (springJoint.distance * 0.5f);

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
