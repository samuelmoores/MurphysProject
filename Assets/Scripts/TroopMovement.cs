using UnityEngine;

public class TroopMovement : MonoBehaviour
{
    GameObject player;
    Animator animator;
    bool releaseTheTroops = false;
    bool damaged;
    float damageCooldown = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (releaseTheTroops)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            transform.LookAt(player.transform.position);

            if (!damaged && distance > 1.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime / 2);
                animator.SetBool("griddy", false);

            }
            else if(!damaged)
            {
                animator.SetBool("griddy", true);
            }

                animator.SetBool("damaged", damaged);

            if (damaged)
            {
                damageCooldown -= Time.deltaTime;

                if (damageCooldown < 0.0f)
                {
                    damaged = false;
                    damageCooldown = 5.0f;
                }
            }
        }
    }

    public void TakeDamage()
    {
        if(releaseTheTroops)
        {
            damaged = true;
        }
    }

    public void ReleaseTheTroop()
    {
        releaseTheTroops = true;
    }
}
