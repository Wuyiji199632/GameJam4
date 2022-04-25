using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
       Blade b= collision.GetComponent<Blade>();
        if (!b) return;
        FindObjectOfType<GameManager>().OnBombHit();
    }
}
