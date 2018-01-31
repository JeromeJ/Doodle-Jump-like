using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : DualBehaviour
{
    #region Public Members

    public Camera m_camera;
    public PlayerController m_player;

    public enum MovingDirection
    {
        UP = 1,
        DOWN = -1
    }

    public MovingDirection m_trackMovingDirection  = MovingDirection.UP;

    public float MaxUp
    {
        get { return m_maxUp; }
    }


    #endregion

    #region Public void

    #endregion

    #region System

    protected override void Awake()
    {
        m_maxUp = m_player.transform.position.y;
        m_maxDown = m_player.transform.position.y;

        m_offset = m_camera.transform.position.y - m_player.transform.position.y;
    }

    private void FixedUpdate()
    {
        TrackMaxima();

        if (m_trackMovingDirection == MovingDirection.UP)
        {
            if (m_camera.transform.position.y < m_maxUp)
                m_camera.transform.position = new Vector3(m_camera.transform.position.x, m_maxUp - m_offset, m_camera.transform.position.z);
        }
        else
        {
            if (m_camera.transform.position.y > m_maxDown)
                m_camera.transform.position = new Vector3(m_camera.transform.position.x, m_maxDown + m_offset, m_camera.transform.position.z);
        }
    }

    #endregion

    #region Class Methods

    private void TrackMaxima()
    {
        float newPos = m_player.transform.position.y;

        if (newPos > m_maxUp)
            m_maxUp = newPos;
        else if (newPos < m_maxDown)
            m_maxDown = newPos;
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    [SerializeField] private float m_maxUp;
    [SerializeField] private float m_maxDown;

    [SerializeField] private float m_offset;

    #endregion
}
