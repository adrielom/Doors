using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayServicesManager : MonoBehaviour {

    public bool initializePlatform;
    public bool firstTimeAchievement;

	// Use this for initialization
	void Start () {

        if (initializePlatform) {
            PlayGamesPlatform.Activate ();
            Social.localUser.Authenticate ((bool success) => {
                //abrir entrada de log in no jogo
            });
        }
        if (firstTimeAchievement) {
            Social.ReportProgress ("CgkIso-F-qQIEAIQCA", 100.0f, (bool success) => {
                // handle success or failure
            });
        }            

    }
	
    public void CallAchievementsUI () {
        Social.ShowAchievementsUI ();
    }

}
