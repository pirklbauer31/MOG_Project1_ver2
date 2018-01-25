using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHitable {

    void OnGetHit (HitType type);
    void Die();

}
