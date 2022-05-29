using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "MyScriptable/Create PopUpStory")]
public class PopUpStoryScritable : ScriptableObject
{
    public string storyName;
    public Sprite topUpImage;
    [SerializeField, MultilineAttribute (2)]
    public string story;
    [SerializeField, MultilineAttribute (5)]
    public string storyDetails;
}
