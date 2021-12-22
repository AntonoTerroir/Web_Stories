using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODSoundManager : MonoBehaviour
{
    private static FMODSoundManager instance = null;
    public static FMODSoundManager sharedInstance
    {

        //Accesseur automatique
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<FMODSoundManager>();
            }
            return instance;
        }
    }

    [Header("UI Events")]

    public FMODUnity.EventReference genericClickSound;
    public FMODUnity.EventReference genericHoverSound;

    [Header("MUS Events")]

    public FMODUnity.EventReference musMainLoop;
    private FMOD.Studio.EventInstance musMainLoopInstance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        /*musMainLoopInstance = FMODUnity.RuntimeManager.CreateInstance(musMainLoop);
        musMainLoopInstance.setParameterByName("music_state_param", 0);
        musMainLoopInstance.start();*/
    }

    public void SetMusicState(float value)
    {
        musMainLoopInstance.setParameterByName("music_state_param", value);
    }
}
