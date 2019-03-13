using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Player player;

	public void StartAttack()
    {
        player.DamageRange.SetActive(true);
        player.IsSwinging = true;
    }

    public void AttackFinish()
    {
        player.DamageRange.SetActive(false);
        player.IsSwinging = false;
    }
}
