using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Image image;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DangerousGround")
        {
            Debug.Log("GameOver");
            ActieveGameOverScreen();
            StopInputController();
        }
    }

    public void ActieveGameOverScreen()
    {
        gameOverCanvas.gameObject.SetActive(true);
        //float a = image.color.a;
        //    = Mathf.Lerp(0f, 0.7f, 0.02f);
    }

    public void StopInputController()
    {

    }

    //public void StopMovementController()
    //{

    //}
}
