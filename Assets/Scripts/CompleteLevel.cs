using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private Canvas LevelCompleteCanvas;
    //[SerializeField] private Image image;
    [SerializeField] private CanvasGroup canvasGroup;

    //private float fadingDuration = 0.4f;

    //private void OnTriggerEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("GameOver");
    //        ActieveGameOverScreen();
    //        StopInputController();
    //        StopPlayerAnimation();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("GameOver");
            ActieveGameOverScreen();
            StopInputController();
            StopPlayerAnimation();
            SoundEffectController.Instance.EndGameSoundEffect();
            this.enabled = false;
        }
    }

    private void ActieveGameOverScreen()
    {
        LevelCompleteCanvas.gameObject.SetActive(true);
        //image.gameObject.SetActive(true);
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
}
