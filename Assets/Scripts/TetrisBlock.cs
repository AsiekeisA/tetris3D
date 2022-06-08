using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    float prevTime;
    float fallTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        ButtonInput.instance.SetActiveBlock(gameObject, this);
        fallTime = GameManager.instance.ReadSpeed();
        if(!CheckValidMove())
        {
            GameManager.instance.SetGameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - prevTime >fallTime)
        {
            transform.position += Vector3.down;
            if (!CheckValidMove())
            {
                //transform.position += Vector3.down;
                Playfield.instance.DeleteLayer();
                enabled = false;
                if(!GameManager.instance.ReadGameOver())
                {
                    Playfield.instance.SpawnNewBlock();
                }
                
            }
            else
            {
                Playfield.instance.UpdateGrid(this);
            }
            prevTime = Time.time;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            SetInput(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetInput(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetInput(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetInput(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetRotation(new Vector3(-90, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetRotation(new Vector3(0, 90, 0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetRotation(new Vector3(0, 0, -90));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetSpeed();
        }


    }

    public void SetInput(Vector3 direction)
    {
        transform.position += direction;
        if(!CheckValidMove())
        {
            transform.position -= direction;
        }
        else
        {
            Playfield.instance.UpdateGrid(this);
        }
    }

    public void SetRotation(Vector3 rotation)
    {
        transform.Rotate(rotation,Space.World);
        if(!CheckValidMove())
        {
            transform.Rotate(-rotation, Space.World);
        }
        else
        {
            Playfield.instance.UpdateGrid(this);
        }
    }

    bool CheckValidMove()
    {
        foreach(Transform child in transform)
        {
            Vector3 pos = Playfield.instance.Round(child.position);
            if (!Playfield.instance.CheckInsideGrid(pos))
            {
                return false;
            }
        }

        foreach(Transform child in transform)
        {
            Vector3 pos = Playfield.instance.Round(child.position);
            Transform t = Playfield.instance.GetTransformOnGridPos(pos);
            if (t!= null && t.parent !=transform)
            {
                return false;
            }
        }
        return true;
    }

    public void SetSpeed()
    {
        fallTime = 0.1f;
    }
}
