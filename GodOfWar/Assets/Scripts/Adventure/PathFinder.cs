using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField]
    private Transform path;
    [SerializeField]
    private float speed =5f;
    List<Transform> pathPointList = new List<Transform>();

    private int index = 0;
    bool direction = false;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        foreach(Transform child in path)
        {
            pathPointList.Add(child);
        }
        if(pathPointList.Count > 0)
        {
            transform.position = pathPointList[0].position;
        }
    }
    void Update()
    {
        if (!direction)
        {
            if (index < pathPointList.Count - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, pathPointList[index + 1].position, speed * Time.deltaTime);
                if (transform.position.x - pathPointList[index + 1].position.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
                if (transform.position == pathPointList[index + 1].position)
                {
                    index++;
                }
            }
            else
            {
                direction = true;
            }
        }
        else
        {
            if(index < pathPointList.Count)
            {
                transform.position = Vector2.MoveTowards(transform.position, pathPointList[index].position, speed * Time.deltaTime);
                if (transform.position.x - pathPointList[index].position.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
                if (transform.position == pathPointList[index].position)
                {
                    index--;
                }
            }
            if(index == 0)
            {
                direction = false;
            }
        }
    }
}
