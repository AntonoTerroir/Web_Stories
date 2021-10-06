using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitionManager : MonoBehaviour
{
    public CanvasGroup transitionOneCG;
    public float speedTransition = 1.0f;
    public int transNumber = 2;
    private int transID = 1;

    public RectTransform transitionTwo;

    private static TransitionManager instance = null;
    public static TransitionManager sharedInstance
    {

        //Accesseur automatique
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TransitionManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        transitionOneCG.blocksRaycasts = false;
    }

    public void StartTransition()
    {
        transID = Random.Range(1, transNumber);
        
        if(transID == 2)
        {
            transitionOneCG.blocksRaycasts = true;
            transitionOneCG.DOFade(1f, speedTransition);
        }

        else if(transID == 1)
        {
            transitionTwo.DOMoveX(-1800, 0).SetEase(Ease.InOutSine);
            transitionTwo.DOMoveX(750, speedTransition).SetEase(Ease.InOutSine);
        }
    }

    public void StopTransition()
    {
        if (transID == 2)
        {
            transitionOneCG.blocksRaycasts = true;
            transitionOneCG.DOFade(0f, speedTransition);
        }

        else if (transID == 1)
        {
            transitionTwo.DOKill();
            transitionTwo.DOMoveX(750, 0).SetEase(Ease.InOutSine);
            transitionTwo.DOMoveX(3000, speedTransition).SetEase(Ease.InOutSine);
        }   
    }
}
