using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject canvas;
    int flag;
    // Start is called before the first frame update
    void Start()
    {
        flag=1;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown("m")){
            Invoke("mapOpen", 0.05f);
        }
    }
    void mapOpen(){
        if(flag==1){
            canvas.GetComponent<Canvas>().enabled=false;
            flag=0;
        }
        
        else if(flag==0){
            canvas.GetComponent<Canvas>().enabled=true;
            flag=1;
        }
    }
}
