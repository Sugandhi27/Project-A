using ClinicManagement.Models;
using ClinicManagement.Service;
using ClinicManagementSystemMVC.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Services
{
    public class SignInManager : ILogin<UserLogin>
    {
        public ClinicContext _context;
        public ILogger<SignInManager> _logger;
        public SignInManager(ClinicContext context, ILogger<SignInManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(UserLogin t)
        {
            try
            {
                _context.LoginTable.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }
        public IEnumerable<UserLogin> GetAll()
        {
            try
            {
                if ((_context.LoginTable) == null)
                    return null;
                return _context.LoginTable.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
        public int UserLogin(UserLogin t)
        {
            var obj = _context.RegisterTable.Where(i => i.UserName.Equals(t.UserName) && i.Password.Equals(t.Password)).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }
    }
}