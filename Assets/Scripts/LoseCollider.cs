using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoseCollider : MonoBehaviour
{
    #region Variables
    [SerializeField] UnityEvent onLose = new UnityEvent();

    #endregion
    #region Main Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(onLose != null)
        {
            onLose.Invoke();
        }
    }
    #endregion
}
