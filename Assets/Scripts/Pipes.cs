
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public GameObject pipes;
    float startxpos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i< 5;  i++)
        {
            startxpos += 5;
            Instantiate(pipes, new Vector3(startxpos, Random.Range(-2, 2)), Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    
    public void GeneratePipe()
    {
        startxpos += 5;
        Instantiate(pipes, new Vector3(startxpos, Random.Range(-2, 2)), Quaternion.identity);
        
    }

   
  
}
