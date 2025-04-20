using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class CharacterBase : MonoBehaviour
{
    private Rigidbody2D rb;

    public float health = 100f;
    public float currentHealth { get; private set; }
    private bool alive = true;

    public float speed = 5f;
    public float timeToMaxSpeed = 0.2f;
    private float acceleration;

    public float rotationSpeed = 720f;
    private float targetAngle;
    private float currentAngle;

    private Vector2 input;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = health;
        SetAcceleration(timeToMaxSpeed);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, input * speed, acceleration * Time.deltaTime);
        currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
        if (!alive)
        {
            rb.linearVelocity = Vector2.zero;
        }
        rb.SetRotation(currentAngle);
    }

    public void Move(Vector2 inp)
    {
        if (!alive) return;
        input = inp.normalized;
    }

    public void Look(Vector2 p)
    {
        if (!alive) return;
        Vector2 dir = p - rb.position;
        targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            Die();
        }
    }

    void Die()
    {
        alive = false;
        rb.linearVelocity = Vector2.zero;
        rotationSpeed = 0;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    void SetAcceleration(float t)
    {
        timeToMaxSpeed = t;
        acceleration = Mathf.Min(speed / timeToMaxSpeed, float.MaxValue);
    }
}
