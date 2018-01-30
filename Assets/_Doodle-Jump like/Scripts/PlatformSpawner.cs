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

    public GameObject m_leftWall;
    public GameObject m_rightWall;
    public GameObject m_spawnZone;
    public GameObject m_despawnZone;

    public List<GameObject> m_platforms = new List<GameObject>();

    private float highestPoint;

    #endregion

    #region Public void

    #endregion

    #region System

    private void Start()
    {
        for (var i = 0; i < 20; i++)
            Spawn();
    }

    protected void FixedUpdate()
    {
        int desiredNumberOfPlatform = GetDesiredNumberOfPlatforms();

        //while (m_platforms.Count < desiredNumberOfPlatform)
        //    Spawn();
    }

    private int GetDesiredNumberOfPlatforms()
    {
        return (int)(42 - Score/10);
    }

    static Random rnd = new Random();

    public int Score { get { return (int)GetComponent<CameraFollowPlayer>().MaxUp; }}

    private void Spawn()
    {
        highestPoint = Mathf.Clamp(highestPoint + Score / 20, highestPoint + 1, highestPoint + 5);

        // Move out into another function
        Vector3 newPos = new Vector3
        {
            x = RandomBetween(m_leftWall.transform.position.x + 1, m_rightWall.transform.position.x - 1),
            //y = RandomBetween(m_despawnZone.transform.position.y, m_spawnZone.transform.position.y)
            y = highestPoint
        };

        //newPos.y += Math.Abs(m_despawnZone.transform.position.y - m_spawnZone.transform.position.y);
        newPos.y += 5;

        GameObject newPlatform = Instantiate(m_platform, newPos, m_transform.rotation);

        // newPlatform.GetComponent<PlatformDestroyer>().m_despawnZone = m_despawnZone;
        newPlatform.GetComponent<PlatformDestroyer>().onDestroy.AddListener(ClearUpDestroyedPlatforms);

        m_platforms.Add(newPlatform);
    }

    private void ClearUpDestroyedPlatforms(GameObject platform)
    {
        m_platforms.Remove(platform);

        Spawn();
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
