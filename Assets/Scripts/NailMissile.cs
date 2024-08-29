using UnityEngine;

public class NailMissile : MonoBehaviour
{
    public float speed = 10f;
    public Transform target;
    public int attackDamage = 10; // Daño del misil, igual al del ataque melee.

    void Start()
    {
        // Destruir el misil después de 5 segundos
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            transform.LookAt(target);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene el componente "PlayerHealthController"
        PlayerHealthController playerHealth = collision.gameObject.GetComponent<PlayerHealthController>();
        if (playerHealth != null)
        {
            // Aplicar daño al jugador
            playerHealth.DecreaseHealth(attackDamage);
        }

        // Destruir el misil después de colisionar
        Destroy(gameObject);
    }
}
