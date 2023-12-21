using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject camera;
    
    public GameObject player;
    public GameObject ui;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(player.transform.position.x, 0, -10);
    }
    public void GameOver()
    {
        GameObject.FindObjectOfType<Player>().canPlay = false;

        StartCoroutine(Over());
    }
    
    IEnumerator Over()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }
    public void Play()
    {

        player.GetComponent<Player>().canPlay = true;
        ui.SetActive(false);
    }
}
