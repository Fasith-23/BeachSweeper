using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    int[,] flag_count = new int[10,10];
    int count=0;
    int max_count=100;
    public sceneChanger SC;
    public MineField mf;
    public GameObject winScreen;
    void Start()
    {
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
                flag_count[i,j]=0;
            }
        }
        Invoke("maxCounter", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(flag_count[(int)SC.playerPos.x,(int)SC.playerPos.y]==0&&mf.field[(int)SC.playerPos.x,(int)SC.playerPos.y]==0){
            count++;
            flag_count[(int)SC.playerPos.x,(int)SC.playerPos.y]=1;
        }
        if(count==max_count){
            Invoke("win", 0.1f);
        }
    }
    void maxCounter(){
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
                if(mf.mineCount[i,j]==1){
                    max_count--;
                }
            }
        }
    }
    void win(){
        winScreen.GetComponent<Canvas>().enabled=true;
    }
}
