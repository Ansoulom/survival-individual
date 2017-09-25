using UnityEngine;

[RequireComponent(typeof(AudioClipData))]
[RequireComponent(typeof(DeathComponent))]
public class Combateer : MonoBehaviour
{
    public float AttackRange = 1f;
    public float AttackWidth = 0.25f;
    public LayerMask EnemyLayers;
    public float Cooldown = 1f;
    public float KnockbackTime = 0.3f;
    public float KnockbackDistance = 20f;
    public int Health;
    public int MaxHealth = 5;
    public bool Invincible;

    private Timer _cooldownTimer;
    private Timer _knockbackTimer;
    private bool _stunned;


    private void Awake()
    {
        _cooldownTimer = new Timer(Cooldown);
    }


    // Use this for initialization
    private void Start()
    {
        Health = MaxHealth;
    }


    private void Update()
    {
        _cooldownTimer.Update(Time.deltaTime);
        if (_stunned)
        {
            if (_knockbackTimer.Update(Time.deltaTime))
            {
                _stunned = false;
                GetComponent<CharacterInput>().enabled = true;
                GetComponent<TopDownController>().Velocity = Vector2.zero;
                GetComponent<TopDownController>().UsesInput = true;
            }
        }
    }


    public void RestoreHealth()
    {
        Health = MaxHealth;
    }


    public void Attack(int damage)
    {
        if (!_cooldownTimer.IsDone) return;

        InstantiatedAudioPlayer.PlaySound(GetComponent<AudioClipData>(), transform.position);
        
        GetComponent<Animator>().SetTrigger("Attacking");

        _cooldownTimer.Reset();
        var direction = GetComponent<TopDownController>().Direction;
        var collisions =
            Physics2D.OverlapBoxAll(
                new Vector2(transform.position.x, transform.position.y) + direction * (AttackRange / 2),
                new Vector2(AttackWidth, AttackRange), Vector2.SignedAngle(Vector2.up, direction), EnemyLayers);
        foreach (var collision in collisions)
        {
            var target = collision.GetComponent<Combateer>();
            if (target)
            {
                target.TakeDamage(damage);
                var distance = (target.transform.position - transform.position).normalized * KnockbackDistance;
                target.TakeKnockback(new Vector2(distance.x, distance.y), KnockbackTime);
            }
        }
    }


    private void TakeDamage(int damage)
    {
        if (Invincible) return;
        InstantiatedAudioPlayer.PlaySound(GetComponents<AudioClipData>()[1], transform.position);
        Health -= damage;
        if (Health <= 0)
            Kill();
    }


    private void TakeKnockback(Vector2 distance, float time)
    {
        if (Invincible) return;
        var velocity = distance / time;
        GetComponent<CharacterInput>().enabled = false;
        GetComponent<TopDownController>().Velocity = velocity;
        GetComponent<TopDownController>().UsesInput = false;
        _knockbackTimer = new Timer(time);
        _stunned = true;
    }


    private void Kill()
    {
        GetComponent<DeathComponent>().Kill();
    }
}