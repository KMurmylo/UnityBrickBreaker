using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;

public class LevelGenerator : MonoBehaviour
{   [SerializeField]
    private GameObject blue;
    [SerializeField]
    private GameObject red;
    [SerializeField]
    private GameObject green;
    [SerializeField]
    private Transform levelParent;


    Dictionary<string, GameObject> blocksD;
    
    private List<string[,]> levels=new List<string[,]>();

    public void GenerateLevel(int level)
    {
        string[,] currentLevel = levels[level];
        for(int i=0;i<5;i++)
        {
            for(int j = 0; j < 13; j++)
            {   if(currentLevel[i, j]!=null)
                Instantiate(blocksD[currentLevel[i,j]], new Vector3(-13.2f+2.2f*j, 4-0.7f*i, 1), Quaternion.identity).transform.parent=levelParent;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        

        blocksD=new Dictionary<string, GameObject>();
        blocksD.Add("r", red);
        blocksD.Add("g", green);
        blocksD.Add("b", blue);

        ReadLevels();
        GenerateLevel(1);     
   
        
    }
    
// Update is called once per frame
void Update()
    {
        
    }

void ReadLevels(string path="Assets/Levels/levels.txt")
    {
        
            string[,] level = new string[5, 13];
            int i = 0;
            int j = 0;
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach(string line in lines)
            {if (line[0] == '-') continue;
            foreach(char c in line)
                    {
                if (c == ' ') { level[i, j] = null; }
                else
                {
                    level[i, j] = c.ToString();}
                    j++;
                
                    }
         
            j = 0;
            i++;
            if(i == 5)
            {   //Debug.Log("Added: "+i);
                levels.Add(level);
                level = new string[5, 13];
                //Debug.Log(levels.Count);
                i = 0;
            }
            }
            
    
    }
}
