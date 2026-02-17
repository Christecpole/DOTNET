using TpBilleterie.Classes;
using TpBilleterie.Exceptions;

namespace TpBilleterie.Service;

public class CustomerService
{
    private List<Customer> customers;

    public CustomerService()
    {
        this.customers = new List<Customer>();
    }

    public void AddCustomer(Customer newCustomer)
    {
        customers.Add(newCustomer);
    }

    public void AddCustomer(string firstName, string lastName, Address address, int age, string phone)
    {
        customers.Add(new Customer(firstName, lastName, address, age, phone));
    }

    public List<Customer> GetAllCustomers()
    {
        return customers;
    }

    public bool DeleteCustomer(int index)
    {
        try
        {
            customers.RemoveAt(index);
            return true;
        }
        catch (IndexOutOfRangeException e)
        {
            throw new NotFoundException("Customer not found");
        }
    }

    public Customer GetCustomer(int index)
    {
        try
        {
            return customers[index];
        }
        catch (Exception e)
        {
            throw new NotFoundException("Customer not found");
        }
    }

    public Customer Update(int index, string firstName, string lastName, Address address, int age, string phone)
    {
        try
        {
            Customer CustomerFound = customers[index];
            CustomerFound.Firstname = firstName;
            CustomerFound.Lastname = lastName;
            CustomerFound.Address = address;
            CustomerFound.Phone = phone;
            CustomerFound.Age = age;
            return CustomerFound;
        }catch(IndexOutOfRangeException e)
        {
            throw new NotFoundException("Customer not found");
        }
    }
}