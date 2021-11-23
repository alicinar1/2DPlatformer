using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Image image;
    [SerializeField] private CanvasGroup canvasGroup;

    //private float fadingDuration = 0.4f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DangerousGround")
        {
            Debug.Log("GameOver");
            ActieveGameOverScreen();
            StopInputController();
            StopPlayerAnimation();
        }
    }

    private void ActieveGameOverScreen()
    {
        gameOverCanvas.gameObject.SetActive(true);
        image.gameObject.SetActive(true);
        StartCoroutine(FadeOutCanvasGroup());
    }

    private IEnumerator FadeOutCanvasGroup()
    {
        float counter = 0f;

        while (canvasGroup.alpha < 1)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, counter);

            yield return null;
        }
    }

    private void StopInputController()
    {
        Player.Instance.gameObject.GetComponentInChildren<InputController>().enabled = false;
    }

    private void StopPlayerAnimation()
    {
        Player.Instance.GetComponent<Animator>().enabled = false;
    }

    //public void StopMovementController()
    //{

    //}
}
