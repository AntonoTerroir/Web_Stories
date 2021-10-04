using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChoiceAnimation : MonoBehaviour
{
    public RectTransform rect;
    public bool loop = true;
    public float strength = 1.1f;
    public float speed = 0.5f;

    public void StartChoiceAnimation()
    {
        if (loop)
        {
            rect.DOScale(strength, speed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }
        else
        {
            rect.DOScale(strength, speed).SetEase(Ease.InSine).SetEase(Ease.OutBack);
        }
    }

    public void StopChoiceAnimation()
    {
        rect.DOKill();
        rect.DOScale(1.0f, 0.1f).SetEase(Ease.OutSine);
    }
}
