using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    
    #region Singleton

    public static UIScript Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    
    [Header("LevelStart Panel")]
    public GameObject levelStartPanel;

    [Header("Level End Panel")]
    public GameObject levelComplatedPanel;

    public void HideLevelStartPanel()
    {
        levelStartPanel.SetActive(false);
    }
    
    
    public void ShowLevelComplatedPanel()
    {
        levelComplatedPanel.SetActive(true);
    }
}
