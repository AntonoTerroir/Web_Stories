using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColumnManager : MonoBehaviour
{
    public RectTransform content;

    public string vcaPath = "vca:/master_vol_vca";
    public FMOD.Studio.VCA masterVolVCA;

    public Image speakerImage;
    public Sprite speakerNoVol;
    public Sprite speakerLoVol;
    public Sprite speakerFullVol;

    private bool isMuted = false;
    private float lastUnmutedVolume = 1f;

    public Slider slider;

    void Start()
    {
        masterVolVCA = FMODUnity.RuntimeManager.GetVCA(vcaPath);
        content.DOMoveX(-30, 0.3f).SetEase(Ease.InSine).SetDelay(2f);
    }

    public void SetGeneralVolume(float value)
    {
        isMuted = false;

        masterVolVCA.setVolume(value);

        lastUnmutedVolume = value;

        UpdateSpeakerSprite(value);
    }

    public float GetGeneralVolume()
    {
        float volume = slider.value;
        return volume;
    }

    public void SpeakerButton()
    {
        if (!isMuted)
        {
            Debug.Log("cété pas muté");
            lastUnmutedVolume = GetGeneralVolume();
            masterVolVCA.setVolume(0f);
            UpdateSpeakerSprite(0f);
            slider.SetValueWithoutNotify(0f);
            isMuted = true;
            return;
        }
        else if (isMuted)
        {
            Debug.Log("cété muté");
            masterVolVCA.setVolume(lastUnmutedVolume);
            UpdateSpeakerSprite(lastUnmutedVolume);
            slider.SetValueWithoutNotify(lastUnmutedVolume);
            isMuted = false;
            return;
        }
    }

    private void UpdateSpeakerSprite(float value)
    {
        if (value >= 0f && value < 0.3f)
        {
            speakerImage.sprite = speakerNoVol;
        }
        if (value >= 0.3f && value < 0.6f)
        {
            speakerImage.sprite = speakerLoVol;
        }
        if (value >= 0.6f && value <= 1f)
        {
            speakerImage.sprite = speakerFullVol;
        }
    }

    public void StartColumnHover()
    {
        content.DOKill();
        content.DOMoveX(30, 0.3f).SetEase(Ease.OutSine);
    }

    public void StopColumnHover()
    {
        content.DOKill();
        content.DOMoveX(-30, 0.3f).SetEase(Ease.InSine);
    }

    public void HomeButton()
    {
        FadeToBlack.sharedInstance.FadeOut();
        StartCoroutine(SceneLaunchTimer());
    }

    private IEnumerator SceneLaunchTimer()
    {
        yield return new WaitForSeconds(FadeToBlack.sharedInstance.speed + 0.1f);
        SceneManager.LoadScene(0);
    }
}
