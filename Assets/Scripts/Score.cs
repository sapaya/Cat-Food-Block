using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour
{
    #region Variables
    TextMeshProUGUI textField;
    #endregion

    #region Main Methods
    // Start is called before the first frame update
    void Awake()
    {
        textField = GetComponent<TextMeshProUGUI>();
    }
    #endregion

    #region Helper Methods
    public void UpdateScore(int newScore)
    {
        textField.text = newScore.ToString();
    }
    #endregion
}
