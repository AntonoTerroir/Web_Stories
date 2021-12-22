using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class FMODButtonSound : MonoBehaviour
{
    // Script à attacher à votre bouton
    // Il suffit juste de lui ajouter des sons (si ce bouton a des sons spécifiques)
    // Sinon le script ira chercher les sons de boutons génériques spécifiés dans votre Sound Manager

    // Faut-il un son sur le clique et le passage de la souris ?
    [Header("Settings")]

    public bool hoverEnabled = true;
    public bool clickEnabled = true;
    public bool pressEnabled = false;

    [Header("FMOD Events")]

    public FMODUnity.EventReference clickEventRef;
    public FMODUnity.EventReference hoverEventRef;
    public FMODUnity.EventReference pressEventRef;

    private EventTrigger eventTrigger;

    private void Awake()
    {
        if (hoverEnabled)
        {
            // Si le bouton ne possede pas d'event trigger (qui permet de detecter le passage de la souris), on lui en ajoute un au lancement du jeu
            if (this.GetComponent<EventTrigger>() != null)
            {
                eventTrigger = this.GetComponent<EventTrigger>();
            }
            else
            {
                eventTrigger = gameObject.AddComponent<EventTrigger>() as EventTrigger;
            }
        }
    }

    private void Start()
    {
        // Si des fichiers sonores n'ont pas été spécifiés pour ce bouton, on va chercher sur le sound manager les sons génériques de boutons
        if (clickEventRef.IsNull && clickEnabled)
        {
            clickEventRef = FMODSoundManager.sharedInstance.genericClickSound;
        }

        if (hoverEventRef.IsNull && hoverEnabled)
        {
            hoverEventRef = FMODSoundManager.sharedInstance.genericHoverSound;
        }

        if (clickEnabled)
        {
            // On ajoute une action au bouton, qui se jouera lorsque l'on cliquera dessus, on lie cette action à notre fonction ONCLICK (plus bas)
            Button button = this.GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        if (hoverEnabled)
        {
            // On ajoute une action à l'event trigger, qui se jouera lorsque l'on passera la souris dessus, on lie cette action à notre fonction ONHOVER (plus bas)
            EventTrigger.Entry hoverEntry = new EventTrigger.Entry();
            hoverEntry.eventID = EventTriggerType.PointerEnter;
            hoverEntry.callback.AddListener((eventData) => { OnHover(); });
            eventTrigger.triggers.Add(hoverEntry);
        }

        if (pressEnabled)
        {
            EventTrigger.Entry pressEntry = new EventTrigger.Entry();
            pressEntry.eventID = EventTriggerType.PointerDown;
            pressEntry.callback.AddListener((eventData) => { OnPress(); });
            eventTrigger.triggers.Add(pressEntry);
        }
    }

    public void OnClick()
    {
        if (clickEnabled)
        {
            FMODUnity.RuntimeManager.PlayOneShot(clickEventRef);
        }
    }

    public void OnHover()
    {
        if (hoverEnabled && this.GetComponent<Button>().interactable)
        {
            FMODUnity.RuntimeManager.PlayOneShot(hoverEventRef);
        }
    }

    public void OnPress()
    {
        if (pressEnabled)
        {
            FMODUnity.RuntimeManager.PlayOneShot(pressEventRef);
        }
    }
}
