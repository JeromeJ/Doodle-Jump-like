using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : DualBehaviour
{
    #region Public Members

    public Text m_scoreText;

    #endregion

    #region Public void

    #endregion

    #region System

    protected override void Awake()
    {
        m_template = m_scoreText.text;
        m_bestScorePath = Path.Combine(Application.persistentDataPath, "bestScore");

        LoadBestScore();
    }

    private void LoadBestScore()
    {
        if (File.Exists(m_bestScorePath))
            m_bestScore = Int32.Parse(File.ReadAllText(m_bestScorePath));
    }

    private void FixedUpdate()
    {
        int score = GetScore();

        UpdateBestScore(score);
        UpdateScoreText(score);
    }

    private void UpdateBestScore(int _score)
    {
        if(_score > m_bestScore)
        {
            m_bestScore = _score;

            SaveBestScore();
        }
    }

    private void SaveBestScore()
    {
        File.WriteAllText(m_bestScorePath, "" + m_bestScore);
    }

    private void UpdateScoreText(int _score)
    {
        // TODO: Add juicyness when score changes :)
        m_scoreText.text = m_template
            .Replace("{score}",     _score.ToString())
            .Replace("{bestScore}", m_bestScore.ToString());
    }

    private int GetScore()
    {
        // TODO: Dirty

        return (int)GetComponent<CameraFollowPlayer>().MaxUp;
    }

    #endregion

    #region Class Methods

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    [SerializeField] private int m_bestScore;
    [SerializeField] private string m_template;
    private string m_bestScorePath;

    #endregion
}
