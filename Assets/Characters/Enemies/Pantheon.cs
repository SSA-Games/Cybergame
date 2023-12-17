using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantheon : CharacterInstance
{
    // EXAMPLE OF AN ENEMY FOR DEBUGGING
    protected override void Update() //Сначала вызываем оригинальную функцию, потом дополняем ее
    {
        base.Update();
    }
}