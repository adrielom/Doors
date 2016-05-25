using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Doors : MonoBehaviour {

    AudioSource source;
    public static bool correctAnswer = false;
    public static bool wrongDoor = false;

    void Awake() {
        source = GetComponent<AudioSource>();
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseDown() {
        if (this.gameObject.tag == "Aberto")
        {
            correctAnswer = true;
            source.Play();
            StartCoroutine (BlinkSystem ());
        }
        else if (this.gameObject.tag == "Fechado") {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            wrongDoor = true;
           
        }
    }

    IEnumerator BlinkSystem () {
        this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
        yield return new WaitForEndOfFrame ();
        this.gameObject.GetComponent<Renderer> ().material.color = Color.white;

    }


}
