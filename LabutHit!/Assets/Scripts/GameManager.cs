using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton

    public static GameManager Instance;

    void Start()
    {
       _pins = FindObjectsOfType<PinScript>();
       _isFin= new bool[_pins.Count()];
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
                    Debug.Log("GameEnd");
                }
            }
        }
    }

    private IEnumerator NextLevel()
    {

        yield return new WaitForSeconds(2f);
    }

}
