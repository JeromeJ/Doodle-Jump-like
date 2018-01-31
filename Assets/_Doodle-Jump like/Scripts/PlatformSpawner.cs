using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlatformSpawner : DualBehaviour
{
    #region Public Members

    public GameObject m_platform;
    public float m_difficultyScaling  = 1;

    public Camera m_camera;
    public PlayerController m_player;

    public GameObject m_leftWall;
    public GameObject m_rightWall;
    public GameObject m_spawnZone;
    public GameObject m_despawnZone;

    public List<GameObject> m_platforms = new List<GameObject>();

    private float HighestPoint;
    private float DefaultJump;

    #endregion

    #region Public void

    #endregion

    #region System

    private void Start()
    {
        DefaultJump = m_player.m_jumpSpeed;

        for (var i = 0; i < 20; i++)
            Spawn();
    }

    protected void FixedUpdate()
    {
        int desiredNumberOfPlatform = GetDesiredNumberOfPlatforms();
    }

    private int GetDesiredNumberOfPlatforms()
    {
        return (int)(42 - Score/10);
    }

    static Random rnd = new Random();

    public int Score { get { return (int)GetComponent<CameraFollowPlayer>().MaxUp; }}

    private void Spawn()
    {
        // LVL 1
        float max = HighestPoint + 5;
        HighestPoint = Mathf.Clamp(HighestPoint + Score / 20, HighestPoint + 1, max);

        // LVL2
        if (HighestPoint == max)
        {
            float newGameSpeed = 1f + (Score / 50f) / 4f;
            
            Time.timeScale = newGameSpeed;

            Debug.Log("Game speed: " + newGameSpeed);
        }

        // Move out into another function
        Vector3 newPos = new Vector3
        {
            x = RandomBetween(m_leftWall.transform.position.x + 1, m_rightWall.transform.position.x - 1),
            //y = RandomBetween(m_despawnZone.transform.position.y, m_spawnZone.transform.position.y)
            y = HighestPoint
        };

        //newPos.y += Math.Abs(m_despawnZone.transform.position.y - m_spawnZone.transform.position.y);
        newPos.y += 5;

        GameObject newPlatform = Instantiate(m_platform, newPos, m_transform.rotation);

        // newPlatform.GetComponent<PlatformDestroyer>().m_despawnZone = m_despawnZone;
        newPlatform.GetComponent<PlatformDestroyer>().onDestroy.AddListener(ClearUpDestroyedPlatforms);
        newPlatform.GetComponent<PlatformDestroyer>().onDestroy.AddListener(Spawn);

        m_platforms.Add(newPlatform);
    }

    /// <summary>
    /// Called upon an event
    /// </summary>
    /// <param name="arg0"></param>
    private void Spawn(GameObject arg0)
    {
        Spawn();
    }

    private void ClearUpDestroyedPlatforms(GameObject platform)
    {
        m_platforms.Remove(platform);
    }

    #endregion

    #region Class Methods

    #endregion

    #region Tools Debug and Utility

    private float RandomBetween(float x1, float x2)
    {
        return (float)rnd.NextDouble() * (x2 - x1) + x1;
    }

    #endregion

    #region Private and Protected Members

    #endregion
}
