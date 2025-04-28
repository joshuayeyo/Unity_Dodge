using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    void Start() {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = transform.forward * speed;
        
        // 3초 뒤에 Bullet 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
