using ClinicManagement.Models;
using ClinicManagement.Service;
using ClinicManagement.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystemMVC.Service
{
    public class ClinicManager : ILogin<UserLogin>, IFunction<DoctorDetail>, IFunction<PatientDetail>, IFunction<Appointment>
    {
        private ClinicContext _context;
        private ILogger<ClinicManager> _logger;

        public ClinicManager()
        {

        }
        public ClinicManager(ClinicContext context, ILogger<ClinicManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(DoctorDetail t)
        {
            _context.DoctorTable.Add(t);
            _context.SaveChanges();
        }

        public void Add(PatientDetail t)
        {
            _context.PatientTable.Add(t);
            _context.SaveChanges();
        }

        public void Add(Appointment t)
        {
            throw new NotImplementedException();
        }

        public void Add(UserLogin t)
        {
            throw new NotImplementedException();
        }

        public DoctorDetail Get(int id)
        {
            try
            {
                DoctorDetail doctor = _context.DoctorTable.FirstOrDefault(a => a.DoctorID == id);
                return doctor;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<UserLogin> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool SignIn(UserLogin t)
        {
            try
            {
                UserLogin login = _context.LoginTable.SingleOrDefault(u => u.UserName == t.UserName);
                if (login.Password == t.Password)
                    return true;
            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }

        public int UserLogin(UserLogin t)
        {
            throw new NotImplementedException();
        }

        PatientDetail IFunction<PatientDetail>.Get(int id)
        {
            try
            {
                PatientDetail patient = _context.PatientTable.FirstOrDefault(a => a.PatientID == id);
                return patient;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        Appointment IFunction<Appointment>.Get(int id)
        {
            try
            {
                Appointment appointment = _context.AppointmentTable.FirstOrDefault(a => a.AppointmentId == id);
                return appointment;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
    }
}