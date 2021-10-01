using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BackgroundAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public Image imageTop;
    public Image imageMiddle;
    public Image imageBottom;
    public Image[] images;

    public float timeToNextAnim = 3.0f;
    public float randomDelta = 2.0f;

    public float speed = 4.0f;
    public float randomSpeedDelta = 1.0f;

    public float startPos;
    public float endPos;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < images.Length; i++)
        {
            StartCoroutine(CountdownAnimation(images[i]));
            images[i].rectTransform.DOScale(1.1f, Random.Range(1.8f, 3f)).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetRelative(false);
            images[i].rectTransform.DORotate(new Vector3(0, 0, 1), 20f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Incremental).SetRelative(false);
        }
    }

    private IEnumerator CountdownAnimation(Image image)
    {
        PickRandomSprite(image);
        float timer = timeToNextAnim + Random.Range(randomDelta * -1, randomDelta);
        yield return new WaitForSeconds(timer);
        float animSpeed = speed + Random.Range(randomSpeedDelta * -1, randomSpeedDelta);
        StartAnimation(image, animSpeed);
        yield return new WaitForSeconds(animSpeed + 1);
        image.rectTransform.DOMoveX(startPos, 0);
        image.rectTransform.DOMoveY(Random.Range(100, 500), 0);
        RestartAnimation(image);
    }

    private void StartAnimation(Image image, float animationSpeed)
    {
        image.rectTransform.DOMoveX(endPos, animationSpeed);
        image.rectTransform.DOMoveY(Random.Range(-400, 400), animationSpeed).SetRelative(true);
    }

    private void PickRandomSprite(Image image)
    {
        int randomInt = Random.Range(0, sprites.Length);
        Sprite randomSprite = sprites[randomInt];
        image.sprite = randomSprite;
    }

    private void RestartAnimation(Image image)
    {
        StartCoroutine(CountdownAnimation(image));
    }
}
