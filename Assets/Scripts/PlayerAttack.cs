using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    float conjurTimer;

    [HideInInspector] public bool conjuring;
    [HideInInspector] public bool explode;


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
            conjuring = true;
            conjurTimer -= Time.deltaTime;
        }
        else
        {
            conjuring = false;
        }

        animator.SetBool("conjur", conjuring);

        if (Input.GetKeyUp(KeyCode.Space))
        {

            if(conjurTimer <= 0.0f)
            {
                animator.SetBool("release", true);
            }

            conjurTimer = 2.0f;

            GetComponent<AudioSource>().Stop();
        }
  
    }

    public void ReleaseReset()
    {
        animator.SetBool("release", false);

    }

    public void Explode()
    {

        GameObject[] floatingObjects = GameObject.FindGameObjectsWithTag("Floating");

        for (int i = 0; i < floatingObjects.Length; i++)
        {
            floatingObjects[i].GetComponent<FloatingObject>().Explode();
        }

        GameObject[] troops = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < troops.Length; i++)
        {
            troops[i].GetComponent<TroopMovement>().TakeDamage();
        }
    }
}
