using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DualBehaviour
{
    #region Public Members

    public float m_movingSpeed = 5f;
    public float m_jumpSpeed = 5f;

    #endregion

    #region Public void

    #endregion

    #region System

    protected override void Awake()
    {
        m_body = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name, other);

        if (other.tag == "platform")
            Jump();
    }

    #endregion

    #region Class Methods

    private void Jump()
    {
        m_body.velocity = Vector3.zero;
        m_body.AddForce(Vector3.up * m_jumpSpeed * 100);
    }

    private void Move()
    {
        m_body.velocity = new Vector3(
            Input.GetAxisRaw("Horizontal") * m_movingSpeed,
            m_body.velocity.y,
            m_body.velocity.z
        );
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    private Rigidbody m_body;

    #endregion
}
