using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public GameObject meshRenderer;
    GameObject player;
    GameManager manager;
    PlayerMovement playerMovement;
    Rigidbody rb;
    PlayerAttack playerAttack;
    GameObject target;
    Material metal;
    Material green;
    int colorIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerAttack = player.GetComponent<PlayerAttack>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = GameObject.Find("ConjuringArea");
        rb = GetComponent<Rigidbody>();
        metal = meshRenderer.GetComponent<MeshRenderer>().materials[0]; 
        green = meshRenderer.GetComponent<MeshRenderer>().materials[1];

        float max = 0.0f;
        float min = 2.0f;

        float x = Random.Range(min, max);
        float y = Random.Range(min, max);
        float z = Random.Range(min, max);
        colorIndex = 0;

        rb.angularVelocity = new Vector3(x, y, z);

        Physics.IgnoreCollision(player.GetComponent<CharacterController>(), GetComponent<BoxCollider>());

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

            if(distance > 0.75f && playerMovement.moveDirection == Vector3.zero)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 4.0f);
            }
        }
    }

    public void Explode()
    {
        Vector3 vec = transform.position - playerAttack.gameObject.transform.position;

        GetComponent<BoxCollider>().isTrigger = false;
        rb.AddForce(vec * 75.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WIN"))
        {
            manager.AddWinToPlayersWins();

            GetComponent<FloatingObjectSound>().PlayWinSound();

            if(colorIndex == 0)
            {
                meshRenderer.GetComponent<MeshRenderer>().material = green;
                colorIndex++;
            }
            else if(colorIndex == 1)
            {
                meshRenderer.GetComponent<MeshRenderer>().material = metal;
                colorIndex = 0;
            }
        }
    }
}
