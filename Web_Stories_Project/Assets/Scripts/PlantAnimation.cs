using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlantAnimation : MonoBehaviour
{
    public Image colorL;
    public Image colorR;
    public Image fullL;
    public Image fullR;

    public CanvasGroup buttonsCG;

    public Image sunflower;
    
    // Start is called before the first frame update
    void Start()
    {
        colorL.DOFade(0f, 0f);
        colorR.DOFade(0f, 0f);
        fullL.DOFade(0f, 0f);
        fullR.DOFade(0f, 0f);
        sunflower.DOFade(0f, 0f);

        buttonsCG.interactable = false;
        buttonsCG.blocksRaycasts = false;
        buttonsCG.alpha = 0f;

        StartPlantAnim();
    }

    public void StartPlantAnim()
    {
        colorL.DOFade(1f, 0f).SetDelay(2f);
        colorR.DOFade(1f, 0f).SetDelay(3f);
        fullL.DOFade(1f, 0f).SetDelay(4f);
        fullR.DOFade(1f, 0f).SetDelay(5f);
        sunflower.DOFade(1f, 0f).SetDelay(6f);
        colorL.DOFade(0f, 0f).SetDelay(4f);
        colorR.DOFade(0f, 0f).SetDelay(5f);
        
        buttonsCG.interactable = true;
        buttonsCG.blocksRaycasts = true;
        buttonsCG.DOFade(1f, 1f).SetDelay(5f);

        fullL.rectTransform.DOMoveX(-1200, 2f).SetEase(Ease.InSine).SetDelay(6f).SetRelative(true);
        fullR.rectTransform.DOMoveX(1200, 2f).SetEase(Ease.InSine).SetDelay(6f).SetRelative(true);

        //sunflower.rectTransform.DOMoveY(-250f, 1f).SetEase(Ease.OutSine).SetDelay(6f).SetRelative(true);
    }
}
