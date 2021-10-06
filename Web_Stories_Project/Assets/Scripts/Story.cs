using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Story", menuName = "Story")]
public class Story : ScriptableObject
{
    public string creator = "";

    public Sprite icon;

    public LocalizedString titleLocal;

    public int sceneID;
}
