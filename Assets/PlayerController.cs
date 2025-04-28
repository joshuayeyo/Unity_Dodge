using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRigidBody;
    public float speed = 8f;
    
    // Game Object에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당한다.
    void Start() {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update() {
        // if (Input.GetKey(KeyCode.UpArrow) == true)
        // {
        //     playerRigidBody.AddForce(0f, 0f, speed);
        // }
        //
        // if (Input.GetKey(KeyCode.DownArrow) == true)
        // {
        //     playerRigidBody.AddForce(0f, 0f, -speed);
        // }
        //
        // if (Input.GetKey(KeyCode.RightArrow) == true)
        // {
        //     playerRigidBody.AddForce(speed, 0f, 0f);
        // }
        //
        // if (Input.GetKey(KeyCode.LeftArrow) == true)
        // {
        //     playerRigidBody.AddForce(-speed, 0f, 0f);
        // }
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidBody.linearVelocity = newVelocity;
    }

    public void Die() {
        // GameObject 비활성화
        gameObject.SetActive(false);
    }
}
