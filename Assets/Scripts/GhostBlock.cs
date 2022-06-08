using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : MonoBehaviour
{
    GameObject parenter;
    TetrisBlock parentTetris;
    private static GhostBlock instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(RepositionBlock());
    }

    public void SetParent(GameObject _parent)
    {
        parenter = _parent;
        parentTetris = parenter.GetComponent<TetrisBlock>();
    }

    void PositionGhost()
    {
        transform.position = parenter.transform.position;
        transform.rotation = parenter.transform.rotation;
    }

    IEnumerator RepositionBlock()
    {
        while (parentTetris.enabled)
        {
            PositionGhost();

            MoveDown();
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
        yield return null;
    }

    void MoveDown()
    {
        while (CheckValidMove())
        {
            transform.position += Vector3.down;
        }
        //if (!CheckValidMove())
        //{
        //    transform.position += Vector3.up;
        //}
    }

    bool CheckValidMove()
    {
        foreach (Transform child in transform)
        {
            Vector3 pos = Playfield.instance.Round(child.position);
            if (!Playfield.instance.CheckInsideGrid(pos))
            {
                return false;
            }
        }

        foreach (Transform child in transform)
        {
            Vector3 pos = Playfield.instance.Round(child.position);
            Transform t = Playfield.instance.GetTransformOnGridPos(pos);

            if (t != null && t.parent == parenter.transform)
            {
                return true;
            }

            if (t != null && t.parent != transform)
            {
                return false;
            }
        }
        return true;
    }
}
