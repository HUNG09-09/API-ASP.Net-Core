using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web062023.Demo.Domain
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Hàm lấy danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        Task<List<Employee>> GetAllEmployeeAsync();

        /// <summary>
        /// Hàm lấy nhân viên theo id
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        Task<Employee> GetEmployeeAsync(Guid employeeId);

        /// <summary>
        /// Hàm tìm nhân viên theo Id
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        Task<Employee?> FindEmployeeAsync(Guid employeeId);

        /// <summary>
        /// Hàm thêm mới một nhân viên
        /// </summary>
        /// <param name="employee">Nhân viên</param>
        /// <returns>Nhân viên được thêm</returns>
        /// Created by :nshung (15/08/2023)
        Task<Employee> InsertEmployeeAsync(Employee employee);

        /// <summary>
        /// Hàm sửa thông tin nhân viên
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        Task<Employee> UpdateEmployeeAsync(Employee employee);

        /// <summary>
        /// Hàm xóa nhân viên
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        Task<int> DeleteEmployeeAsync(Employee employee);

        /// <summary>
        /// Hàm xóa nhiều nhân viên
        /// </summary>
        /// <returns></returns>
        /// Craete by: nshung (15/08/2023)
        Task<int> DeleteManyEmployeeAsync(List<Employee> employees);
    }
}
