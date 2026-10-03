using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count = 0;
    public float speed = 0;

    private ParticleSystem dustPartical;
    private ParticleSystem deadPartical;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public AudioClip winClip;
    public AudioClip deadClip;
    public AudioClip pickUpClip;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);

        deadPartical = transform.Find("ParticalDead")?.GetComponent<ParticleSystem>();
        dustPartical = transform.Find("DustPartical")?.GetComponent<ParticleSystem>();

        if (dustPartical != null)
        {
            dustPartical.Stop();
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if (dustPartical != null)
        {
            if (rb.linearVelocity.sqrMagnitude > 0.5f)
            {
                if (!dustPartical.isPlaying)
                {
                    dustPartical.Play();
                }
            }
            else
            {
                if (dustPartical.isPlaying)
                {
                    dustPartical.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                }
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            SoundManager.Instance.PlaySound(winClip);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (deadPartical != null)
            {
                deadPartical.transform.parent = null;
                deadPartical.Play();
            }
            SoundManager.Instance.PlaySound(deadClip);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            winTextObject.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            ParticleSystem particle = other.GetComponentInChildren<ParticleSystem>();
            if (particle != null)
            {
                particle.transform.parent = null;
                particle.Play();
            }
            SoundManager.Instance.PlaySound(pickUpClip);
            count++;
            SetCountText();
            other.gameObject.SetActive(false);
        }
    }
}