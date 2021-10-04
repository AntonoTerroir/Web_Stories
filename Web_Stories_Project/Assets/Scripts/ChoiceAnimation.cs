using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChoiceAnimation : MonoBehaviour
{
    public RectTransform rect;
    public Image blackScreenFade;

    public void StartChoiceAnimation()
    {
        rect.DOScale(1.1f, 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    public void StopChoiceAnimation()
    {
        rect.DOKill();
        rect.DOScale(1.0f, 0.1f).SetEase(Ease.OutSine);
    }
}
