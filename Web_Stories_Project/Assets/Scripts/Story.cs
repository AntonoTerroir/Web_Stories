using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Story", menuName = "Story")]
public class Story : ScriptableObject
{
    public string title = "";
    public string creator = "";

    public Sprite icon;

    public int sceneID;
}
