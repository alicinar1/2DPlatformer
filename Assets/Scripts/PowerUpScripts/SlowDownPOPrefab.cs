using UnityEngine;

public class SlowDownPOPrefab : MonoBehaviour, IPowerUp
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
        SlowDownPowerUp.Instance.PowerUpCount = 1;
    }

    public void SetActievePrefab()
    {
        throw new System.NotImplementedException();
    }

    public void SetInactievePowerUp()
    {
        throw new System.NotImplementedException();
    }
}
