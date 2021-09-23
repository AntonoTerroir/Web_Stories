using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Story Node", menuName = "StoryNode")]
public class StoryNode : ScriptableObject
{
    public string title = "Titre";
    public string description = "Description";

    public ChoiceNode choiceLeft;
    public ChoiceNode choiceRight;
    public StoryNode storyEnd;
}
