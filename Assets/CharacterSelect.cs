using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

    public Sprite [] characters = new Sprite [7]; //7 = random

    public static int characterID = 0;
    public int character = 0;
    SpriteRenderer sr;
    
    void Start () {
        sr = this.GetComponent<SpriteRenderer> ();
        sr.sprite = characters [characterID];
    }

    void OnMouseDown () {
        if (characterID >= characters.Length - 1) {
            characterID = 0;
            sr.sprite = characters [characterID];
        } else {
            characterID++;
            sr.sprite = characters [characterID];
        }
        character = characterID;
    }

    public void MinusCharacter () {        
        if (characterID <= 0) {
            characterID = characters.Length - 1;
            sr.sprite = characters [characterID];
        } else {
            characterID--;
            sr.sprite = characters [characterID];
        }
    }

    public void PlusCharacter () {
        if (characterID >= characters.Length - 1) {
            characterID = 0;
            sr.sprite = characters [characterID];
        } else {
            characterID++;
            sr.sprite = characters [characterID];
        }
    }
}
