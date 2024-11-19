using Azure;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.DTO;
using Microsoft.EntityFrameworkCore;


namespace Project.DAL
{
    public class CustomerDal:ICustomerDal
    {
        private readonly Context context;
        public CustomerDal(Context context)
        {
            this.context = context;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            try
            {
                await context.Customers.AddAsync(customer);
                await context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                return await context.Customers.Select(x => x).ToListAsync();
            }
            catch (Exception ex)
            {
                throw /*Exception ex*/;

            }
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            try
            {
                return await context.Customers.FirstAsync(x => x.Id==customerId);
            }
            catch (Exception ex)
            {
                throw /*Exception ex*/;

            }
        }

        public async Task<Customer> DeleteCustomer(int IdCustomer)
        {
            try
            {
                Customer customer = await context.Customers.FirstAsync(x => x.Id == IdCustomer);
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
                return customer;

            }
            catch (Exception ex)
            {
                throw /*Exception ex*/;

            }

        }
        public async Task<Customer> ChangeDetails(Customer customer)
        {
            try
            {
                context.Customers.Update(customer);
                await context.SaveChangesAsync();
                return customer;

            }
            catch (Exception ex)
            {
                throw /*Exception ex*/;

            }
        }
        public async Task<Customer> Login(string name, string password)
        {
            try
            {
                return await context.Customers.FirstAsync(x=>x.Name==name&&x.Password==password);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public Customer GetCustomerById(int id)
        //{

        //}


    }
}
