using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicalProduct : IProduct
{
    public string Title {get; set;} 
    public bool HasOrderBeenCompleted {get; private set;} 

    public PhisicalProduct(string title)
    {
        Title = title;

    }

    public void DeliverProductToCustomer(Customer customer)
    {
        if(!HasOrderBeenCompleted)
        {
            Debug.Log("Осуществляем доставку " + Title + " для покупателя " +  customer.FirstName +" " + customer.LastName);
            HasOrderBeenCompleted = true;

        }



    }


}
