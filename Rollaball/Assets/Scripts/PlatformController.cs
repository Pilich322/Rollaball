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
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(player.tag))
        {
            animator.SetBool(PlayerOnPlatform, true);
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(player.tag))
        {
            animator.SetBool(PlayerOnPlatform, false);
        }
    }
}
