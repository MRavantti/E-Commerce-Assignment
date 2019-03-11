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
            var merchandise = this.merchandiseRepository.Get(id);

            if (merchandise == null)
            {
                return null;
            }
            return merchandise;
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

        public bool Delete(int id)
        {
            var merchandise = merchandiseRepository.Get(id);

            if (merchandise == null)
            {
                return false;
            }
            this.merchandiseRepository.Delete(id);
            return true;
        }
    }
}
