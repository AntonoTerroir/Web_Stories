using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChoiceAnimation : MonoBehaviour
{
    public Image backgroundImage;
    public Image blackScreenFade;

    public void StartChoiceAnimation()
    {
        backgroundImage.rectTransform.DOScale(1.1f, 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    public void StopChoiceAnimation()
    {
        backgroundImage.rectTransform.DOKill();
        backgroundImage.rectTransform.DOScale(1.0f, 0.1f).SetEase(Ease.OutSine);
    }
}
