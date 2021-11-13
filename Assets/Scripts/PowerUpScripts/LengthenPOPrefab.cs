using UnityEngine;

public class LengthenPOPrefab : MonoBehaviour
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
            SetInactievePowerUp();
            Debug.Log("LengthenPowerUp!!");
        }
    }

    public void IncreasePowerUpCount()
    {
        LengthenRopePowerUp.Instance.PowerUpCount = 1;
    }

    public void SetActievePrefab()
    {
        this.gameObject.SetActive(true);
    }

    public void SetInactievePowerUp()
    {
        this.gameObject.SetActive(false);
    }
}
