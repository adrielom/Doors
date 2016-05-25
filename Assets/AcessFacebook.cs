using UnityEngine;
using System.Collections;

public class AcessFacebook : MonoBehaviour {

    public int facebookID;
    	
    public void openFacebook () {
        Application.OpenURL("fb://page/" + facebookID);
    }

}
