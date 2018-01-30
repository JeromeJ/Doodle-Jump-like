using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DualBehaviour
{
    #region Public Members

    public float m_speed = 5f;

    #endregion

    #region Public void

    #endregion

    #region System

    protected override void Awake()
    {
        m_body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 m_speedVector;

        m_speedVector.x = Input.GetAxisRaw("Vertical");
        m_speedVector.y = Input.GetAxisRaw("Horizontal");

        m_body.velocity = new Vector2(m_speedVector.y, m_speedVector.x) * m_speed;
    }

    #endregion

    #region Class Methods

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    private Rigidbody m_body;

    #endregion
}
