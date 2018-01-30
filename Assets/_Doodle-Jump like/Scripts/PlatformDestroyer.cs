using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformDestroyer : DualBehaviour
{
    #region Public Members

    public class OnDestroy : UnityEvent<GameObject> { }

    public OnDestroy onDestroy = new OnDestroy();
    public GameObject m_despawnZone;

    #endregion

    #region Public void

    #endregion

    #region System

    protected override void Awake()
    {
        
    }

    //private void Update()
    //{
    //    if (m_transform.position.y < m_despawnZone.transform.position.y)
    //        Seppuku();
    //}

    private void Seppuku()
    {
        onDestroy.Invoke(gameObject);

        Destroy(gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name, other);

        if (other.tag == "despawn")
            Seppuku();
            
    }

    #endregion

    #region Class Methods

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    #endregion
}
