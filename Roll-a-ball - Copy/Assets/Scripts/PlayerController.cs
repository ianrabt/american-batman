using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private CharacterController rb;
    private int count;
    public Text countText;
    public Text winText;
    public bool grounded = false;
    public float jumpPower;
    private CharacterController controller;
    private float speed = 5;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Camera cam = Camera.main;
        count = 0;
        setCountText();
        winText.text = "";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
        void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3();
        movement = Camera.main.transform.right * moveHorizontal + Camera.main.transform.forward * moveVertical;
        movement += (Physics.gravity * Time.deltaTime * (float) 8.0);

        if (Input.GetKeyDown("space") && grounded)
        {
            movement.y = jumpPower;
        }

        controller.Move(movement * Time.deltaTime);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.visible = true;
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
