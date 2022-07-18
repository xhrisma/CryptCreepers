using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] int addtime = 10;
    [SerializeField]AudioClip pointAudio;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.time += addtime;
            AudioSource.PlayClipAtPoint(pointAudio, transform.position);
            Destroy(gameObject, 0.1f);
        }
    }
}
