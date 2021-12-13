using Business.Abstract;
using Dto.Account;
using Microsoft.AspNetCore.Mvc;
using RadoreDemo.Mappers;
using RadoreDemo.Models.Account;

namespace RadoreDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountApiService _accountApiService;
        public AccountController(IAccountApiService accountApiService)
        {
            _accountApiService = accountApiService;
        }
        public async Task<IActionResult> Index()
        {
            var domainNames = await _accountApiService.GetAllAccountDetailsAsync();

            var accountList = AccountMapper.List(domainNames);

            return View(accountList);
        }

        public async Task<IActionResult> Detail(string hostingDomainName)
        {
            var account = await _accountApiService.GetAccountDetailAsync(hostingDomainName);

            if (account==null)
                return RedirectToAction("Index");
          
            var viewModel = new AccountDetailViewModel
            {
                HostingDomainName = account.HostingDomainName,
                HostingPackage = account.HostingPackage,
                CpuLoad = account.CpuLoad,
                IncomingConnections = account.IncomingConnections,
                Message = account.Message,
                RamMax = account.RamMax,
                RamUsage = account.RamUsage,
            };

            return View(viewModel);
        }

    
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AccountNewViewModel viewModel)
        {     

            var account = new AccountAdd
            {
                HostingDomainName = viewModel.HostingDomainName,
                HostingPackage = viewModel.HostingPackage
            };

            var result = await _accountApiService.AddAsync(account);

            HttpContext.Response.StatusCode = result.Code;        

            return result.Code == 200 ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string hostingDomainName)
        {
            var account = await _accountApiService.GetAccountDetailAsync(hostingDomainName);

            if (!string.IsNullOrEmpty(hostingDomainName) && account != null)
            {
                var result =await _accountApiService.DeleteAsync(account);                
                return result.Code == 200 ? Ok(result.Message) : BadRequest(result.Message);
            }

            return BadRequest(account?.Message);
            
        }
    }
}
