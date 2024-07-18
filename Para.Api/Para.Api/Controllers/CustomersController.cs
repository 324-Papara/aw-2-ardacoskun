using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Para.Data.Domain;
using Para.Data.UnitOfWork;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            var entityList = await unitOfWork.CustomerRepository.GetAll();
            return entityList;
        }

        [HttpGet("{customerId}")]
        public async Task<Customer> Get(long customerId)
        {
            var entity = await unitOfWork.CustomerRepository.GetById(customerId);
            return entity;
        }

        [HttpGet("{customerNumber}")]
        public async Task<List<Customer>> GetCustomerByCustomerNumber(int CustomerNumber)
        {
            return await unitOfWork.CustomerRepository.Where(x => x.CustomerNumber == CustomerNumber);
        }
        [HttpGet("{address}")]
        public async Task<List<Customer>> GetCustomerWithCustomerAddress()
        {
            return await unitOfWork.CustomerRepository.Include(x => x.CustomerAddresses).ToListAsync();
        }

        [HttpPost]
        public async Task Post([FromBody] Customer value)
        {
            await unitOfWork.CustomerRepository.Insert(value);
            await unitOfWork.Complete();
        }

        [HttpPut("{customerId}")]
        public async Task Put(long customerId, [FromBody] Customer value)
        {
            await unitOfWork.CustomerRepository.Update(value);
            await unitOfWork.Complete();
        }

        [HttpDelete("{customerId}")]
        public async Task Delete(long customerId)
        {
            var entity = await unitOfWork.CustomerRepository.GetById(customerId);
            await unitOfWork.CustomerRepository.Delete(entity);
            await unitOfWork.Complete();
        }

    }
}