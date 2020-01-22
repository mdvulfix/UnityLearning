using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalProduct : IProduct
{
    public string Title {get; set;} 
    public bool HasOrderBeenCompleted {get; private set;}
    public int Downloads {get; private set;} = 5;

    public DigitalProduct(string title)
    {
        Title = title;

    }

    public void DeliverProductToCustomer(Customer customer)
    {
        
        if(!HasOrderBeenCompleted)
        {
            Debug.Log("Отправляем лицензию на товар " + Title + " на электронный адрес " +  customer.Email);
            Downloads -= 1;
            HasOrderBeenCompleted = Downloads < 1? true : false;
        }
    }


}
