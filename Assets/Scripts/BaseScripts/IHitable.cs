using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable {

    void OnGetHit (HitType type);
    void Die();

}
