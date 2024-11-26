using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Models;
using Maintainace_system_BACKEND.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Maintainace_system_BACKEND.Services
{
    public class EmployeeIdentService : IEmployeeIdentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmployeeIdentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeIdentDto>> GetEmployeeIdentsAsync()
        {
            var employeeIdents = await _context.EmployeeIdents.Include(ei => ei.Employee).ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeIdentDto>>(employeeIdents);
        }

        public async Task<int> CreateEmployeeIdentAsync(EmployeeIdentDto employeeIdentDto)
        {
            var employeeIdentEntity = _mapper.Map<EmployeeIdent>(employeeIdentDto);
            _context.EmployeeIdents.Add(employeeIdentEntity);
            await _context.SaveChangesAsync();
            return employeeIdentEntity.Id;
        }
    }
}