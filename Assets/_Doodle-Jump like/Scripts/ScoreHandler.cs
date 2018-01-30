using System;
using System.Collections;
using System.Collections.Generic;
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
    }

    private void FixedUpdate()
    {
        UpdateScoreText(GetScore());
    }

    private void UpdateScoreText(int _score)
    {
        // TODO: Add juicyness when score changes :)
        m_scoreText.text = m_template.Replace("{score}", _score.ToString());
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

    [SerializeField] private string m_template;

    #endregion
}
