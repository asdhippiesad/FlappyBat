using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
            Destroy(gameObject);
    }
}

