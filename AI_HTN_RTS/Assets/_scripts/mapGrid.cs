using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGrid : MonoBehaviour {

    public Node[,] grid= new Node[30,30];
    int i, j;
   
    Vector3 pos = new Vector3();

    public GameObject tree1, tree2, tree3;
    public GameObject gold1, gold2;
    public GameObject rock1, rock2, rock3;

    public GameObject house;
    public GameObject human;

    //spawn different resources at random location
    void SpawnResources(GameObject resource, NodeState resourceState, int x, int y)
    {
        for (i = x; i < x + 3; i++)
        {
            for (j = y; j < y + 3; j++)
            {
                pos = new Vector3(grid[i, j].xPos, 0, grid[i, j].zPos);
                grid[i, j].nodeState = resourceState;
                Instantiate(resource, pos, transform.rotation);
            }
        }
    }
    
	// Use this for initialization
	void Start () {

        //assign grid values
        for (i = 0; i < 30; ++i)
        {
            for (j = 0; j < 30; ++j)
            {
                Node node = new Node();
                node.xPos = i*10 ;
                node.zPos = j*10;
                node.nodeState = NodeState.EMPTY;
                grid[i, j] = node;

            }
        }

        //spawn trees
        SpawnResources(tree1, NodeState.TREE, 3, 23);
        SpawnResources(tree2, NodeState.TREE, 25, 5);
        //SpawnResources(tree3, NodeState.TREE, 3);
        
        //spawn gold mine
        SpawnResources(gold1, NodeState.GOLD, 8, 9);
        SpawnResources(gold2, NodeState.GOLD, 20, 18);

        //spawn quarry
        SpawnResources(rock1, NodeState.ROCK, 13, 6);
        SpawnResources(rock2, NodeState.ROCK, 18, 27);
        //  SpawnResources(rock3, NodeState.ROCK, 2);

        Instantiate(house, new Vector3(150.0f,0.0f,150.0f), Quaternion.Euler(-90, 0, 0));

    }

    // Update is called once per frame
    void Update () {
		
	}
}
