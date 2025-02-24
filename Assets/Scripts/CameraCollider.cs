using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;

    Vector3 dollyDir;
    public float dollyDirAdjusted;
    public float distance;

    void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
        maxDistance = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit) && hit.transform.gameObject.layer != 1)
        {
            distance = Mathf.Clamp((hit.distance * 0.9f), minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
    }
}
