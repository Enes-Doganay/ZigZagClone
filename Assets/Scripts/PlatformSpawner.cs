using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    
    [SerializeField] private Transform platformContainer;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject diamonds;
    private bool gameOver;
    private Vector3 lastPosition; // position of last platform
    private float size; // size of platform

	void Start () 
    {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x; // x or z, both are the same	

        for (int i = 0; i < 20; i++) // create first set of platforms
            SpawnPlatform();
	}
	
	void Update ()
    {
        if (GameManager.Instance.gameOver == true)
            CancelInvoke("SpawnPlatform");
	}
    
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f); // begin creating the next ones
    }

    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6);
        if (rand < 3)
            SpawnX();
        else if (rand >= 3)
            SpawnZ();
    }

    void SpawnX() // spawn platform in X direction
    {
        Vector3 pos = lastPosition;
        pos.x += size; // move new one on x axis by the size of the platform
        GameObject platformObj = Instantiate(platform, pos, Quaternion.identity);
        platformObj.transform.SetParent(platformContainer);
        lastPosition = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            GameObject diamondObj = Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
            diamondObj.transform.SetParent(platformObj.transform);
        }

    }

    void SpawnZ() // spawn platform in Z direction
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        GameObject platformObj = Instantiate(platform, pos, Quaternion.identity);
        platformObj.transform.SetParent(platformContainer);
        lastPosition = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            GameObject diamondObj = Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
            diamondObj.transform.SetParent(platformObj.transform);
        }
    }
}
