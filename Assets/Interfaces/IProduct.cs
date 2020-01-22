using System.Collections;
using UnityEngine;

public interface IProduct
{
    string Title {get; set;} 
    bool HasOrderBeenCompleted {get;}

    void DeliverProductToCustomer(Customer customer);
}
