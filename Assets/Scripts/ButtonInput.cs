using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public static ButtonInput instance;

    public GameObject[] rotateCanvas;
    public GameObject moveCanvas;

    GameObject activeBlock;
    TetrisBlock activeTetris;

    void Awake()
    {
        instance = this;
    }

    void RepositionToActiveBlock()
    {
        if(activeBlock!=null)
        {
            transform.position = activeBlock.transform.position;
        }
    }

    public void SetActiveBlock(GameObject block, TetrisBlock tetris)
    {
        activeBlock = block;
        activeTetris = tetris;
    }

    void Update()
    {
        RepositionToActiveBlock();
    }

    public void MoveBlock(string direction)
    {
        if(activeBlock != null)
        {
            if(direction == "left")
            {
                activeTetris.SetInput(Vector3.left);
            }
            if (direction == "right")
            {
                activeTetris.SetInput(Vector3.right);
            }
            if (direction == "forward")
            {
                activeTetris.SetInput(Vector3.forward);
            }
            if (direction == "back")
            {
                activeTetris.SetInput(Vector3.back);
            }
        }
    }
    
    public void RotateBlock(string rotation)
    {
        if(activeBlock != null)
        {
            if(rotation == "X")
            {
                activeTetris.SetRotation(new Vector3(-90, 0, 0));
            }
            if (rotation == "Y")
            {
                activeTetris.SetRotation(new Vector3(0, 90, 0));
            }
            if (rotation == "Z")
            {
                activeTetris.SetRotation(new Vector3(0, 0, -90));
            }
        }
    }
}
