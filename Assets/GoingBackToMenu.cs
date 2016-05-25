using UnityEngine;
using System.Collections;

public class GoingBackToMenu : MonoBehaviour {

    public GameObject creditsMenu;

    public void CreditsFunction(bool active) {
        if (active) {
            creditsMenu.SetActive (!active);
        } else {
            creditsMenu.SetActive (!active);
        }
    }
}
