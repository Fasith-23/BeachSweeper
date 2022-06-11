using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sceneChanger : MonoBehaviour
{   
    public Vector2 playerPos= new Vector2 (5,5);
    public Rigidbody RB;
    public Text posText;
    public MineField minefield;
    public Shooting shoot;
    TextMeshPro Text;
    //Vector2 N= new Vector2(0,1);
    //Vector2 E= new Vector2(1,0);
    // Start is called before the first frame update
    void Start()
    {
        posText.text = "(" + playerPos.x.ToString() + "," + playerPos.y.ToString() + ")\n Nearby Mines:" + minefield.mineCount[(int)playerPos.x,(int)playerPos.y];
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
                GameObject btn =GameObject.Find("Button"+(i*10+j));
                btn.GetComponent<Image>().color = new Color(1,1,1);
            }
        }
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
                GameObject txt =GameObject.Find("text"+(i*10+j));
                Text =txt.GetComponent<TextMeshPro>();
                Text.text="?";
                txt.GetComponent<RectTransform>().anchoredPosition =Vector3.zero;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerPos= new Vector2((int)(RB.position.x/12.5),(int)(RB.position.z/12.5));
        posText.text = "(" + playerPos.x.ToString() + "," + playerPos.y.ToString() + ")\n Nearby Mines:" + minefield.mineCount[(int)playerPos.x,(int)playerPos.y];
        if(minefield.ammoTile[(int)playerPos.x,(int)playerPos.y]==1){
            shoot.ammo+=1;
            minefield.ammoTile[(int)playerPos.x,(int)playerPos.y]=0;
        }
        GameObject btn =GameObject.Find("Button"+(playerPos.y*10+playerPos.x));
        btn.GetComponent<Image>().color = new Color(0.3f,0.3f,0.3f);
    }
    //void Transition(Vector2 Trans){
      //  playerPos = playerPos + Trans;
    //}
    /*void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "NE"){
            playerPos = playerPos + N + E;
        }
        if(other.gameObject.name == "N"){
            playerPos = playerPos + N;
        }
        if(other.gameObject.name == "SE"){
            playerPos = playerPos + E - N;
        }
        if(other.gameObject.name == "S"){
            playerPos = playerPos - N;
        }
        if(other.gameObject.name == "E"){
            playerPos = playerPos + E;
        }
        if(other.gameObject.name == "W"){
            playerPos = playerPos - E;
        }
        if(other.gameObject.name == "SW"){
            playerPos = playerPos - N - E;
        }
        if(other.gameObject.name == "NW"){
            playerPos = playerPos - E + N;
        }
        posText.text = "(" + playerPos.x.ToString() + "," + playerPos.y.ToString() + ")\n Nearby Mines:" + minefield.mineCount[(int)playerPos.x,(int)playerPos.y];
    }*/
}
