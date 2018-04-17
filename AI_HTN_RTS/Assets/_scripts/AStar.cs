using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// enum to state the current element on the node
public enum NodeState {
    EMPTY,    //nothing on the node
    OBSTACLE, //mountain on the node where nothing can be built
    TREE,     //tree on the node
    ROCK,     //quarry on the node
    GOLD,     //gold mine on the node
    BUILDING  //building present on the node
}

public struct Node {
   public int xPos; // node position in the x-direction
   public int zPos; // node position in the z-direction

   public NodeState nodeState;
}
