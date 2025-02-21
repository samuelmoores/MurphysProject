using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    CharacterController controller;
    GameObject cam;
    Animator animator;
    Vector3 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = GameObject.Find("Main Camera");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        moveDirection = new Vector3(horizontal, 0.0f, vertical);
        moveDirection.Normalize();

        if(moveDirection != Vector3.zero)
        {
            moveDirection = Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up) * moveDirection;
            moveDirection.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 720.0f * Time.deltaTime);

        }

        controller.Move(moveDirection * Time.deltaTime);

        animator.SetBool("moving", moveDirection != Vector3.zero);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floating"))
        {
            Debug.Log(collision.gameObject);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.position - transform.position * -10.0f);
        }
    }
}
