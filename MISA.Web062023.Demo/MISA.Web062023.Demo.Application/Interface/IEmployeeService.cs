using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web062023.Demo.Application.Dto;

namespace MISA.Web062023.Demo.Application
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Hàm lấy danh sách nhân viên
        /// </summary>
        /// <param name="employee">Nhân viên</param>
        /// <returns>Danh sách nhân viên </returns>
        /// Created by :nshung (15/08/2023)
        Task<List<EmployeeDto>> GetAllEmployeeAsync();

        /// <summary>
        /// Hàm lấy nhân viên theo Id
        /// </summary>
        /// <param name="employee">Nhân viên</param>
        /// <returns>Nhân viên </returns>
        /// Created by :nshung (15/08/2023)
        Task<EmployeeDto> GetEmployeeAsync(Guid employeeId);

        /// <summary>
        /// Hàm thêm mới một nhân viên
        /// </summary>
        /// <param name="employee">Nhân viên</param>
        /// <returns>Nhân viên được thêm</returns>
        /// Created by :nshung (15/08/2023)
        Task<EmployeeDto> InsertEmployeeAsync(EmployeeInsertDto employeeCreateDto);

        /// <summary>
        /// Hàm sửa thông tin nhân viên
        /// </summary>
        /// <param name="employee">Nhân viên</param>
        /// <returns>Nhân viên đã được sửa</returns>
        /// Created by :nshung (15/08/2023)
        Task<EmployeeDto> UpdateEmployeeAsync(Guid employeeId, EmployeeUpdateDto employee);

        /// <summary>
        /// Hàm xóa nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên bị xóa</param>
        /// <returns></returns>
        /// Created by :nshung (15/08/2023)
        Task<int> DeleteEmployeeAsync(Guid employeeId);

        /// <summary>
        /// Hmà xóa nhiều nhân viên
        /// </summary>
        /// <param name="employeeIds">Danh sách Id bị xóa</param>
        /// <returns></returns>
        Task<int> DeleteManyEmployeeAsync(List<Guid> employeeIds);
       
    }
}
