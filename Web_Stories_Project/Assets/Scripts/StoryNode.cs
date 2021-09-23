using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Story Node", menuName = "StoryNode")]
public class StoryNode : ScriptableObject
{
    public string title = "";
    [TextArea(15, 20)]
    public string description = "";

    public bool isConclusion = false;
    public Sprite conclusionSprite;

    public ChoiceNode choiceLeft;
    public ChoiceNode choiceRight;
}
