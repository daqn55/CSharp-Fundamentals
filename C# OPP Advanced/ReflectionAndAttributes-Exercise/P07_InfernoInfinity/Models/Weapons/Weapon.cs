using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


public abstract class Weapon
{
    private int maxSockets;

    protected Weapon(int minDamage, int maxDamage, int maxSockets, string name)
    {
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.maxSockets = maxSockets;
        this.Sockets = new List<Gem>(this.maxSockets);
        for (int i = 0; i < maxSockets; i++)
        {
            this.Sockets.Add(null);
        }
        this.Name = name;
    }

    public string Name { get; }

    public int MinDamage { get; private set; }

    public int MaxDamage { get; private set; }

    public List<Gem> Sockets { get; private set; }

    public void AddGemToSocket(Gem gem, int indexSocket)
    {
        if (indexSocket >= 0 && indexSocket < this.maxSockets)
        {
            if (Sockets[indexSocket] != null)
            {
                Sockets[indexSocket].WeaponDecreasesDamage(this);
                Sockets[indexSocket] = gem;
                Sockets[indexSocket].WeaponIncreasesDamageDependOfGemType(this);
            }
            else
            {
                Sockets[indexSocket] = gem;
                Sockets[indexSocket].WeaponIncreasesDamageDependOfGemType(this);
            }
        }
    }

    public void RemoveGemFromSocket(int indexSocket)
    {
        if (indexSocket >= 0 && indexSocket < this.maxSockets)
        {
            Sockets[indexSocket] = null;
        }
    }

    public void IncreasedDamage(int increasesDmg)
    {
        this.MinDamage *= increasesDmg;
        this.MaxDamage *= increasesDmg;
    }

    public void IncreasesDamageByGemStrength(int minDmgStr, int maxDmgStr)
    {
        this.MinDamage += minDmgStr;
        this.MaxDamage += maxDmgStr;
    }

    public void IncreasesDamageByGemAgility(int minDmgAgi, int maxDmgAgi)
    {
        this.MinDamage += minDmgAgi;
        this.MaxDamage += maxDmgAgi;
    }

    public void DecreasesDamageStr(int minDmgStr, int maxDmgStr)
    {
        this.MinDamage -= minDmgStr;
        this.MaxDamage -= maxDmgStr;
    }

    public void DecreasesDamageAgi(int minDmgAgi, int maxDmgAgi)
    {
        this.MinDamage -= minDmgAgi;
        this.MaxDamage -= maxDmgAgi;
    }
}

