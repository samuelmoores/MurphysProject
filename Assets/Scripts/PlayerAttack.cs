using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("conjur", true);
        }
        else
        {
            animator.SetBool("conjur", false);
        }
    }
}
