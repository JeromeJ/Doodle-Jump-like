using System;
using UnityEngine;
using UnityEngine.Analytics;
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
        m_player.m_onTriggerCollision.AddListener(CheckForGameOver);

        // Prevents a lightning bug when reloading the scene
        DontDestroyOnLoad(GameObject.Find("Directional Light"));

#if UNITY_ANDROID
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif
    }

    #endregion

    #region Class Methods

    private void CheckForGameOver(Collider _other)
    {
        if(_other.gameObject == m_deathZone)
            GameOver();
    }

    private void GameOver()
    {
        PauseGame();

        ShowGameOverUI();

        Analytics.CustomEvent("GaaaameOveeer");

        AnalyticsEvent.GameOver(GetComponent<PlatformSpawner>().Score);

        //GetComponent<AnalyticsEventTracker>().TriggerEvent();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;

#if UNITY_ANDROID
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
#endif
    }

    private void ShowGameOverUI()
    {
        m_gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        // TODO: Instead set it to 1 at the start.
        ResumeGame();

        ReloadScene();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;

#if UNITY_ANDROID
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    #endregion
}
