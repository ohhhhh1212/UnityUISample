using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    void Test()
    {
        // 이거 보이면 성공!!
    }


    [SerializeField] Transform hell = null;
    [SerializeField] Text txt = null;

    public float speed = 5f;
    public float rot = 30f;
    public int scal = 10;

    private void Update()
    {
        Move();
        Rotation();
        Scale();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 pos = new Vector3(x, y, 0f);
        pos.Normalize();

        hell.Translate(pos * Time.deltaTime * speed, Space.World);
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.B))
        {
            hell.Rotate(new Vector3(0f, 0f, rot));
        }
    }

    void Scale()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            int size = txt.fontSize + scal;
            txt.fontSize = size;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (txt.fontSize - scal <= 0)
                return;

            int size = txt.fontSize - scal;
            txt.fontSize = size;
        }
    }
}
