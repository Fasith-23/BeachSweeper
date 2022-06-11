using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AnimalAttack : MonoBehaviour
{
    public sceneChanger sc;
    public Rigidbody RB;
    public Vector2 pPos = new Vector2(10,10);
    public Shooting shoot;
    bool living = true;
    public GameObject loseScreen;
    Vector2 animalPos = new Vector2(100,100);
    // Start is called before the first frame update
    void Start()
    {
        pPos.x =sc.playerPos.x;
        pPos.y =sc.playerPos.y;
    }

    // Update is called once per frame
    void Update()
    {
        pPos.x =sc.playerPos.x;
        pPos.y =sc.playerPos.y;
        animalPos= new Vector2((int)(RB.position.x/10),(int)(RB.position.z/10));
        if(animalPos.x==pPos.x && animalPos.y==pPos.y && living){
            float xChange = RB.position.x-sc.RB.position.x;
            float zChange = RB.position.z-sc.RB.position.z;
            RB.AddForce(-50*(xChange)/((float)Math.Sqrt(xChange*xChange+zChange*zChange)),0,-50*(zChange)/((float)Math.Sqrt(xChange*xChange+zChange*zChange)));
        }
    }
    void OnMouseDown(){
        float xChange = RB.position.x-sc.RB.position.x;
        float zChange = RB.position.z-sc.RB.position.z;
        if(shoot.ammo>0){
            living = false;
        RB.AddForce(5000*(xChange)/((float)Math.Sqrt(xChange*xChange+zChange*zChange)),0,5000*(zChange)/((float)Math.Sqrt(xChange*xChange+zChange*zChange)));
        }
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "Player" && living){
            Invoke("Lose", 0.1f);
            col.gameObject.SetActive(false);
        }
    }
    void Lose(){
        loseScreen.GetComponent<Canvas>().enabled=true;
        StartCoroutine(Fade()); 
    }
    

    IEnumerator Fade()
    {
        Color c = GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(.1f);
        }
    }
}
