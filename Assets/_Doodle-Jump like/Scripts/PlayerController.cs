﻿using UnityEngine;
using UnityEngine.Events;

public class PlayerController : DualBehaviour
{
    #region Public Members

    public float m_movingSpeed = 5f;
    public float m_jumpSpeed = 5f;

    public class OnTriggerCollision : UnityEvent<Collider> { }
    [HideInInspector] public OnTriggerCollision m_onTriggerCollision = new OnTriggerCollision();

    #endregion

    #region Public void

    #endregion

    #region System

    protected override void Awake()
    {
        m_body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name, other);

        m_onTriggerCollision.Invoke(other);

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
        //// Bad Practice
        //m_body.velocity = new Vector3(
        //    (Input.GetAxisRaw("Horizontal") + Input.acceleration.x) * m_movingSpeed,
        //    m_body.velocity.y,
        //    m_body.velocity.z
        //);

#if UNITY_EDITOR || UNITY_WEBGL || UNITY_STANDALONE
        m_body.velocity = new Vector3(
            Input.GetAxisRaw("Horizontal") * m_movingSpeed,
            m_body.velocity.y,
            m_body.velocity.z
        );
#elif UNITY_ANDROID
        m_body.velocity = new Vector3(
            Input.acceleration.x * m_movingSpeed,
            m_body.velocity.y,
            m_body.velocity.z
        );
#endif
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    private Rigidbody m_body;

#endregion
}
