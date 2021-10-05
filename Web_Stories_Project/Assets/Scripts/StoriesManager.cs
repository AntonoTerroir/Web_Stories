using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Tables;

public class StoriesManager : MonoBehaviour
{
    public Story[] stories;
    public GameObject storyPrefab;
    public GameObject panel;

    private void Start()
    {
        for (int i = 0; i < stories.Length; i++)
        {
            GameObject storyUI = Instantiate(storyPrefab, transform.position, Quaternion.identity) as GameObject;
            storyUI.transform.SetParent(panel.transform);
            StoryUIReference storyUIRef = storyUI.GetComponent<StoryUIReference>();
            storyUIRef.titleLocalEvent.StringReference.SetReference(stories[i].titleLocal.TableReference, stories[i].titleLocal.TableEntryReference);
            storyUIRef.creatorText.text = ("[" + stories[i].creator + "]");
            storyUIRef.iconImage.sprite = stories[i].icon;
            int storyIndex = i + 1;
            storyUIRef.storyNumberText.text = storyIndex.ToString();
            storyUIRef.sceneIndex = stories[i].sceneID;
        }
    }
}
