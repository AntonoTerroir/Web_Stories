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
        stories.DOMoveY(900, 2f).SetEase(Ease.InOutSine).SetRelative(true);
    }
}
