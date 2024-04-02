using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web062023.Demo.Application;
using MISA.Web062023.Demo.Domain;
using MySqlConnector;


namespace MISA.Web062023.Demo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase

    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// Created by: nshung (12/08/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {        
            var result = await _employeeService.GetAllEmployeeAsync();
            return StatusCode(StatusCodes.Status200OK,result);
        }


        /// <summary>
        /// Lấy ra 1 nhân viên theo id
        /// </summary>
        /// <returns>1 nhân viên</returns>
        /// Created by: nshung (12/08/2023)
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployeeAsync(Guid id)
        {        
            var result = await _employeeService.GetEmployeeAsync(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Xóa một nhân viên
        /// </summary>
        /// 204 - Xóa thành công
        /// 500 - Có exception
        /// </returns>
        /// Created by: nshung (12/08/2023)
        /// 

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(Guid id)
        {              
            var result = await _employeeService.DeleteEmployeeAsync(id);
            return StatusCode(StatusCodes.Status200OK, result);                        
        }

        /// <summary>
        /// Xóa nhiều nhân viên
        /// </summary>
        /// </returns>
        /// Created by: nshung (12/08/2023)
        /// 
        [HttpDelete]
        public async Task<IActionResult> DeleteManyEmployeeAsync(List<Guid> ids )
        {
            var result = await _employeeService.DeleteManyEmployeeAsync(ids);
            return StatusCode(StatusCodes.Status200OK, result);
        }


        /// <summary>
        /// Thêm mới một nhân viên
        /// </summary>
        /// 201 - Thêm mới thành công
        /// 400 - Dữ liệu đầu vào không hợp lệ
        /// 500 - Có exception
        /// </returns>
        /// Created by: nshung (12/08/2023)
        /// 

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(Employee employee)
        {
            var result = await _employeeService.InsertEmploeeAsync(employee);
            return StatusCode(StatusCodes.Status201Created, result);
        }


        /// <summary>
        /// Sửa thông tin  nhân viên
        /// </summary>
        /// 200 - Sửa thành công
        /// 400 - Dữ liệu đầu vào không hợp lệ
        /// 500 - Có exception
        /// </returns>
        /// Created by: nshung (12/08/2023)
        /// 
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(Guid id, Employee updatedEmployee)
        {

            var result = await _employeeService.UpdateEmployeeAsync(id, updatedEmployee);

            return StatusCode(StatusCodes.Status204NoContent, result);
        }

    }
}
