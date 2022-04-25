using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioSource Slash;
   // public CheckFruitInstantiated check;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //check = GetComponent<CheckFruitInstantiated>();
    }

    // Update is called once per frame
    void Update()
    {
        SetBladeToMouse();
        //PlaySlashingSound();
    }
    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;// distance of 10 units from the camera.
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    //private void PlaySlashingSound()
    //{
    //    if(check.FruitIsInstantiated==true)
    //    {
    //        Slash.Play();
    //    }
    //}
    
}
