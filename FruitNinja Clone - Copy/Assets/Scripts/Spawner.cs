using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitToSpawn;
    public GameObject Bomb;
    public Transform[] SpawnPlaces;
    public float minWAait = 0.3f;
    public float maxWait = 1f;
    public float MinForce = 12f;
    public float MaxForce = 17f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }
    private void Update()
    {

    }
    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWAait, maxWait));
            Transform t = SpawnPlaces[Random.Range(0, SpawnPlaces.Length)];
            GameObject go = null;
            float p = Random.Range(0, 100);
            if (p < 80)
            {
                go = Bomb;
            }
            else
            {
                go = fruitToSpawn[(Random.Range(0, fruitToSpawn.Length))];

            } // 10% chance of spawing bombs and 90% chance of whatever objects.


            GameObject fruit = Instantiate(go, t.position, t.rotation);
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(MinForce, MaxForce), ForceMode2D.Impulse);// shoot the fruits upwards.
            Debug.Log("Fruit gets spawned");
            Destroy(fruit, 5);
        }
    }
}
            

    


    // Update is called once per frame
    

