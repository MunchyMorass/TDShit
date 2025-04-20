using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public float range;
    private float lifetime;
    void Start()
    {
        lifetime = range / speed;
    }

    void Update()
    {
        RaycastHit2D p = Physics2D.Raycast(transform.position, transform.right);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CharacterBase character;
        if (TryGetComponent<CharacterBase>(out character))
        {
            character.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
