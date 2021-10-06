using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Story Node", menuName = "StoryNode")]
public class StoryNode : ScriptableObject
{
    public string title = "";
    [TextArea(15, 20)]
    public string description = "";

    public LocalizedString descriptionLocal;

    public bool isConclusion = false;
    public Sprite conclusionSprite;

    public bool hasOneChoice = false;

    public ChoiceNode choiceLeft;
    public ChoiceNode choiceRight;
}
