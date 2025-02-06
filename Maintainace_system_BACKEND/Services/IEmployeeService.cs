using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Models;
using Maintainace_system_BACKEND.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Maintainace_system_BACKEND.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /**
         * Iegūst visu darbinieku sarakstu.
         * @return Saraksts ar darbinieku DTO objektiem.
         */
        public async Task<IEnumerable<EmployeeDto>> GetEmployeeAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        /**
         * Izveido jaunu darbinieku un saglabā to datu bāzē.
         * @param employeeDto - Jaunā darbinieka dati DTO formātā.
         * @return Izveidotā darbinieka ID.
         */
        public async Task<int> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeDto);
            _context.Employees.Add(employeeEntity);
            await _context.SaveChangesAsync();
            return employeeEntity.Id;
        }

        /**
         * Iegūst darbiniekus kopā ar to identifikācijas datiem.
         * @return Saraksts ar darbiniekiem un to identifikācijas informāciju.
         */
        public async Task<IEnumerable<EmployeeWithIdentDTO>> GetEmployeesWithIdentsAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            var employeeIdents = await _context.EmployeeIdents.ToListAsync();

            var combinedData = employees.Select(employee =>
            {
                var ident = employeeIdents.FirstOrDefault(i => i.EmployeeId == employee.Id);
                return new EmployeeWithIdentDTO
                {
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Username = ident?.Username ?? "N/A",  // Default to N/A if not found
                    Password = ident?.Password ?? "N/A"
                };
            }).ToList();

            return combinedData;
        }

        /**
         * Iegūst darbinieka datus pēc ID.
         * @param employeeId - Darbinieka unikālais identifikators.
         * @return Darbinieka DTO vai null, ja darbinieks nav atrasts.
         */
        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _context.Employees
                .Where(e => e.Id == employeeId)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Surname = e.Surname,
                    Role_Id = e.Role_Id,
                    PictureUrl = e.PictureUrl
                })
                .FirstOrDefaultAsync();

            return employee;
        }

        /**
         * Autentificē darbinieku pēc lietotājvārda un paroles.
         * @param username - Lietotājvārds.
         * @param password - Parole.
         * @return Darbinieka DTO ar lomas informāciju vai null, ja lietotājs netika atrasts.
         */
        public async Task<EmployeeDto?> GetEmployeeWithRoleAsync(string username, string password)
        {
            var employeeWithRole = await _context.EmployeeIdents
                .Include(ei => ei.Employee) // Iekļauj saistīto Employee
                .ThenInclude(e => e.Role)  // Iekļauj saistīto EmployeeRoles
                .Where(ei => ei.Username == username && ei.Password == password)
                .Select(ei => new EmployeeDto
                {
                    Id = ei.Employee.Id,
                    Name = ei.Employee.Name,
                    Surname = ei.Employee.Surname,
                    RoleName = ei.Employee.Role.RoleName, // Lomas nosaukums no EmployeeRoles
                    PictureUrl = ei.Employee.PictureUrl
                })
                .FirstOrDefaultAsync();

            return employeeWithRole;
        }
    }
}
