using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeToBlack : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float speed = 2f;
    public float startDelay = 0.5f;
    // Start is called before the first frame update

    private static FadeToBlack instance = null;
    public static FadeToBlack sharedInstance
    {

        //Accesseur automatique
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<FadeToBlack>();
            }
            return instance;
        }
    }

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;
        FadeIn(startDelay);
    }

    public void FadeIn(float delay = 0f)
    {
        canvasGroup.DOKill();
        canvasGroup.DOFade(0f, speed).SetDelay(delay);
    }

    public void FadeOut()
    {
        canvasGroup.DOKill();
        canvasGroup.DOFade(1f, speed);
    }
}
