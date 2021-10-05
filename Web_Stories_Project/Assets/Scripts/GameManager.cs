using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public StoryNode firstStoryNode;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI storyDescriptionText;

    public TextMeshProUGUI choiceLeftDescriptionText;
    public Image choiceLeftImage;
    public Color choiceLeftColor;
    public Button choiceLeftButton;

    public TextMeshProUGUI choiceCenterDescriptionText;
    public Image choiceCenterImage;
    public Color choiceCenterColor;
    public Button choiceCenterButton;

    public TextMeshProUGUI choiceRightDescriptionText;
    public Image choiceRightImage;
    public Color choiceRightColor;
    public Button choiceRightButton;

    public StoryNode nextStoryNode;
    public StoryNode currentStoryNode;

    public GameObject conclusionUI;
    public GameObject choicesUI;
    public GameObject choiceL;
    public GameObject choiceR;
    public GameObject choiceC;

    public Image conclusionImage;

    public TransitionManager transitionManager;

    private static GameManager instance = null;
    public static GameManager sharedInstance
    {

        //Accesseur automatique
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        transitionManager.gameObject.SetActive(true);
        
        FadeToBlack.sharedInstance.FadeIn();

        if (firstStoryNode == null)
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

        if (node.hasOneChoice)
        {
            DisplayChoiceNodeCenter(node.choiceLeft);
            
            return;
        }

        DisplayChoiceNodeLeft(node.choiceLeft);
        DisplayChoiceNodeRight(node.choiceRight);
    }

    public void DisplayChoiceNodeLeft(ChoiceNode node)
    {
        choiceC.SetActive(false);
        choiceL.SetActive(true);
        choiceR.SetActive(true);

        choiceLeftDescriptionText.text = node.description;
        choiceLeftImage.sprite = node.sprite;
        choiceLeftColor = node.backgroundColor;
    }

    public void DisplayChoiceNodeRight(ChoiceNode node)
    {
        choiceC.SetActive(false);
        choiceL.SetActive(true);
        choiceR.SetActive(true);

        choiceRightDescriptionText.text = node.description;
        choiceRightImage.sprite = node.sprite;
        choiceRightColor = node.backgroundColor;
    }

    public void DisplayChoiceNodeCenter(ChoiceNode node)
    {
        choiceC.SetActive(true);
        choiceL.SetActive(false);
        choiceR.SetActive(false);

        choiceCenterDescriptionText.text = node.description;
        choiceCenterImage.sprite = node.sprite;
        choiceCenterColor = node.backgroundColor;
    }

    public void MakeChoiceLeft()
    {
        StartCoroutine(ChoiceLeftStructure());
    }

    private IEnumerator ChoiceLeftStructure()
    {
        transitionManager.StartTransition();
        yield return new WaitForSeconds(transitionManager.speedTransition);
        nextStoryNode = currentStoryNode.choiceLeft.nextStoryNode;
        DisplayStoryNode(nextStoryNode);
        transitionManager.StopTransition();
    }

    public void MakeChoiceRight()
    {
        StartCoroutine(ChoiceRightStructure());
    }

    private IEnumerator ChoiceRightStructure()
    {
        transitionManager.StartTransition();
        yield return new WaitForSeconds(transitionManager.speedTransition);
        nextStoryNode = currentStoryNode.choiceRight.nextStoryNode;
        DisplayStoryNode(nextStoryNode);
        transitionManager.StopTransition();
    }

    public void MenuButton()
    {
        StartCoroutine(MenuStructure());
    }

    public void ReplayButton()
    {
        StartCoroutine(ReplayStructure());
    }

    private IEnumerator ReplayStructure()
    {
        transitionManager.StartTransition();
        yield return new WaitForSeconds(transitionManager.speedTransition);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator MenuStructure()
    {
        FadeToBlack.sharedInstance.FadeOut();
        yield return new WaitForSeconds(FadeToBlack.sharedInstance.speed + 0.1f);
        SceneManager.LoadScene(0);
    }
}
