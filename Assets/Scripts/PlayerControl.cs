using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float hatLeftOut;
    private Camera cam;
    private Rigidbody2D rigidbody2D;

    private float maxWidth;
    private void Start()
    {
        if (cam == null)
            cam = Camera.main;

        rigidbody2D = GetComponent<Rigidbody2D>();

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 cornerPosition = cam.ScreenToWorldPoint(upperCorner);

        //获取帽子出线的部分，然后减去
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;

        maxWidth = cornerPosition.x - hatWidth;
    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 targetPosition = new Vector3(mousePosition.x, 0.0f, 0.0f);

        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth + hatLeftOut, maxWidth);

        targetPosition = new Vector3(targetWidth, transform.position.y, transform.position.z);

        rigidbody2D.MovePosition(targetPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }




























    //public Camera cam;
    //private Rigidbody2D rigidbody2D;
    //private float maxWidth;

    //private void Start()
    //{
    //    if(cam == null)
    //        cam = Camera.main;

    //    rigidbody2D = GetComponent<Rigidbody2D>();
    //    Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
    //    Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
    //    float hatWidth = GetComponent<Renderer>().bounds.extents.x;
    //    maxWidth = targetWidth.x - hatWidth;

    //}
    //private void FixedUpdate()
    //{
    //    Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    //    Debug.Log(mousePosition);
    //    Vector3 targetPosition = new Vector3(mousePosition.x, 0.0f, 0.0f);
    //    float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
    //    targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);

    //    rigidbody2D.MovePosition(targetPosition);
    //}
}
