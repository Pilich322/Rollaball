using System;
using UnityEngine;
using UnityEngine.Events;

public class PlatformController : MonoBehaviour
{
    public GameObject player;
    private static readonly int PlayerOnPlatform = Animator.StringToHash("PlayerOnPlatform");
    private Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Коллизия началась");
        if (collision.gameObject.CompareTag(player.tag))
        {
            animator.SetBool(PlayerOnPlatform, true);
            Debug.Log("Коллизия идёт");
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Коллизия закончилась");
        if (collision.gameObject.CompareTag(player.tag))
        {
            animator.SetBool(PlayerOnPlatform, false);
            Debug.Log("Коллизии нет");
        }
    }
}
