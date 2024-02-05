using Godot;
using System;

public partial class Inventory : Node2D
{
    public uint foodAmount = 5;
    public uint drinkAmount = 5;
    public uint healingItemAmount = 1;
    public float foodEatFactor = 5.5f;
    public float drinkUpFactor = 6f;
    public float healingFactor = 10f;

    public int money = 50;

    public Action OnInventoryUpdate;

    public void AddFood()
    {
        foodAmount++;
        OnInventoryUpdate?.Invoke();
    }
    public void AddFood(uint amount)
    {
        foodAmount += amount;
        OnInventoryUpdate?.Invoke();

    }
    public void AddDrinks()
    {
        drinkAmount++;
        OnInventoryUpdate?.Invoke();

    }
    public void AddDrinks(uint amount)
    {
        drinkAmount += amount;
        OnInventoryUpdate?.Invoke();

    }
    public void AddHeals()
    {
        healingItemAmount++;
        OnInventoryUpdate?.Invoke();

    }
    public void AddHeals(uint amount)
    {
        healingItemAmount += amount;
        OnInventoryUpdate?.Invoke();
    }

    public void RemoveFood()
    {
        foodAmount--;
        OnInventoryUpdate?.Invoke();
    }
    public void RemoveDrink()
    {
        drinkAmount--;
        OnInventoryUpdate?.Invoke();
    }
    public void RemoveHeal()
    {
        healingItemAmount--;
        OnInventoryUpdate?.Invoke();
    }
    public void AddMoney(int amount)
    {
        money += amount;
        OnInventoryUpdate?.Invoke();
    }
    public void SetMoney(int amount)
    {
        money = amount;
        OnInventoryUpdate?.Invoke();
    }
    public void RemoveMoney(int amount)
    {
        money -= amount;
        OnInventoryUpdate?.Invoke();
    }
    //percent = 0.0 to 1
    public void UpgradeFoodFactor(float percent)
    {
        foodEatFactor *= 1 + percent;
        OnInventoryUpdate?.Invoke();

    }
    public void UpgradeDrinkFactor(float percent)
    {
        drinkUpFactor *= 1 + percent;
        OnInventoryUpdate?.Invoke();

    }
    public void UpgradeHealingFactor(float percent)
    {
        healingFactor *= 1 + percent;
        OnInventoryUpdate?.Invoke();

    }


}
