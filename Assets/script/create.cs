using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour
{

    public GameObject b7;
    public GameObject b5;
    public GameObject tow;
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public byte count = 30;
    public int TypeRange = 6;
    GameObject newBlock;
    Vector2 position;
    int b = 0, i, Type;
    byte Method;

    void Start()
    {
        StartCoroutine(OnGeneratingRoutine());
    }

    private IEnumerator OnGeneratingRoutine()
    {

        position = new Vector2(0, 0);

        newBlock = Instantiate(b7);
        newBlock.transform.position = position;


        for (i = 0; i < count; i++)
        {
            Type = Random.Range(0, TypeRange);
            switch (Type)
            {
                case 0:
                    StartCoroutine(GenerateBlock(b7));
                    break;
                case 1:
                    StartCoroutine(GenerateRoom(r1));
                    break;
                case 2:
                    StartCoroutine(GenerateRoom(r2));
                    break;
                case 3:
                    StartCoroutine(GenerateRoomDown(r3));
                    break;
                case 4:
                    Method = 1;
                    StartCoroutine(GenerateTonnel(t1));
                    break;
                case 5:
                    Method = 2;
                    StartCoroutine(GenerateTonnel(t2));
                    break;
                default:
                    StartCoroutine(Platform(b5));
                    break;
            }
        }
        yield return new WaitForEndOfFrame();
    }
    private IEnumerator Platform(GameObject Block)
    {
        switch (b)
        {
            case 0:
                position.x += 0.733f;
                position.y += 0.2f;
                break;
            case 1:
                position.x += 1.5f;
                position.y -= 0.907f;
                break;
            case 2:
                position.x += 1.498f;
                position.y += 0.908f;
                break;
            case 3:
                position.x += 1.5f;
                position.y -= 0.907f;
                break;
            case 4:
                position.x += 1f;
                position.y += 0.419f;
                break;
            case 5:
                position.x += 1f;
                position.y -= 1.41f;
                break;
            case 29:
                position.x += Block.GetComponent<BoxCollider2D>().size.x;
                break;
        }
        newBlock = Instantiate(Block);
        newBlock.transform.position = position;
        b = 29;
        yield return new WaitForEndOfFrame();
    }
    private IEnumerator GenerateBlock(GameObject Block)
    {

        switch (b)
        {
            case 0:
                position.x += Block.GetComponent<BoxCollider2D>().size.x;
                position.y += Block.GetComponent<BoxCollider2D>().size.y * Random.Range(-1, 2);
                break;
            case 1:
                position.x += 1.234f;
                position.y -= 1.107f;
                break;
            case 2:
                position.x += 1.23f;
                position.y += 0.707f;
                break;
            case 3:
                position.x += 1.234f;
                position.y -= 1.107f;
                break;
            case 4:
                position.x += 0.735f;
                position.y += 0.219f;
                break;
            case 5:
                position.x += 0.735f;
                position.y -= 1.61f;
                break;
            case 29:
                position.x += 0.734f;
                position.y += 0.2f * Random.Range(-1,1);
                break;

        }
        newBlock = Instantiate(Block);
        newBlock.transform.position = position;
        b = Type;
        yield return new WaitForEndOfFrame();
    }
    private IEnumerator GenerateRoom(GameObject Block)
    {

        switch (b)
        {
            case 0:
                position.x += 1.23f;
                position.y += 1.11f;
                break;
            case 1:
                position.x += Block.GetComponent<BoxCollider2D>().size.x;
                break;
            case 2:
                position.x += Block.GetComponent<BoxCollider2D>().size.x;
                position.y += Block.GetComponent<BoxCollider2D>().size.y - 0.186f;
                break;
            case 3:
                position.x += Block.GetComponent<BoxCollider2D>().size.x;
                break;
            case 4:
                position.x += 1.5f;
                position.y += 1.327f;
                break;
            case 5:
                position.x += 1.5f;
                position.y -= 0.5f;
                break;
            case 29:
                if (Block == r1)
                {
                    position.x += 1.499f;
                }
                else
                {
                    position.x += 1.5006f;
                }
                position.y += 0.907f;
                break;
        }
        newBlock = Instantiate(Block);
        newBlock.transform.position = position;
        b = Type;
        yield return new WaitForEndOfFrame();
    }
    private IEnumerator GenerateRoomDown(GameObject Block)
    {
        switch (b)
        {
            case 0:
                position.x += 1.234f;
                position.y -= 0.71f;
                break;
            case 1:
                position.x += Block.GetComponent<BoxCollider2D>().size.x;
                position.y -= 1.82f;
                break;
            case 2:
                position.x += Block.GetComponent<BoxCollider2D>().size.x;
                break;
            case 4:
                position.x += 1.5f;
                position.y -= 0.4906f;
                break;
            case 5:
                position.x += 1.5f;
                position.y -= 2.32f; 
                break;
            case 29:
                position.x += 1.5006f;
                position.y -= 0.907f;
                break;
        }
        newBlock = Instantiate(Block);
        newBlock.transform.position = position;
        if (b == Type && Type == 3)
        {
            Destroy(this.newBlock);
            i--;
        }
        else b = Type;
        yield return new WaitForEndOfFrame();
    }
    private IEnumerator GenerateTonnel(GameObject Block)
    {
        newBlock = Instantiate(Block);
        switch (Method)
        {
            case 1:
                switch (b)
                {
                    case 2:
                        position.x += 0.5f;
                        position.y += 2.5f;
                        b = Type;
                        break;
                    default:
                        Destroy(this.newBlock);
                        i--;
                        break;
                }
                break;
            case 2:
                switch (b)
                {
                    case 1:
                        position.x += 1.5f;
                        position.y -= 1.32f;
                        b = Type;
                        break;
                    case 3:
                        position.x += 1.5f;
                        position.y -= 1.32f;
                        b = Type;
                        break;
                    default:
                        Destroy(this.newBlock);
                        i--;
                        break;
                }
                break;
        }
        newBlock.transform.position = position;
        yield return new WaitForEndOfFrame();
    }
}
