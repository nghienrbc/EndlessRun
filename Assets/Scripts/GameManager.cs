using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject basicRoad; 
    public GameObject obstacle;
    private Vector3 startPosition;
    private Vector3 nextPosition;
    public int numOfBasicRoad = 10;
    private bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = new Vector3(0, 0, 0);
        nextPosition = startPosition;
        for (int i = 0; i < numOfBasicRoad; i++) // Tạo trước một số basicRoad
        {
            CreateBasicRoad();
        } 
    } 

    public void CreateBasicRoad()
    {  
        var newBasicRoad = Instantiate(basicRoad, nextPosition, Quaternion.identity);
        nextPosition = newBasicRoad.transform.Find("NextRoadPosition").transform.position; // cập nhật vị trí tạo basicRoad tiếp theo bằng cách lấy vị trí NextRoadPosition của basicRoad hiện tại
        int randnumber = Random.Range(0, 3);
        Vector3 obstaclePos = randnumber == 0 ? newBasicRoad.transform.Find("LeftPos").transform.position :
            randnumber == 1 ? newBasicRoad.transform.Find("CenterPos").transform.position : newBasicRoad.transform.Find("RightPos").transform.position;
        var newObstacle = Instantiate(obstacle, obstaclePos, Quaternion.identity);
        newObstacle.transform.SetParent(newBasicRoad.transform);
        }
    public void GameOver()
    {
        isGameOver = true;
        Invoke("LoadScene", 2f);
    }
    void LoadScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName); 
    }

}
