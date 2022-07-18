using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    float originalSpeed;
    Player player;
    [SerializeField] float speedReduction = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        originalSpeed = player.speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.speed *= speedReduction;
        }
    }
    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.speed = originalSpeed;
        }   
    }
}
