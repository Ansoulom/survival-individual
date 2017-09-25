using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class TopDownController : MonoBehaviour
{
    private Vector2 _input;

    public Vector2 Velocity { get; set; }
    public float MaxSpeed = 5f;
    public Vector2 Direction { get; private set; }
    public bool UsesInput { get; set; }


    public Vector2 Input
    {
        get { return _input; }
        set
        {
            _input = value.normalized;
            if (_input.magnitude > 0f) Direction = _input;
        }
    }


    private void Awake()
    {
        UsesInput = true;
    }


    // Use this for initialization
    private void Start()
    {
        Velocity = Vector2.zero;
    }


    // Update is called once per frame
    private void Update()
    {
        if(UsesInput) Velocity = _input * MaxSpeed;
        var sprite = GetComponent<SpriteRenderer>();
        if (Velocity.x > 0f)
            sprite.flipX = false;
        else if (Velocity.x < 0f)
            sprite.flipX = true;
    }


    private void FixedUpdate()
    {
        Move();
        GetComponent<Rigidbody2D>().position = transform.position;
    }


    private void Move()
    {
        transform.position += new Vector3(Velocity.x, Velocity.y, 0f) * Time.deltaTime;
    }
}