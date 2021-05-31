using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Models
{
    public class ClinicContext : DbContext
    {
        public ClinicContext()
        {}

        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        { }
        public DbSet<Appointment> AppointmentTable { get; set; }
        public DbSet<DoctorDetail> DoctorTable { get; set; }
        public DbSet<UserLogin> LoginTable { get; set; }
        public DbSet<PatientDetail> PatientTable { get; set; }
        public DbSet<Register> RegisterTable { get; set; }
    }
}
