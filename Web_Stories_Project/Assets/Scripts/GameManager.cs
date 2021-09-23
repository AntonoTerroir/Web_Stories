using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public StoryNode firstStoryNode;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI storyDescriptionText;

    public TextMeshProUGUI choiceLeftDescriptionText;
    public Image choiceLeftImage;
    public Color choiceLeftColor;
    public Button choiceLeftButton;


    public TextMeshProUGUI choiceRightDescriptionText;
    public Image choiceRightImage;
    public Color choiceRightColor;
    public Button choiceRightButton;

    public StoryNode nextStoryNode;
    public StoryNode currentStoryNode;

    public GameObject conclusionUI;
    public GameObject choicesUI;

    public Image conclusionImage;

    private void Start()
    {
        if(firstStoryNode == null)
        {
            return;
        }

        conclusionUI.SetActive(false);
        choicesUI.SetActive(true);

        DisplayStoryNode(firstStoryNode);
    }

    public void DisplayStoryNode(StoryNode node)
    {
        currentStoryNode = node;
        
        titleText.text = node.title;
        storyDescriptionText.text = node.description;

        if (node.isConclusion)
        {
            conclusionUI.SetActive(true);
            choicesUI.SetActive(false);

            conclusionImage.sprite = node.conclusionSprite;

            return;
        }

        DisplayChoiceNodeLeft(node.choiceLeft);
        DisplayChoiceNodeRight(node.choiceRight);
    }

    public void DisplayChoiceNodeLeft(ChoiceNode node)
    {
        choiceLeftDescriptionText.text = node.description;
        choiceLeftImage.sprite = node.sprite;
        choiceLeftColor = node.backgroundColor;
    }

    public void DisplayChoiceNodeRight(ChoiceNode node)
    {
        choiceRightDescriptionText.text = node.description;
        choiceRightImage.sprite = node.sprite;
        choiceRightColor = node.backgroundColor;
    }

    public void MakeChoiceLeft()
    {
        //Transition
        nextStoryNode = currentStoryNode.choiceLeft.nextStoryNode;
        //Fin de transition
        DisplayStoryNode(nextStoryNode);
    }

    public void MakeChoiceRight()
    {
        //Transition
        nextStoryNode = currentStoryNode.choiceRight.nextStoryNode;
        //Fin de transition
        DisplayStoryNode(nextStoryNode);
    }
}
