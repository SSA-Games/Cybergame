using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantheon : AbstractEnemy
{
    private void Awake()
    {
        Invulnurable = false;
        InBattle = false;
        Talkable = false;
    }
    protected override void Update() //Сначала вызываем оригинальную функцию, потом дополняем ее
    {
        base.Update();
    }
}