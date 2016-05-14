using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private CharacterController rb;
    private int count;
    public Text countText;
    public Text winText;
    public bool grounded = true;
    public float jumpPower = 100;

    public float rotationSpeed = 5;
    public float direction = 0;

    private CharacterController controller;
    private float speed = 6;
    private float turnSpeed = 90;

    void Start()
    {
        rb = GetComponent<CharacterController>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    void onCollissionEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }

    void FixedUpdate()
    {
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");
        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.AddForce(movement * speed);

        Vector3 moveDir = new Vector3(0.0f, 0.0f, 0.0f);

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        movDir = transform.forward * Input.GetAxis("Vertical") * speed;
        controller.Move(movDir * Time.deltaTime - Vector3.up * 0.1);

        if (Input.GetKeyDown("space") && grounded == true)
        {
            Vector3 jumpVector = new Vector3(0.0f, jumpPower, 0.0f);
            rb.AddForce(jumpVector);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >=12)
        {
            winText.text = "You Win!!";
        }
    }
}
