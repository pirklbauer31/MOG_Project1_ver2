using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {


    private Text playerHPText;
    Subscription<HealthUpdate> notificationToken;

    // Use this for initialization
    void Start () {

        notificationToken = EventAggregator.SingletionAggregator.Subscribe<HealthUpdate>(this.updateHealth);
        playerHPText = GetComponent<Text>();
    }
    public void updateHealth(HealthUpdate u) { playerHPText.text = u.Health.ToString(); }

}
