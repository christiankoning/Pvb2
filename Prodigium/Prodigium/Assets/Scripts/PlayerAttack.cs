using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Player player;
    public SoundManager SManager;

    void Start()
    {
        SManager.AudioSwordSwing = SManager.AddAudio(SManager.Punch, false, 0.2f);
    }

    public void StartAttack()
    {
        player.DamageRange.SetActive(true);
        player.IsSwinging = true;
        SManager.AudioSwordSwing.Play();
    }

    public void AttackFinish()
    {
        player.DamageRange.SetActive(false);
        player.IsSwinging = false;
    }
}
