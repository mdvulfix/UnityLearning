using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{

    List<IProduct> cart = new List<IProduct>();
    
    private void Start() 
    {
        Customer customer = new Customer()
        {
            FirstName = "Ivan",
            LastName = "Petrov",
            PhoneNumber = "123-456-789",
            Email = "email@shop.com"


        };

        cart.Add(new PhisicalProduct("Cheese"));
        cart.Add(new PhisicalProduct("Bread"));
        cart.Add(new DigitalProduct("Game"));

        DeliverToCustomer(customer);
    }

    void DeliverToCustomer(Customer customer)
    {
        foreach (IProduct product in cart)
        {
            product.DeliverProductToCustomer(customer);
        }
    }

    

}


