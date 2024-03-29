﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton

    public static GameManager Instance;

    void Start()
    {
        _pins = FindObjectsOfType<PinScript>();
        _isFin = new bool[_pins.Count()];
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Application.targetFrameRate = 60;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion


    //public GameObject[] Pincont;
    PinScript[] _pins;
    bool[] _isFin;
    // public int score;
    private GameObject particleEffect;




    // Update is called once per frame
    void Update()
    {
        EndGameControl();
    }



    void EndGameControl()
    {
        for (int i = 0; i < _pins.Length; i++)
        {
            if (_pins[i].isTouchPlayer)
            {
                _isFin[i] = true;

                if (_isFin.All(_isFin => _isFin))
                {
                    StartCoroutine("NextLevel");
                }
            }
        }
    }


    private void levleLoadInvokable()
    {
        
    }

    private IEnumerator NextLevel()
    {
        UIScript.Instance.ShowLevelComplatedPanel();
       // particleEffect = ObjectPooler.SharedInstance.GetPooledObject(2);
       // particleEffect.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      
    }

}
