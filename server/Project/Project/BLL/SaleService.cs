using Project.DAL;
using Project.Models;

namespace Project.BLL
{
    public class SaleService:ISaleService
    {
        private readonly ISaleDal SaleDal;
        private readonly ICustomerDal CustomerDal;
        public SaleService(ISaleDal ISaleDal,ICustomerDal customerDal)
        {
            this.SaleDal = ISaleDal;
            this.CustomerDal= customerDal;
        }

        public async Task< Sale> AddSale(Sale sale)
        {
            return await SaleDal.AddSale(sale);
        }

        public async Task< List<Sale>>GetAllSalesByStatusT()
        {
            return await SaleDal.GetAllSalesByStatusT();
        }


        public async Task< Sale> DeleteSale(int idSale)
        {
            return await SaleDal.DeleteSale(idSale);
        }

        public async Task< List<Sale>> GetSaleByCustomer(int customerId)
        {
            return await SaleDal.GetSaleByCustomer(customerId);
        }
        public async Task<List<Sale>> GetSaleByGift(int giftId)
        {
            return await SaleDal.GetSaleByGift(giftId);
        }
        public async Task< Sale> GetSaleById(int saleId)
        {
            return await SaleDal.GetSaleById(saleId);

        }

        public async Task<Sale> ChangeToStatusT(int saleId)
        {
            return await SaleDal.ChangeToStatusT(saleId);

        }

        public async Task<Customer> Random(int giftId)
        {
            List<Sale>s= await SaleDal.GetSaleByGift(giftId);
            s.ForEach(sale => {
                if (sale.Count > 1)
                {
                    Sale ss = sale;
                    ss.Count = 1;
                    for (int i = 0; i < sale.Count - 1; i++)
                    {
                        s.Add(ss);
                    }
                }
            });
            Random random = new Random();
            int randomIndex = random.Next(s.Count);
            Customer c = await CustomerDal.GetCustomerById(s[randomIndex].CustomerId);
            return c;

        }
    }
}
