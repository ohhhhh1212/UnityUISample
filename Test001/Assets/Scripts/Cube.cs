using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] Transform cube = null;
    public float speed = 5f;
    public float rot = 30f;
    public float scal = 1f;

    private void Update()
    {
        Move();
        Rotation();
        if (Input.GetKeyDown(KeyCode.J))
        {
            Scale(true);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Scale(false);
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 pos = new Vector3(x, y, 0f);
        pos.Normalize();

        cube.Translate(pos * Time.deltaTime * speed, Space.World);
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.U))
        {
            cube.Rotate(new Vector3(rot, 0f, 0f));
        }
        if (Input.GetKey(KeyCode.I))
        {
            cube.Rotate(new Vector3(0f, rot, 0f));
        }
        if (Input.GetKey(KeyCode.O))
        {
            cube.Rotate(new Vector3(0f, 0f, rot));
        }
    }

    void Scale(bool plus)
    {
        Vector3 s = cube.localScale;
        Vector3 scale = Vector3.zero;

        if (plus)
        {
            scale = new Vector3(s.x + scal, s.y + scal, s.z + scal);
        }
        else
        {
            if (s.x - scal <= 0)
                return;

            scale = new Vector3(s.x - scal, s.y - scal, s.z - scal);
        }

        cube.localScale = scale;
    }
}
