using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    #region Singleton

    public static GameManager Instance;

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
    public PinScript[] _pins;
    public bool[] _isFin;
   // public int score;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Pincont.All(GetComponentsInChildren<PinScript>())
    }

    // Update is called once per frame
    void Update()
    {
        EndGameControl();
    }


    void EndGameControl()
    {
        for (int i = 0; i < _pins.Length ; i++)
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
        
        yield return new  WaitForSeconds(2f);
    }
    
}
