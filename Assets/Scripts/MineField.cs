using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineField : MonoBehaviour
{
    public int[,] field = new int[10,10];
    public int[,] ammoTile = new int[10,10];
    public int[,] mineCount =new int[10,10];
    // Start is called before the first frame update
    void Start()
    {
        System.Random rnd = new System.Random();
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
                ammoTile[i,j]=0;
                if(rnd.Next(10)<5){
                    field[i,j]= 0;
                }
                else
                    field[i,j]=0;
            }
        }
        field[0,0]=0;
        field[0,1]=1;
        for(int i=1; i<9; i++){
            for(int j=1; j<9; j++){
                mineCount[i,j]=field[i-1,j-1]+field[i-1,j]+field[i-1,j+1]+field[i,j-1]+field[i,j+1]+field[i+1,j-1]+field[i+1,j]+field[i+1,j+1];
            }
        }
        for(int i=1; i<9; i++){
            mineCount[0,i]=field[0,i-1]+field[1,i-1]+field[1,i]+field[1,i+1]+field[0,i+1];
            mineCount[9,i]=field[9,i-1]+field[8,i-1]+field[8,i]+field[8,i+1]+field[8,i+1];
            mineCount[i,0]=field[i-1,0]+field[i-1,1]+field[i,1]+field[i+1,1]+field[i+1,0];
            mineCount[i,9]=field[i-1,9]+field[i-1,8]+field[i,8]+field[i+1,8]+field[i+1,9];
        }
        mineCount[0,0]=field[1,0]+field[0,1]+field[1,1];
        mineCount[9,9]=field[9,8]+field[8,9]+field[8,8];
        mineCount[0,9]=field[1,9]+field[0,8]+field[1,8];
        mineCount[9,0]=field[9,1]+field[8,0]+field[8,1];
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
                if(rnd.Next(45)==0&&field[i,j]==0){
                    ammoTile[i,j]=1;
                }
            }
        }
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }
}
