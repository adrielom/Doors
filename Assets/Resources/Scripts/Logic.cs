using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Logic : Doors {
    public static int gO;
    public List<Sprite> charactersSprites;
    public List<GameObject> characterBackgrounds;
    public int highScore = 0;
    public Image gameOver;
    public Text currentScore;
    public Text lastScore;
    public Button menu;
    public Button playAgain;
    public Text gameOverT;
    public Text bestScore;
    public Button audioB;
    public Text score;
    public Sprite[] timeB = new Sprite[27];
    public Text pontuation;
    public float tempo = 26;
    public float bonusTime;
    public int selectedDoor;
    public int points = 0;
    public Sprite openDoor, closedDoor;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject bar;


    void Awake () {
        gO = 0;
        applyCharacter ();
        Randomize ();
        tempo = 26;
        correctAnswer = false;
        wrongDoor = false;
        pontuation.text = points.ToString();
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }
	
	void Update () {
        pontuation.text = points.ToString();
        Timer();
        TimeBar();
        if (correctAnswer == true)
        {
            StartCoroutine (RespondSystem ());
        }
        if (wrongDoor == true) {
            GameOver();

        }
	}

    public void applyCharacter() {
        if (CharacterSelect.characterID > charactersSprites.Count - 1) {
            int charRandom = Random.Range (0, charactersSprites.Count);
            openDoor = charactersSprites [charRandom];
            Instantiate (characterBackgrounds[charRandom], characterBackgrounds [charRandom].transform.position, Quaternion.identity);
        } else {
            openDoor = charactersSprites [CharacterSelect.characterID];
            Instantiate (characterBackgrounds [CharacterSelect.characterID], characterBackgrounds [CharacterSelect.characterID].transform.position, Quaternion.identity);
        }

        
    }

    public void Timer() {
        
        if (tempo >= 26)
            tempo = 26;
        if (tempo <= 0) {
            GameOver();
        } else {
            tempo -= Time.deltaTime * 4;
        }
    }
    
    public void Randomize(){

        selectedDoor = Random.Range(1, 4);

        switch (selectedDoor)
        {
            case 1:
                door1.GetComponent<SpriteRenderer>().sprite = openDoor;
                door1.tag = "Aberto";
                break;
            case 2:
                door2.GetComponent<SpriteRenderer>().sprite = openDoor;
                door2.tag = "Aberto";

                break;
            case 3:
                door3.GetComponent<SpriteRenderer>().sprite = openDoor;
                door3.tag = "Aberto";
                break;
          
        }
    }

    public void ResetSprites(){
        door1.GetComponent<SpriteRenderer>().sprite = closedDoor;
        door1.tag = "Fechado";
        door2.GetComponent<SpriteRenderer>().sprite = closedDoor;
        door2.tag = "Fechado";
        door3.GetComponent<SpriteRenderer>().sprite = closedDoor;
        door3.tag = "Fechado";

    }

    public void TimeBar() {
        bar.GetComponent<SpriteRenderer>().sprite = timeB[(int)tempo];
    }

    public void CheckBestScore() {
        if(points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetInt("highScore", points);
            PlayerPrefs.Save();
        }
    }

    public void CheckAchievements () {
        // Conquista de 50 pontos
        if (PlayerPrefs.GetInt("highScore") >= 50) {
            Social.ReportProgress ("CgkIso-F-qQIEAIQAw", 100.0f, (bool success) => {
                // handle success or failure
            });
        }

        //Conquista de 100 pontos
        if (PlayerPrefs.GetInt ("highScore") >= 100) {
            Social.ReportProgress ("CgkIso-F-qQIEAIQBA", 100.0f, (bool success) => {
                // handle success or failure
            });
        }

        //Conquista de 150 pontos
        if (PlayerPrefs.GetInt ("highScore") >= 150) {
            Social.ReportProgress ("CgkIso-F-qQIEAIQBQ", 100.0f, (bool success) => {
                // handle success or failure
            });
        }

        //Conquista de 200 pontos
        if (PlayerPrefs.GetInt ("highScore") >= 200) {
            Social.ReportProgress ("CgkIso-F-qQIEAIQBg", 100.0f, (bool success) => {
                // handle success or failure
            });
        }

        //Conquista de 250 pontos
        if (PlayerPrefs.GetInt ("highScore") >= 250) {
            Social.ReportProgress ("CgkIso-F-qQIEAIQBw", 100.0f, (bool success) => {
                // handle success or failure
            });
        }
    }


    public void GameOver()
    {
        if (gO == 1) {
            gO = 2;
        }
        else if (gO != 3){
            gO = 1;
        }
        gameOver.enabled = true;
        gameOverT.enabled = true;
        score.enabled = true;
        bestScore.enabled = true;
        currentScore.enabled = true;
        lastScore.text = points.ToString();
        lastScore.enabled = true;
        bestScore.text = highScore.ToString();
       // Debug.Log(highScore);
        menu.image.enabled = true;
        menu.enabled = true;
        playAgain.enabled = true;
        audioB.enabled = false;
        playAgain.image.enabled = true;
        audioB.image.enabled = false;
        pontuation.enabled = false;
        door1.GetComponent<Collider2D>().enabled = false;
        door2.GetComponent<Collider2D>().enabled = false;
        door3.GetComponent<Collider2D>().enabled = false;
        CheckBestScore ();
        CheckAchievements ();
       
        
    }

    IEnumerator RespondSystem() {
        yield return new WaitForEndOfFrame ();
        ResetSprites ();
        Randomize ();
        tempo += 1.5f;
        points++;
        correctAnswer = false;

    }


}
