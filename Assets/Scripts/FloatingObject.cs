using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    Rigidbody rb;
    PlayerAttack playerAttack;
    GameObject target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        target = GameObject.Find("ConjuringArea");
        rb = GetComponent<Rigidbody>();
        float max = 0.0f;
        float min = 5.0f;

        float x = Random.Range(min, max);
        float y = Random.Range(min, max);
        float z = Random.Range(min, max);
        float mag = Random.Range(2.0f, 20.0f);


    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if(playerAttack.conjuring)
        {
            GetComponent<BoxCollider>().isTrigger = true;
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = Vector3.zero;

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 8.0f);
        }

    }

    public void Explode()
    {
        float max = 0.0f;
        float min = 0.3f;

        Vector3 vec = playerAttack.gameObject.transform.forward;
        Vector3 vec_adj = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));

        GetComponent<BoxCollider>().isTrigger = false;
        rb.AddForce(vec * 100.0f);
    }
}
