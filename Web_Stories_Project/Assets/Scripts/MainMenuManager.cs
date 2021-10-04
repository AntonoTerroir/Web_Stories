using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuManager : MonoBehaviour
{
    public RectTransform main;
    public RectTransform stories;
    public RectTransform credits;

    public float transitionSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        stories.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        main.gameObject.SetActive(true);
    }    

    public void MainToStories()
    {
        stories.DOMoveY(-900, 0f).SetRelative(true);
        stories.gameObject.SetActive(true);
        stories.DOMoveY(900, transitionSpeed).SetEase(Ease.OutBack).SetRelative(true);
    }

    public void MainToCredits()
    {
        credits.DOMoveX(1200, 0f).SetRelative(true);
        credits.gameObject.SetActive(true);
        credits.DOMoveX(-1200, transitionSpeed).SetEase(Ease.OutBack).SetRelative(true);
    }

    public void CreditsToMain()
    {
        credits.DOMoveX(1200, transitionSpeed).SetEase(Ease.InSine).SetRelative(true);
        StartCoroutine(DeactivateCredits());
        credits.DOMoveX(-1200, 0f).SetRelative(true).SetDelay(transitionSpeed);
    }

    private IEnumerator DeactivateCredits()
    {
        yield return new WaitForSeconds(transitionSpeed);
        credits.gameObject.SetActive(false);
    }

    public void StoriesToMain()
    {
        stories.DOMoveY(-900, transitionSpeed).SetEase(Ease.InSine).SetRelative(true);
        StartCoroutine(DeactivateStories());
        stories.DOMoveY(900, 0f).SetRelative(true).SetDelay(transitionSpeed);
    }

    private IEnumerator DeactivateStories()
    {
        yield return new WaitForSeconds(transitionSpeed);
        stories.gameObject.SetActive(false);
    }
}
