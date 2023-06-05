using Importer.Entities;
using Importer.Repositories;
using Importer.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Parser
{
    public enum NameTable
    {
        Department,
        Emppployee,
        JobTile
    }

    public class Parser
    {
        private readonly string filePath;
        private readonly NameTable nameTable;
        private IDepartmentRepository departmentRepository;
        private IEmployeeRepository employeeRepository;
        private IJobTitleRepository jobTitleRepository;

        public Parser(string _filePath, NameTable _nameTable, IDepartmentRepository _departmentRepository,
            IEmployeeRepository _employeeRepository, IJobTitleRepository _jobTitleRepository) 
        {
            filePath = _filePath;
            nameTable = _nameTable;
            departmentRepository = _departmentRepository;
            employeeRepository = _employeeRepository;  
            jobTitleRepository = _jobTitleRepository;
        }

        public void  ParseDepartment()
        {
            using (StreamReader reader = new(filePath))
            {
                string? line;
                string[] data;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        data = line.Trim().Split("\t");
                    }
                    catch 
                    {
                        continue;
                    }
                    departmentRepository.Add(CreateDepartment(data));
                }
            }
        }
        private Department CreateDepartment(string[] data)
        {
            var department = new Department();
            if (data.Length == 3)
            {
                department.Name = data[0];
                department.ParentID = 0;
                employeeRepository.Update(new Employee() { FullName = data[1] });
                department.ManagerID = employeeRepository.FindOnName(data[1]);
                department.Phone = data[2];
                departmentRepository.Update(department);
            }
            if (data.Length == 4)
            {
                department.Name = data[0];
                department.ParentID = departmentRepository.FindOnName(data[1]);
                employeeRepository.Update(new Employee() { FullName = data[2] });
                department.ManagerID = employeeRepository.FindOnName(data[2]);
                department.Phone = data[3];
                departmentRepository.Update(department);
            }
            return department;
        }
    }
}
