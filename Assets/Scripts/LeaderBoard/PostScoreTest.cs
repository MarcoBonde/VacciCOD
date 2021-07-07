using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PostScoreTest : MonoBehaviour
{
    public static PostScoreTest Singleton;

    public string DreamloLink = "http://dreamlo.com/lb/R09SDeeExEySbpfXhc5Wyg-GQWggnGkkKU5i7yT2nyKw";
    public string PlayerName;
    public int Score;
    public List<ScoreEntry> ScoreBoardEntries = new List<ScoreEntry>();

    public UnityEvent ScoreBoardUpdatedEvent;
    private float timer;
    private int survivedSeconds;

    private void OnEnable()
    {
        Singleton = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        timer=0f;
        PlayerController.singleton.gameOverEvent.AddListener(gameOver);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        survivedSeconds = (int)timer;
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PostNewScore(PlayerName, survivedSeconds);
        }
        */
    }

    public void PostNewScore(string playerName, int score)
    {      
        StartCoroutine(PostScoreEnumerator(playerName, score));
        PlayerName = playerName;
        Score = score;
    }

    IEnumerator PostScoreEnumerator(string playerName, int score)
    {
        string myUrl = DreamloLink + "/add/" + playerName + "/" + score.ToString();
        using (WWW loadedWebsite = new WWW(myUrl))
        {
            yield return loadedWebsite;
            if (loadedWebsite.text.Contains("OK"))
            {
                print("Caricamento Completato");
            }
            StartCoroutine(GetScoreBoardEnumerator());
        }
    }

    IEnumerator GetScoreBoardEnumerator()
    {
        //Creating the URL to get the ScoreBoard
        string myUrl = DreamloLink + "/quote";
        //Cleaning UP old Values in the list (I forgot to do this during the lesson, this is why it was not working)
        ScoreBoardEntries.Clear();

        using (WWW loadedWebsite = new WWW(myUrl))
        {
            yield return loadedWebsite;
            string pageContent = loadedWebsite.text;
            string[] pageContentLines = pageContent.Split('\n');

            for (int i = 0; i < pageContentLines.Length; i++)
            {
                if (!string.IsNullOrEmpty(pageContentLines[i]))
                {
                    string[] lineContent = pageContentLines[i].Split(',');

                    string myPlayerName = QuotedStringCleanup(lineContent[0]);
                    int myScore = int.Parse(QuotedStringCleanup(lineContent[1]));

                    ScoreBoardEntries.Add(new ScoreEntry(myPlayerName, myScore));
                }
            }   
        }
        yield return new WaitForFixedUpdate();
        ScoreBoardUpdatedEvent.Invoke();
    }

    string QuotedStringCleanup(string rawString)
    {
        string tempString = rawString.Substring(1, rawString.Length - 2);
        return tempString;
    }
    public void gameOver()
    {
        PostNewScore(PlayerName, survivedSeconds);
    }
}

public class ScoreEntry
{
    public string PlayerName;
    public int PlayerScore;

    public ScoreEntry(string playerName,int playerScore)
    {
        PlayerName = playerName;
        PlayerScore = playerScore;
    }
}