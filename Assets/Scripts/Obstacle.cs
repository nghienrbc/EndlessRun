using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player") // nếu đối tượng va chạm vào là player
        {
            Destroy(collision.gameObject);
            gm.GameOver();
        }
    }
}
