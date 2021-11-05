using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    TileManager groundSpawner;
    public int number = 10;
    public Transform playertransform;
    private List<GameObject> activetiles = new List<GameObject>();
    // Start is called before the first frame update
    public void Start()
    {
       for (int i = 0; i < number; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
        groundSpawner = GameObject.FindObjectOfType<TileManager>();
        spawncoins();
    }

    // Update is called once per frame
    void Update()
    {
        if (playertransform.position.z -35 > zSpawn - (number * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            deleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
       GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activetiles.Add(go);
        zSpawn += tileLength;
    }
    private void deleteTile()
    {
        Destroy(activetiles[0]);
        activetiles.RemoveAt(0);
    }
    public GameObject coinfab;
    void spawncoins()
    {
        int coinstospawn = 10;
        for (int i = 0; i < coinstospawn; i++)
        {
            GameObject temp = Instantiate(coinfab, transform);
            temp.transform.position = getrandomcointincollider(GetComponent<Collider>());
        }
    }
    Vector3 getrandomcointincollider(Collider collider)
    {
        Vector3 point = new Vector3(
          Random.Range(collider.bounds.min.x, collider.bounds.max.x),
           Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = getrandomcointincollider(collider);
        }

        point.y = 1;
        return point;
    }
}
