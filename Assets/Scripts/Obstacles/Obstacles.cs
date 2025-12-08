using System;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    public bool cultistaCentro;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (cultistaCentro)
        {
            float distance = Vector3.Distance(Game_Manager.Instance.Player.gameObject.transform.position, transform.position);
            if (distance < 5) animator.SetTrigger("Attack");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
