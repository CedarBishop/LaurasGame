using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Reciever : MonoBehaviour
{
    public AudioClip pickupSound;
    CircleCollider2D circleCollider;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            AudioManager.instance.PlaySFX(pickupSound);
            gameObject.SetActive(false);
        }
    }
}
