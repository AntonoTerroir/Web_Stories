using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Choice Node", menuName = "ChoiceNode")]
public class ChoiceNode : StoryNode
{
    public Sprite sprite;
    public Color backgroundColor;

    public StoryNode nextStoryNode;
}
