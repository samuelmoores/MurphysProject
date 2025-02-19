using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    CharacterController controller;
    GameObject cam;
    Animator animator;

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

        Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical);
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
}
