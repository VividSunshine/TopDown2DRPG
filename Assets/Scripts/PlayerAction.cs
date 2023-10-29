using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    public GameManager manager;

    Rigidbody2D rigid;
    Animator anim;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;

    //Mobile Key Var
    int up_Value;
    int down_Value;
    int left_Value;
    int right_Value;
    bool up_down;
    bool down_down;
    bool left_down;
    bool right_down;
    bool up_up;
    bool down_up;
    bool left_up;
    bool right_up;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Move Value
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal") + right_Value + left_Value;
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical") + up_Value + down_Value;

        //Check Button Down & Up
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal") || right_down || left_down;
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical") || up_down || down_down;
        bool hUp = manager.isAction ? false : Input.GetButtonDown("Horizontal") || right_up || left_up;
        bool vUp = manager.isAction ? false : Input.GetButtonDown("Vertical") || up_up || down_up;

        //Check Horizontal Move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        //Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v) {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);

        //Direction
        if(vDown && v == 1)
            dirVec = Vector3.up;
        else if(vDown && v == -1)
            dirVec = Vector3.down;
        else if(hDown && h == -1)
            dirVec = Vector3.left;
        else if(hDown && h == 1)
            dirVec = Vector3.right;

        //Scan Object & Action
        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);

        //Mobile Var Init
        up_down = false;
        down_down = false;
        left_down = false;
        right_down = false;
        up_up = false;
        down_up = false;
        left_up = false;
        right_up = false;
    }

    void FixedUpdate()
    {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;
        Debug.Log(h);
        Debug.Log(v);

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }

    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 1;
                up_down = true;
                break;
            case "D":
                down_Value = -1;
                down_down = true;
                break;
            case "L":
                left_Value = -1;
                left_down = true;
                break;
            case "R":
                right_Value = 1;
                right_down = true;
                break;
            case "A":
                if(scanObject != null)
                {
                    manager.Action(scanObject);
                }
                break;
            case "C":
                manager.SubMenuActive();
                break;
        }
    }

    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 0;
                up_up = true;
                break;
            case "D":
                down_Value = 0;
                down_up = true;
                break;
            case "L":
                left_Value = 0;
                left_up = true;
                break;
            case "R":
                right_Value = 0;
                right_up = true;
                break;
        }
    }
}