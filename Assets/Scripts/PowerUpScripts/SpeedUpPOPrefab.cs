using UnityEngine;

public class SpeedUpPOPrefab : MonoBehaviour, IPowerUp
{
    [SerializeField] private PowerUpScriptableObject powerUpScriptableObject;
    private void Start()
    {
        SetPowerUp(powerUpScriptableObject);
    }
    public void SetPowerUp(PowerUpScriptableObject scriptableObject)
    {
        this.name = powerUpScriptableObject.nameOfPO;
        this.tag = powerUpScriptableObject.tagOfPO;
        this.GetComponent<SpriteRenderer>().color = powerUpScriptableObject.spriteColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IncreasePowerUpCount();
        }
    }

    public void IncreasePowerUpCount()
    {
        SpeedUpPowerUp.Instance.PowerUpCount = 1;
    }

    public void SetActievePrefab()
    {

    }

    public void SetInactievePowerUp()
    {
        throw new System.NotImplementedException();
    }
}
