using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    float conjurTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        conjurTimer = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("conjur", true);
            conjurTimer -= Time.deltaTime;
        }
        else
        {
            animator.SetBool("conjur", false);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(conjurTimer <= 0.0f)
            {
                animator.SetBool("release", true);
            }

                conjurTimer = 2.0f;
        }
       
    }

    public void ReleaseReset()
    {
        animator.SetBool("release", false);
    }
}
