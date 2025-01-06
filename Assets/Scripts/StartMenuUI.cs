using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{

    //public Text menuHighScoreText;
    public TMP_Text highScoreText;
    public TMP_InputField playerNameInput;

    public GameObject highScoreManager;
    public HighScoreTracker highScoreTracker;
    public int highScoreStatic;
    public string highScoreName;
    private string highScoreTextUpdate;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        highScoreTracker = GameObject.Find("High Score Manager").GetComponent<HighScoreTracker>();
        highScoreStatic = highScoreTracker.highScore;
        highScoreName = highScoreTracker.highScoreplayerName;
        highScoreTextUpdate = "High Score: " + highScoreStatic + " Name: " + highScoreName;
        highScoreText.text = highScoreTextUpdate;
        playerNameInput.onEndEdit.AddListener(NameInput);

        //use this to clean up saved highscores
        //highScoreTracker.SaveHighScore(0, "");

    }

    void NameInput(string name)
    {
        highScoreTracker.playerName = name;
        
        //Debug.Log("Name is " + highScoreTracker.playerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }


}
