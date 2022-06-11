using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawn : MonoBehaviour
{
    public MineField minefield;
    public Rigidbody[] rb;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("animalLocation",0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void animalLocation(){
        int x=0;
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
                if(minefield.field[i,j]==1){
                    rb[x].position= new Vector3(10*i+5,1, 10*j+5);
                    x++;
                }
            }
        }
    }
}
