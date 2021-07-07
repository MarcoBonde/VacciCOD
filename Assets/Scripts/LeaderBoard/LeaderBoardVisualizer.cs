using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardVisualizer : MonoBehaviour
{
    public RectTransform ContentBoxTransform;
    public RectTransform ScoreEntryPrefab;

    public List<GameObject> currentlyInstantiatedTexts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PostScoreTest.Singleton.ScoreBoardUpdatedEvent.AddListener(UpdateScoreVisualization);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void UpdateScoreVisualization()
    {
        int numberOfPlayerInBoard = PostScoreTest.Singleton.ScoreBoardEntries.Count;

        ContentBoxTransform.sizeDelta = new Vector2(ContentBoxTransform.sizeDelta.x, ScoreEntryPrefab.sizeDelta.y * numberOfPlayerInBoard);

        for (int i = 0; i < currentlyInstantiatedTexts.Count; i++)
        {
            Destroy(currentlyInstantiatedTexts[i]);
        }
        currentlyInstantiatedTexts.Clear();

        for (int i = 0; i < PostScoreTest.Singleton.ScoreBoardEntries.Count; i++)
        {
            RectTransform tempText = Instantiate(ScoreEntryPrefab, ContentBoxTransform);
            tempText.anchoredPosition = new Vector2(0, -(i * ScoreEntryPrefab.sizeDelta.y));
            tempText.GetComponent<Text>().text = PostScoreTest.Singleton.ScoreBoardEntries[i].PlayerName + " / " + PostScoreTest.Singleton.ScoreBoardEntries[i].PlayerScore.ToString();
            currentlyInstantiatedTexts.Add(tempText.gameObject);
        }
    }
}
