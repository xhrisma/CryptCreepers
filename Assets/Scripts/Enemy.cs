using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    [SerializeField]int health = 2;
    [SerializeField]float speed = 1;
    [SerializeField]int scorePoint = 10;
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<Player>().transform;
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int randomSpawPoint = Random.Range(0, spawnPoint.Length);
        transform.position = spawnPoint[randomSpawPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction * Time.deltaTime *speed;
       
    }
    public void RestarVida()
    {
        health--;
        if (health <= 0)
        {
            GameManager.Instance.Score += scorePoint;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().RestarVidaPlayer();
           
        }
    }
}
