using MISA.Web062023.Demo.Application.Dto;
using MISA.Web062023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web062023.Demo.Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        /// <summary>
        /// Hàm lấy danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        public async Task<List<EmployeeDto>> GetAllEmployeeAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeeAsync();
            var employeeDto = employees.Select(employee => EmployeeToEmployeeDto(employee)).ToList();
            return employeeDto;
        }

        /// <summary>
        /// Hàm lấy nhân viên theo Id
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        public async Task<EmployeeDto> GetEmployeeAsync(Guid employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(employeeId);
            var employeeDto = EmployeeToEmployeeDto(employee);
            return employeeDto;
        }

        /// <summary>
        /// Hàm thêm mới một nhân viên
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        public async Task<EmployeeInsertDto> InsertEmploeeAsync(EmployeeInsertDto employeedDto)
        {
            var employee = EmployeeDtoToEmployee(employeedDto);
            await _employeeRepository.InsertEmploeeAsync(employee);
            return employeedDto;
        }


        /// <summary>
        /// Hàm sửa thông tin nhân viên
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        public async Task<EmployeeUpdateDto> UpdateEmployeeAsync(Guid employeeId, EmployeeUpdateDto employeeDto)
        {
            var employee = EmployeeDtoToEmployee(employeeId, employeeDto);
            await _employeeRepository.UpdateEmployeeAsync(employee);
            return employeeDto;
        }

        /// <summary>
        /// Hàm xóa nhân viên
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        public async Task<int> DeleteEmployeeAsync(Guid employeeId)
        {
            var result = await _employeeRepository.DeleteEmployeeAsync(employeeId);
            return result;
        }


        /// <summary>
        /// Hàm xóa nhiều nhân viên
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        public async Task<int> DeleteManyEmployeeAsync(List<Guid> employeeIds)
        {
            var result = await _employeeRepository.DeleteManyEmployeeAsync(employeeIds);

            return result;
        }

        /// <summary>
        /// Hàm sửa thông tin nhân viên
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        private Employee EmployeeDtoToEmployee(Guid employeeId, EmployeeUpdateDto employeeDto)
        {
            var employee = new Employee()
            {
                EmployeeId = employeeId,
                EmployeeCode = employeeDto.EmployeeCode,
                FullName = employeeDto.FullName,
                Gender = employeeDto.Gender,              
                DateOfBirth = employeeDto.DateOfBirth,
            };
            return employee;
        }

        /// <summary>
        /// Hàm thêm mới
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        private Employee EmployeeDtoToEmployee(EmployeeInsertDto employeeDto)
        {
            var employee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                EmployeeCode = employeeDto.EmployeeCode,
                FullName = employeeDto.FullName,
                Gender = employeeDto.Gender,
                DateOfBirth = employeeDto.DateOfBirth,
            };
            return employee;
        }



        private EmployeeDto EmployeeToEmployeeDto(Employee employee)
        {
            var employeeDto = new EmployeeDto()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeCode = employee.EmployeeCode,
                FullName = employee.FullName,
                Gender = employee.Gender,
                DateOfBirth = employee.DateOfBirth,
       
            };
            return employeeDto;
        }
       
    }
}
