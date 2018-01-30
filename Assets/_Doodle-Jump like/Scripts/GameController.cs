using System;
using UnityEngine;

public class GameController : DualBehaviour
{
    #region Public Members

    public PlayerController m_player;
    public GameObject m_deathZone;

    #endregion

    #region Public void

    #endregion

    #region System

    protected override void Awake()
    {
        m_player.m_onTriggerCollision.AddListener(OnTriggerCollision);
    }

    private void Update()
    {
        
    }

    #endregion

    #region Class Methods

    private void OnTriggerCollision(Collider _other)
    {
        if(_other.gameObject == m_deathZone)
        {
            Debug.LogError("GAME OVER");
            Debug.Break();
        }
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    #endregion
}
