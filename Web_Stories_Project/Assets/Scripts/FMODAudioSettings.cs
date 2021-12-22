using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ce script permet de gérer des sliders de volumes
//Et une fonction pour réinitialiser les niveaux

public class FMODAudioSettings : MonoBehaviour
{
    private static FMODAudioSettings instance = null;
    public static FMODAudioSettings sharedInstance
    {

        //Accesseur automatique
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<FMODAudioSettings>();
            }
            return instance;
        }
    }

    //On utilise des VCA plutôt que des bus pour deux raisons
    //1: pouvoir controler plusieurs bus avec un VCA sans modifier la hiérarchie du mixer
    //2: pouvoir gérer indépendamment le volume souhaité par le joueur et les volumes gérés par le mixeur dynamique (avec les transitions et autres par exemple)

    //Chemin d acces aux vca dans la hierarchie du projet FMOD
    public string ambVCAPath = "vca:/Amb";
    public string musicVCAPath = "vca:/Music";
    public string sfxVCAPath = "vca:/SFX";
    
    //Reference aux objets VCA dans votre projet FMOD
    private FMOD.Studio.VCA ambVCA;
    private FMOD.Studio.VCA musicVCA;
    private FMOD.Studio.VCA sfxVCA;

    //Volumes de depart
    public float ambStartVol = 1f;
    public float musicStartVol = 1f;
    public float sfxStartVol = 1f;

    //Sliders gerant ces volumes dans le menu
    public Slider ambVolSlider;
    public Slider musicVolSlider;
    public Slider sfxVolSlider;

    private void Start()
    {
        //En premier lieu on lie les objets VCA à leur chemin d'acces dans FMOD pour que Unity sache quel objet utiliser
        ambVCA = FMODUnity.RuntimeManager.GetVCA(ambVCAPath);
        musicVCA = FMODUnity.RuntimeManager.GetVCA(musicVCAPath);
        sfxVCA = FMODUnity.RuntimeManager.GetVCA(sfxVCAPath);

        //On recupere le volume du VCA dans FMOD pour appliquer cette valeur au slider dans l'UI
        float masterVol;
        ambVCA.getVolume(out masterVol);
        ambVolSlider.value = masterVol;

        float musicVol;
        musicVCA.getVolume(out musicVol);
        musicVolSlider.value = musicVol;

        float sfxVol;
        sfxVCA.getVolume(out sfxVol);
        sfxVolSlider.value = sfxVol;
    }

    // Fonctions a appeler (EN MODE DYNAMIC FLOAT) dans le slider
    // Va prendre la valeur donnee par le slider pour l'appliquer au VCA dans FMOD
    public void SetAmbVol(float value)
    {
        ambVCA.setVolume(value);
    }

    public void SetMusicVol(float value)
    {
        musicVCA.setVolume(value);
    }

    public void SetSFXVol(float value)
    {
        sfxVCA.setVolume(value);
    }

    // Fonction a appeler sur un bouton pour remettre a zero les sliders de volume
    public void ResetVolumes()
    {
        // verifie qu'il y a bien un slider référencé pour chaque catégorie, sinon ne fait rien
        // remet les valeurs de chaque slider au volume de départ
        if(ambVolSlider != null)
        {
            ambVolSlider.value = ambStartVol;
        }

        if (musicVolSlider != null)
        {
            musicVolSlider.value = musicStartVol;
        }

        if (sfxVolSlider != null)
        {
            sfxVolSlider.value = sfxStartVol;
        }
    }
}
