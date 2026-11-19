using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float zoneAreaValue = 0.5f;

    private NavMeshAgent agent;
    private Animator animator;
    private SphereCollider zoneVisibility;
    private bool isChasing = false; // Флаг, преследуем ли мы игрока сейчас

    private static readonly int TuchPlayer = Animator.StringToHash("TuchPlayer");
    private static readonly int PlayerIsDead = Animator.StringToHash("PlayerIsDead");
    private static readonly int SeePlayer = Animator.StringToHash("SeePlayer");
    private static readonly int Velocity = Animator.StringToHash("Velocity");

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zoneVisibility = GetComponentInChildren<SphereCollider>();

        if (zoneVisibility != null)
        {
            zoneVisibility.radius = zoneAreaValue;
        }
    }

    private void Update()
    {
        // Постоянно передаем текущую скорость в Animator (даже когда враг останавливается)
        animator.SetFloat(Velocity, agent.velocity.magnitude);
        if (isChasing && player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что в зону вошел именно игрок
        if (other.CompareTag(player.tag))
        {
            Debug.Log("Вижу");
            isChasing = true;
            animator.SetBool(SeePlayer, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, что из зоны вышел именно игрок
        if (other.CompareTag(player.tag))
        {
            Debug.Log("Не Вижу");
            isChasing = false;
            animator.SetBool(SeePlayer, false);
            agent.SetDestination(player.transform.position);
        }
    }
}