using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject target;
    private Vector3 offset;
    void Start()
    {
        if (target != null)
        {
            offset = transform.position - target.transform.position; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            transform.position = target.transform.position + offset;
    }
}
