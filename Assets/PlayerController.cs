using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // properties of Rigidbody; AddForce, velocity

    Rigidbody rb;
    Rigidbody rb2;

    [SerializeField] // these are all fields. variables but fields within a class. NOTE: also, for the very next field, serialize it.
    GameObject bullet;


    float speed = 10;

    [SerializeField]
    float bulletSpeed = 100;

    [SerializeField]
    float jumpSpeed = 1000;

    public int bulletMax = 10;

    [SerializeField]
    private TMP_Text ammoDisplay;

    bool onGround = true;

    int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ammoDisplay.text = bulletMax.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue value) // Control type: Vector 2 --> {x, y}
    {
        Vector2 input = value.Get<Vector2>();

        Debug.Log(input);

        // transform.position, transform.rotation
        // transform.forward, transform. right

        rb.velocity = input.y * transform.forward + input.x * transform.right;
        rb.velocity *= speed; // 

    }

    void OnFire() // this function will be called when the fire action is triggered, e.g. when we press the left mouse button
    {
        Debug.Log("FIRING");
        if (bulletMax > 0)
        {
            bulletMax--;
            ammoDisplay.text = bulletMax.ToString();
            GameObject bulletInstance = Instantiate(bullet, transform.position + 0.5f * transform.forward, Quaternion.identity);  // add f because its a float
            Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(bulletSpeed * transform.forward);
        }

    }

    void OnJump()
    {
        if(onGround || jumpCount != 2)
        {
            //... your code
            Debug.Log("JUMPING");
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jumpCount += 1;
            onGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            // our feet are touching the ground
            onGround = true;
            jumpCount = 0;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            // our feet are no longer touching the ground
            onGround = false;

        }
    }
}
