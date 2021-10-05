using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField PlayerNameText;
    [SerializeField] TextMeshProUGUI BestScoreText;

    private string displayBestPlayer;
    private string playerName;
    private int displayBestScore;
    // Start is called before the first frame update
    void Start()
    {
        DisplayBestScore();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        DataPersistence.Instance.StoreName(playerName);
    }

    public void Exit()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        playerName = PlayerNameText.text;
    }

    void DisplayBestScore()
    {
        DataPersistence.Instance.LoadBestScore();
        displayBestPlayer = DataPersistence.Instance.displayTopPlayer;
        displayBestScore = DataPersistence.Instance.displayBestScore;

        BestScoreText.text = $"Best Score : {displayBestPlayer} : {displayBestScore}";
    }
}
