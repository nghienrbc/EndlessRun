using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    public float moveSpeed; 
    public float jumpSpeed;
    private Rigidbody rb;
    private float horizontalInput = 0;
    private bool isGrounded = false;
    private bool isCanJump = false;
    private GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded){
            isCanJump = true;
            isGrounded = false;
        }
    } 
    private void FixedUpdate()
    {
        // Giữ vận tốc cố định 
        rb.linearVelocity = Vector3.forward * moveSpeed + new Vector3(horizontalInput * turnSpeed, rb.linearVelocity.y, 0);
        if (isCanJump)
        {
            Debug.Log("Nhảy");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpSpeed, rb.linearVelocity.z);
            isCanJump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "DeadZone")
        {
            // tạo mới BasicRoad
            gm.CreateBasicRoad();
            Destroy(other.transform.parent.gameObject, 2);
        }
    }
}
