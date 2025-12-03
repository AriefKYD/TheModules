using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerExample : MonoBehaviour
{
    private Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon = new Pistol();
        weapon.InitWeapon();
    }
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            weapon.Attack();
        }
    }
}

//Interface
public interface IReload
{
    public void Reload();
}

//Interface
public interface IDamageable
{
    public void Damaged();
}

//Child Class
public class Sword : Weapon, IDamageable
{
    public override void Attack()
    {
        Debug.Log("Attack Sword");
    }

    public void Damaged()
    {
    }

    public override void InitWeapon()
    {
        Debug.Log("Use Sword");
    }
}

//Child Class
public class Pistol : Weapon, IReload
{
    private int maxMag = 10;
    private int curMag = 10;
    public override void Attack()
    {
        curMag--;
        if(curMag<=0)
        {
            Reload();
        }
        Debug.Log("Attack Pistol");
    }

    public override void InitWeapon()
    {
        Debug.Log("Use Pistol");
    }

    public void Reload()
    {
        curMag = maxMag;
        Debug.Log("Reload Pistol");
    }
}


//Base Class
public abstract class Weapon
{
    public abstract void InitWeapon();
    public abstract void Attack();
}