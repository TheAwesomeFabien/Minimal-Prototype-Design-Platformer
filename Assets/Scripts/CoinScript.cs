using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int scoreWorth;
    private AudioSource aS;
    [SerializeField] private AudioClip aC;

    private void Start() =>
        aS = GetComponent<AudioSource>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            Collect();
    }

    private void Collect()
    {
        GameManager.instance.score += scoreWorth;
        GameManager.instance.ScoreChange();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log(aS);
        aS.PlayOneShot(aC);
        Invoke("CleanUp", 1);
    }

    private void CleanUp()
    {
        Destroy(gameObject);
    }
}
