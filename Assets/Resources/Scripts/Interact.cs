using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

    public static bool isAudioOn = true;
    public static string audioTag = "On";
    public AudioListener sons;   

    void Start () {
        sons = Camera.main.GetComponent<AudioListener> ();
        sons.enabled = isAudioOn;
    }

    public void TurnOnOffAudio(){
        if (isAudioOn)
        {
            MusicSingleton.Instance.GetComponent<AudioSource> ().Pause ();
            sons.enabled = false;
            isAudioOn = false;
            this.gameObject.tag = "Off";

        }
        else if (!isAudioOn)
        {
            MusicSingleton.Instance.GetComponent<AudioSource> ().Play ();
            sons.enabled = true;
            isAudioOn = true;
            this.gameObject.tag = "On";
        }
    }

    public void GoToMenu() {
        Application.LoadLevel("Menu");
    }

    public void LoadThisLevel()
    {
        Application.LoadLevel("Jogo");
    }

}
