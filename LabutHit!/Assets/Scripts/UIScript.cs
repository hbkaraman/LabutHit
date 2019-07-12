using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public BallControlScript ballController;
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


    private bool isClicked;
    private void Update()
    {
        if (Input.GetMouseButton(0) && !isClicked)
        {
            HideLevelStartPanel();
            isClicked = true;
            ballController.enabled=true;
        }
    }

    public void HideLevelStartPanel()
    {
        levelStartPanel.SetActive(false);
    }
    
    
    public void ShowLevelComplatedPanel()
    {
        levelComplatedPanel.SetActive(true);
    }
}
