# TreeProblem

## Description
Problem given to solve by Neuroscouting.  
This is a relatively simple programming problem written in C# where I create a tree where each node has two children and the values of each node are determined by adding the parent of the node's value with the node's parent's right or left neighbor depending on which side the node is on. The program accepts user input to determine how many levels down that the tree goes.

##Organization
I have three classes: a Node, a Tree and the test class. 

The node contains the small amount of information that each node needs to have such as its parent and its children along with its value. It also contains a simple function that returns whether the node is a leaf.

The tree class contains all the functionallity of the tree itself. It has three properties: the root node of the entire tree, the data contained within the tree, and the total number of levels that the tree will have. It creates the tree by first filling all levels with the default nodes and then goes back and fills in the data so that it only tries to fill in the value when you know that each node will be able to find the ones it relies on and that they are set. In the case where one isn't set by the time a node needs it to be, it will set that node then skip over it later on in the data filling method.




