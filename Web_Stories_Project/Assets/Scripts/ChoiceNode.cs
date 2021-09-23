using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Choice Node", menuName = "ChoiceNode")]
public class ChoiceNode : ScriptableObject
{
    public Sprite sprite;
    public Color backgroundColor;

    [TextArea(15, 20)]
    public string description = "";

    public StoryNode nextStoryNode;
}
