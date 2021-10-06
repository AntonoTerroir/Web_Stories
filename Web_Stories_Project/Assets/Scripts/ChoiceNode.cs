using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Choice Node", menuName = "ChoiceNode")]
public class ChoiceNode : ScriptableObject
{
    public Sprite sprite;
    public Color backgroundColor;

    [TextArea(15, 20)]
    public string description = "";

    public LocalizedString descriptionLocal;

    public StoryNode nextStoryNode;
}
