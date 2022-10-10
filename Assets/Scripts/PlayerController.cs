using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float Speed;
    [SerializeField] private float StartDashTime;
    [SerializeField] private float DashTime;
    [SerializeField] private float ExtraSpeed;
    [SerializeField] private bool IsDashing;

    private float input;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (input > 0 )
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }else if (input < 0){
            transform.eulerAngles = new Vector3(0,180,0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsDashing == false){
            Speed += ExtraSpeed;
            IsDashing = true;
            DashTime = StartDashTime;
        }

        if(DashTime <= 0 && IsDashing == true){
            IsDashing = false;
            Speed -= ExtraSpeed;
        }
        else {
            DashTime-= Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        //Player Input
        input = Input.GetAxisRaw("Horizontal");

        //Moving Player
        rb.velocity = new Vector2(input * Speed, rb.velocity.y);
    }
}
