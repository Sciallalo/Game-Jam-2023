using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject galaxy;
    [SerializeField] GameObject monsterPlayer;
    [SerializeField] BoundariesDimension boundaries;
    [SerializeField] float spawnTimeSec;
    [SerializeField] int maxGalaxyOnView;
    [SerializeField] float spawnBaundariesOffset;

    private ArrayList galaxies;
    private int galaxyCounter;

    void Start()
    {
        galaxyCounter = 0;
        galaxies = new ArrayList();
        StartCoroutine(GalaxySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        //Vector2 halfWidthHeight = boundaries.getCurrentDimension() * 0.5f;
        //Vector3 transform = new Vector3(Random.Range(-halfWidthHeight.x, halfWidthHeight.x), 0, Random.Range(-halfWidthHeight.y, halfWidthHeight.y));

        //GameObject justSpawnedGalaxy = Instantiate(galaxy, transform, galaxy.transform.rotation);
        //justSpawnedGalaxy.SetActive(true);
    }

    IEnumerator GalaxySpawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTimeSec);
            spawnGalaxy();
        }
    }

    public void decreaseGalaxyCounter(GameObject galaxy)
    {
        this.galaxies.Remove(galaxy);
        Destroy(galaxy);
        this.galaxyCounter--;
    }

    void spawnGalaxy()
    {
        if (galaxyCounter < maxGalaxyOnView)
        {
            GameObject justSpawnedGalaxy=null;
            Vector2 halfWidthHeight = boundaries.getCurrentDimension() * 0.5f - new Vector2(spawnBaundariesOffset, spawnBaundariesOffset);
            Vector3 transform = new Vector3();

            bool done = false;
            while (!done)
            {
                transform = new Vector3(Random.Range(-halfWidthHeight.x, halfWidthHeight.x), 0, Random.Range(-halfWidthHeight.y, halfWidthHeight.y));
                justSpawnedGalaxy = Instantiate(galaxy, transform, galaxy.transform.rotation);

                bool intersecate = false;
                foreach (GameObject galaxy in galaxies) {
                    if (galaxy.GetComponent<Collider>().bounds.Intersects(justSpawnedGalaxy.GetComponent<Collider>().bounds) ||
                        galaxy.GetComponent<Collider>().bounds.Intersects(monsterPlayer.GetComponent<Collider>().bounds))
                    {
                        intersecate = true;
                        Destroy(justSpawnedGalaxy);
                        break;
                    }
                }
                if(!intersecate)  done = true;
            }

            //justSpawnedGalaxy = Instantiate(galaxy, transform, galaxy.transform.rotation);
            justSpawnedGalaxy.SetActive(true);
            galaxies.Add(justSpawnedGalaxy);

            galaxyCounter ++;
        }
    }
}
