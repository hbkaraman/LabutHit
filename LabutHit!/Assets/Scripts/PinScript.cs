using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    public bool isTouchPlayer;
    private GameObject _particleEffect;
    public Material _mat;
    private Renderer _rend;
    private bool oneCreted = true;
   // public TextMeshPro scoreText;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Pin")
        {
            isTouchPlayer = true;
            if (oneCreted)
            {
                StartCoroutine("Effects");
            }
        }
    }

    private IEnumerator Effects()
    {
       // GameManager.Instance.score += 1;
        //scoreText.gameObject.SetActive(true);
        _rend.material = _mat;
        _particleEffect = ObjectPooler.SharedInstance.GetPooledObject(0);
        _particleEffect.gameObject.transform.position = transform.position;
        _particleEffect.SetActive(true);
        oneCreted = false;
       /* yield return new WaitForSeconds(1f);
        scoreText.gameObject.SetActive(false);*/
        yield return new WaitForSeconds(3f);
        
        this.gameObject.SetActive(false);
    }
}
