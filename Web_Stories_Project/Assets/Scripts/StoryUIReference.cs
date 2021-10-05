using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Localization.Components;
using UnityEngine.SceneManagement;

public class StoryUIReference : MonoBehaviour
{
    public LocalizeStringEvent titleLocalEvent;
    public TextMeshProUGUI creatorText;
    public TextMeshProUGUI storyNumberText;
    public Image iconImage;
    public int sceneIndex = 1;

    public void LaunchStoryScene()
    {
        FadeToBlack.sharedInstance.FadeOut();
        StartCoroutine(SceneLaunchTimer());
    }

    private IEnumerator SceneLaunchTimer()
    {
        yield return new WaitForSeconds(FadeToBlack.sharedInstance.speed + 0.1f);
        SceneManager.LoadScene(sceneIndex);
    }
}
