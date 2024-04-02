using Dapper;
using MISA.Web062023.Demo.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web062023.Demo.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository

    {
        private readonly string _connectionString = "Server=127.0.0.1;Port=3306;Database=misa.amis.nshung;Uid=nshung;Pwd=Syhung262626.";
        private object updatedEmployee;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        } 

        /// <summary>
        /// Hàm lấy danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var connection = new MySqlConnection(_connectionString);

            var sql = "SELECT * FROM employee;";

            var result = await connection.QueryAsync<Employee>(sql);

            return result.ToList();
        }

        /// <summary>
        /// Hàm lấy nhân viên theo Id
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeAsync(Guid employeeId)
        {
            var employee = await FindEmployeeAsync(employeeId);
            if(employee == null)
            {
                throw new NotFoundException();
            }
            return employee;
        }

        /// <summary>
        /// Hàm tìm nhân viên theo Id
        /// </summary>
        /// <returns></returns>
        public async Task<Employee?> FindEmployeeAsync(Guid employeeId)
        {
            var connection = new MySqlConnection(_connectionString);

            var sql = $"SELECT * FROM employee WHERE EmployeeId = @id;";

            var param = new DynamicParameters();
            param.Add("id", employeeId);

            var result = await connection.QuerySingleOrDefaultAsync(sql, param);
            return result;
        }

        /// <summary>
        /// Hàm sửa thông tin nhân viên
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> InsertEmployeeAsync(Employee employee)
        {
            var connectionString = "Server=127.0.0.1;Port=3306;Database=misa.amis.nshung;Uid=nshung;Pwd=Syhung262626.";
            var connection = new MySqlConnection(connectionString);

            var sql = @"
            INSERT INTO employee (EmployeeId, EmployeeCode, FullName, DateOfBirth, Gender, DepartmentId, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy)
            VALUES (@EmployeeId, @EmployeeCode, @FullName, @DateOfBirth, @Gender, @DepartmentId, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy);
        ";

            var result = await connection.ExecuteAsync(sql, employee);

            return result;
        }


        /// <summary>
        /// Hàm sửa thông tin nhân viên
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var connectionString = "Server=127.0.0.1;Port=3306;Database=misa.amis.nshung;Uid=nshung;Pwd=Syhung262626.";

            var connection = new MySqlConnection(connectionString);

            // Kiểm tra xem nhân viên có tồn tại không
            var checkSql = $"SELECT COUNT(*) FROM employee WHERE EmployeeId = @id;";
           

            // Cập nhật thông tin nhân viên
            var updateSql = @"
            UPDATE employee 
            SET EmployeeCode = @EmployeeCode, FullName = @FullName, DateOfBirth = @DateOfBirth, 
                Gender = @Gender, DepartmentId = @DepartmentId, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy 
            WHERE EmployeeId = @EmployeeId;
        ";
            var result = await connection.ExecuteAsync(updateSql, updatedEmployee);
        }

        /// <summary>
        /// Hàm xóa nhân viên
        /// </summary>
        /// <returns></returns>
        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            var connection = new MySqlConnection(_connectionString);

            var sql = $"DELETE FROM employee WHERE EmployeeID = @id;";

            var param = new DynamicParameters();
            param.Add("id", employee.EmployeeId);

            var result = await connection.ExecuteAsync(sql, param);
            return result;
        }

        /// <summary>
        /// Hàm xóa nhiều nhân viên
        /// </summary>
        /// <returns></returns>
        public async Task<int> DeleteManyEmployeeAsync(List<Employee> employees)
        {
            var connection = new MySqlConnection(_connectionString);

            var sql = $"DELETE FROM employee WHERE EmployeeID IN @ids;";

            var param = new DynamicParameters();
            param.Add("ids", employees.Select(employee => employee.EmployeeId));

            var result = await connection.ExecuteAsync(sql, param);
            return result;
        }

       
    }
}
