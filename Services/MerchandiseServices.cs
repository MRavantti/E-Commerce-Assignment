using System;
using System.Collections.Generic;

namespace E_Commerce
{
    public class MerchendiseService
    {
        private readonly MerchandiseRepository merchandiseRepository;

        public MerchendiseService(MerchandiseRepository merchandiseRepository)
        {
            this.merchandiseRepository = merchandiseRepository;
        }

        public List<Merchandise> Get()
        {
            return this.merchandiseRepository.Get();
        }

        public Merchandise Get(int id)
        {
            if (id < 1)
            {
                return null;
            }
            return this.merchandiseRepository.Get(id);
        }

        public bool Add(Merchandise merchandise)
        {
            if (string.IsNullOrEmpty(merchandise.Name) || string.IsNullOrEmpty(merchandise.Description) || merchandise.Price < 1)
            {
                return false;
            }
            this.merchandiseRepository.Add(merchandise);
            return true;
        }
    }
}
