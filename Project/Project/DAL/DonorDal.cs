using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public class DonorDal:IDonorDal
    {
        private readonly Context context;

        public DonorDal(Context context)
        {
            this.context = context;
        }

        public async Task<List<Customer>> GetAllDonors()
        {
            try
            {
                return await context.Customers.Select(x => x).Where(x=>x.Role==role.Donor).ToListAsync();
            }
            catch (Exception ex)
            {
                throw /*Exception ex*/;

            }
        }

        public async Task<Customer> DeleteDonor(int IdDonor)
        {
            try
            {
                Customer notDonor = await context.Customers.FirstAsync(x => x.Id == IdDonor);
                //context.Donors.Remove(donor);
                notDonor.Role = role.Custumer;
                context.Customers.Update(notDonor);
                await context.SaveChangesAsync();
                return notDonor;

            }
            catch (Exception ex)
            {
                throw /*Exception ex*/;

            }
        }
        public async Task<Customer> ChangeToDonor(int IdDonor)
        {
            try
           {
                Customer c= await context.Customers.FirstAsync(x => x.Id == IdDonor);
                if(c.Role==role.Custumer)
                    c.Role = role.Donor;
                context.Customers.Update(c);
                await context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                throw /*Exception ex*/;

            }
        }
        public async Task<Customer> ChangeDetails(DonorDto donorDto)
        {
            try
            {
                Customer d = await context.Customers.FirstAsync(x => x.Id == donorDto.Id);
                d.Name= donorDto.Name;
                d.Address= donorDto.Address;
                d.Phone= donorDto.Phone;
                d.Email= donorDto.Email;
                context.Customers.Update(d);
                await context.SaveChangesAsync();
                return d;
            }
            catch (Exception ex)
            {
                throw /*Exception ex*/;

            }
        }
        public async Task<Customer> GetDonorByGift(int GiftId)
        {

            try
            {
                var g= await context.Gifts.FirstOrDefaultAsync(x=>x.Id == GiftId);
                return g.Customer;
            }
            catch (Exception ex)
            {
                throw /*Exception ex*/;

            }
        }
    }
}
