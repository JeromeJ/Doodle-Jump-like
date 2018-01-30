using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : DualBehaviour
{
    #region Public Members

    public Camera m_camera;
    public GameObject m_player;

    public enum MovingDirection
    {
        UP = 1,
        DOWN = -1
    }

    public MovingDirection m_trackMovingUp  = MovingDirection.UP;

    #endregion

    #region Public void

    #endregion

    #region System

    protected override void Awake()
    {
        
    }

    private void Update()
    {
        
    }

    #endregion

    #region Class Methods

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    #endregion
}
