using UnityEngine;
using UnityEngine.UI;

public interface IPowerUpController
{
    public int PowerUpCount { get; set; }
    public abstract void ExecutePowerUp(GameObject player);
    public abstract void SetButtonActieve(Button button);
    public abstract void SetButtonInactieve(Button button);
}
