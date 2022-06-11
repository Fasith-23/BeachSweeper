using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flag : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Transform childtr= this.transform.GetChild(1);
        GameObject child= childtr.gameObject;
        if(child.activeSelf){
            child.SetActive(false);
        }
        else{
            child.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void flag(){
        Transform childtr= this.transform.GetChild(1);
        GameObject child= childtr.gameObject;
        if(child.activeSelf){
            child.SetActive(false);
        }
        else{
            child.SetActive(true);
        }
    }
}
