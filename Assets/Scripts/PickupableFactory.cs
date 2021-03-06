using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableFactory : Singleton<PickupableFactory>
{
    public Pickupable pickupablePrefab;
    private List<Pickupable> pool;

    private void Start()
    {
        Pickupable temp;
        pool = new List<Pickupable>();

        for (int j = 0; j < 20; j++)
        {
            temp = (Pickupable)Instantiate(pickupablePrefab);
            temp.gameObject.SetActive(false);
            temp.transform.parent = transform;
            pool.Add(temp);
        }
    }

    public Pickupable Activate(Item item)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeSelf)
            {
                Pickupable currObj = pool[i];
                currObj.gameObject.SetActive(true);
                currObj.SetItem(item);
                return currObj;
            }
        }
        Pickupable newObj = Instantiate(pickupablePrefab) as Pickupable;
        newObj.SetItem(item);
        pool.Add(newObj);
        return newObj;
    }

    public void Deactivate(Pickupable p)
    {
        p.Reset();
        p.gameObject.SetActive(false);
    }
}
