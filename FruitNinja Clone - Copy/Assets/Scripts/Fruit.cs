using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
  
    
    
    public void Update()
    {
        
    }
    public void CreateSlicedFruit()
    {
        GameObject inst= (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();
        FindObjectOfType<GameManager>().PlayRandomSound();
        foreach(Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }
        FindObjectOfType<GameManager>().IncreaseScore(3);
        Destroy(gameObject);
        Destroy(inst.gameObject, 5);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Blade b =other.GetComponent<Blade>();
        if (!b) return;
        CreateSlicedFruit();
        //FindObjectOfType<GameManager>().IsSlicingFruit = true;
        
    }
}
   
