using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryTextBehaviour : MonoBehaviour
{
    public Text MyText;
    string victoryString = "Complimenti sei quello che è sopravvisuto più a lungo! Sei sopravvissuto: ";
    string lossString = "Sei morto! Sei sopravvissuto: ";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WriteScore();
    }

    void WriteScore() {
        if (PostScoreTest.Singleton.ScoreBoardEntries.Count > 1)
        {
            if (PostScoreTest.Singleton.ScoreBoardEntries[0].PlayerName == PostScoreTest.Singleton.PlayerName)
            {
                MyText.text = victoryString + secondsToMinutes(PostScoreTest.Singleton.ScoreBoardEntries[0].PlayerScore);
            }
            else
            {
                MyText.text = lossString + secondsToMinutes(PostScoreTest.Singleton.Score) + "\n Il campione è sopravvissuto: "+secondsToMinutes(PostScoreTest.Singleton.ScoreBoardEntries[0].PlayerScore) + "\nProva a raggiungerlo!";
            }
        }
    }

    string secondsToMinutes(int seconds) {
        int minutes = 0;
        if (seconds > 59) {
            minutes = seconds / 60;
            seconds = seconds % 60;
        }
        

        return minutes +" Minuti e "+seconds +" secondi!";
    }
}
