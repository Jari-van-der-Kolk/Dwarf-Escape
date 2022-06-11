using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
   public static ResourceManager instance;
   
   public List<ResourceHolder> resourceHolders = new List<ResourceHolder>();

   public static EventHandler updateValues;

   [SerializeField] private GameObject SlotHolder;
   [SerializeField] private GameObject text;

   private void Awake()
   {
      Init();                                   
   }

   public void Init()
   {
      if (instance == null)
      {
         instance = this;
      }
      else if (instance != null)
      {
         Destroy(this);
      }

      for (int i = 0; i < transform.childCount; i++)
      {
         var equipmentSlotMember = transform.GetChild(i).GetComponent<ResourceHolder>();
         resourceHolders.Add(equipmentSlotMember);
      }
   }

   public void Add(InventoryItem referenceData)
   {
      bool hasFoundSlot = false;
      for (int i = 0; i < resourceHolders.Count; i++)
      {
         if (resourceHolders[i].id == referenceData.data.id)
         {
            hasFoundSlot = true;
           //voeg hem toe aan de resourceHolder

            CreateSlot(referenceData).transform.parent = resourceHolders[i].transform;
            var sort = SortSlots(resourceHolders[i]);
            for (int s = 0; s < sort.Length; s++)
            {
                resourceHolders[i].transform.GetChild(s).SetSiblingIndex(sort[s].transform.GetSiblingIndex());   
            }
            break;
         }
      }

      if (!hasFoundSlot)
      {
            // maak een nieuwe equipmentHolder aan, en voeg de referenceData toe
            var slotHolder = CreateSlotHolder(referenceData);
            resourceHolders.Add(slotHolder.GetComponent<ResourceHolder>());
            CreateSlot(referenceData).transform.parent = slotHolder.transform;
      }     
      
      
   }

   public Resource[] SortSlots(ResourceHolder resourceHolder)
   {
      Resource[] resources = new Resource[resourceHolder.transform.childCount];
      
      for (int i = 0; i < resourceHolder.transform.childCount; i++)
      {
            resources[i] = resourceHolder.transform.GetChild(i).GetComponent<Resource>();
      }
      
      Resource temp;

      for (int write = 0; write < resources.Length; write++)
      {
         for (int sort = 0; sort < resources.Length - 1; sort++)
         {
            if (resources[sort].referenceData.data.tier > resources[sort + 1].referenceData.data.tier)
            {
               temp = resources[sort + 1];
               resources[sort + 1] = resources[sort];
               resources[sort] = temp;
            }
         }
      }

      return resources;
   }

   public void SortHolders()
   {
      
   }

    public GameObject CreateSlotHolder(InventoryItem referenceData)
    {
        var Holder = Instantiate(SlotHolder, transform);
        Holder.GetComponent<ResourceHolder>().id = referenceData.data.id;
        return Holder;
    }
   
   public GameObject CreateSlot(InventoryItem referenceData)
   {
      var resource = new GameObject("ResourceSlot", typeof(Image), typeof(Resource));
      var text = Instantiate(this.text, resource.transform);
      resource.GetComponent<Resource>().Init(referenceData, resource.GetComponent<Image>() , text.GetComponent<TextMeshProUGUI>());

      return resource;
   }
   
   
   
   
}
