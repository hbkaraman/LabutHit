using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    public bool isTouchPlayer;
    private GameObject _particleEffectFirst;
    private GameObject _particleEffectSecond;
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
        _particleEffectFirst = ObjectPooler.SharedInstance.GetPooledObject(0);
        _particleEffectFirst.gameObject.transform.position = transform.position;
        _particleEffectFirst.SetActive(true);
        oneCreted = false;
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        _particleEffectSecond =  ObjectPooler.SharedInstance.GetPooledObject(1);
        _particleEffectSecond.gameObject.transform.position = transform.position;
        _particleEffectSecond.SetActive(true);
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}
