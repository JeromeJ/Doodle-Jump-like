using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : DualBehaviour
{
    #region Public Members

    public PlayerController m_player;
    public GameObject m_deathZone;
    public GameObject m_gameOverUI;

    #endregion

    #region Public void

    #endregion

    #region System

    protected override void Awake()
    {
        m_player.m_onTriggerCollision.AddListener(OnTriggerCollision);
        DontDestroyOnLoad(GameObject.Find("Directional Light"));
    }

    private void Update()
    {
        
    }

    #endregion

    #region Class Methods

    private void OnTriggerCollision(Collider _other)
    {
        if(_other.gameObject == m_deathZone)
            GameOver();
    }

    private void GameOver()
    {
        Time.timeScale = 0;

        ShowGameOverUI();
    }

    private void ShowGameOverUI()
    {
        m_gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    #endregion
}
