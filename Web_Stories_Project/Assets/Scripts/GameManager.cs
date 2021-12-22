using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Components;

public class GameManager : MonoBehaviour
{
    public StoryNode firstStoryNode;

    public TextMeshProUGUI titleText;
    public LocalizeStringEvent titleLocalEvent;
    public TextMeshProUGUI storyDescriptionText;
    public LocalizeStringEvent descriptionLocalEvent;

    public TextMeshProUGUI choiceLeftDescriptionText;
    public LocalizeStringEvent choiceLeftLocalEvent;
    public Image choiceLeftImage;
    public Color choiceLeftColor;
    public Button choiceLeftButton;

    public TextMeshProUGUI choiceCenterDescriptionText;
    public LocalizeStringEvent choiceCenterLocalEvent;
    public Image choiceCenterImage;
    public Color choiceCenterColor;
    public Button choiceCenterButton;

    public TextMeshProUGUI choiceRightDescriptionText;
    public LocalizeStringEvent choiceRightLocalEvent;
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
        
        //titleText.text = node.title;
        titleLocalEvent.StringReference.SetReference(node.titleLocal.TableReference, node.titleLocal.TableEntryReference);
        descriptionLocalEvent.StringReference.SetReference(node.descriptionLocal.TableReference, node.descriptionLocal.TableEntryReference);
        //storyDescriptionText.text = node.description;

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

        if (node.requiredCondition != null)
        {
            if (node.requiredCondition.completed)
            {
                if (node.changeChoiceLeftOnMetCondition)
                {
                    DisplayChoiceNodeLeft(node.alternativeChoiceLeft);
                    DisplayChoiceNodeRight(node.choiceRight);
                }
                else if (node.changeChoiceRightOnMetCondition)
                {
                    DisplayChoiceNodeLeft(node.choiceLeft);
                    DisplayChoiceNodeRight(node.alternativeChoiceRight);
                }
                else if (node.changeBothChoicesOnMetCondition)
                {
                    DisplayChoiceNodeLeft(node.alternativeChoiceLeft);
                    DisplayChoiceNodeRight(node.alternativeChoiceRight);
                }

                return;
            }
        }

        DisplayChoiceNodeLeft(node.choiceLeft);
        DisplayChoiceNodeRight(node.choiceRight);
    }

    public void DisplayChoiceNodeLeft(ChoiceNode node)
    {
        choiceC.SetActive(false);
        choiceL.SetActive(true);
        choiceR.SetActive(true);

        //choiceLeftDescriptionText.text = node.description;
        choiceLeftLocalEvent.StringReference.SetReference(node.descriptionLocal.TableReference, node.descriptionLocal.TableEntryReference);
        choiceLeftImage.sprite = node.sprite;
        choiceLeftColor = node.backgroundColor;
    }

    public void DisplayChoiceNodeRight(ChoiceNode node)
    {
        choiceC.SetActive(false);
        choiceL.SetActive(true);
        choiceR.SetActive(true);

        //choiceRightDescriptionText.text = node.description;
        choiceRightLocalEvent.StringReference.SetReference(node.descriptionLocal.TableReference, node.descriptionLocal.TableEntryReference);
        choiceRightImage.sprite = node.sprite;
        choiceRightColor = node.backgroundColor;
    }

    public void DisplayChoiceNodeCenter(ChoiceNode node)
    {
        choiceC.SetActive(true);
        choiceL.SetActive(false);
        choiceR.SetActive(false);

        //choiceCenterDescriptionText.text = node.description;
        choiceLeftLocalEvent.StringReference.SetReference(node.descriptionLocal.TableReference, node.descriptionLocal.TableEntryReference);
        choiceCenterImage.sprite = node.sprite;
        choiceCenterColor = node.backgroundColor;
    }

    public void MakeChoiceLeft()
    {
        StartCoroutine(ChoiceLeftStructure());
        if (currentStoryNode.choiceLeft.fulfillCondition != null)
        {
            currentStoryNode.choiceLeft.fulfillCondition.completed = true;
        }
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
        StartCoroutine(ChoiceLeftStructure());
        if (currentStoryNode.choiceRight.fulfillCondition != null)
        {
            currentStoryNode.choiceRight.fulfillCondition.completed = true;
        }
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
        Debug.Log("bah alors ?");
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
