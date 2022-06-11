using DotNet.EFCore.DatabaseFirst.Library.Constants;
using DotNet.EFCore.DatabaseFirst.MvcApp.Data;
using DotNet.EFCore.DatabaseFirst.MvcApp.Models;
using DotNet.EFCore.DatabaseFirst.MvcApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DotNet.EFCore.DatabaseFirst.MvcApp.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Logger for Home Controller
        /// </summary>
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// Entity Framework Core DB Context
        /// </summary>
        private readonly EFCoreDBFirstDatabaseContext _dbContext;

        /// <summary>
        /// Constructor to Initialize class
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="dbContext">DB context</param>
        public HomeController(ILogger<HomeController> logger, EFCoreDBFirstDatabaseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Default Index View Action Method
        /// </summary>
        /// <returns>view action result</returns>
        public IActionResult Index()
        {
            // Initializing Response View Model
            var responseViewModel = new ResponseViewModel
            {
                // Invoking Repository Methods
                Departments = new GenericRepository<Department>(_dbContext).GetEntityData() ?? new List<Department>(),
                Employees = new GenericRepository<Employee>(_dbContext).GetEntityData() ?? new List<Employee>(),
                Skills = new GenericRepository<Skill>(_dbContext).GetEntityData() ?? new List<Skill>(),
                EmployeeSkills = new GenericRepository<EmployeeSkill>(_dbContext).GetEntityData() ?? new List<EmployeeSkill>()
            };

            // Returning response view model to the view
            return View(responseViewModel);
        }

        /// <summary>
        /// Controller Action method to perform entity creation.
        /// </summary>
        /// <param name="entityJson">entity JSON</param>
        /// <param name="entityName">entity name</param>
        /// <returns>json result of entity create operation</returns>
        [HttpPost]
        public JsonResult CreateEntity(string entityJson, string entityName)
        {
            var response = new SampleResponse { };

            if (entityName.ToLower() == typeof(Employee).Name.ToLower())
                response.Data = new GenericRepository<Employee>(_dbContext).CreateEntity(JsonConvert.DeserializeObject<Employee>(entityJson));
            else if (entityName.ToLower() == typeof(Skill).Name.ToLower())
                response.Data = new GenericRepository<Skill>(_dbContext).CreateEntity(JsonConvert.DeserializeObject<Skill>(entityJson));
            else if (entityName.ToLower() == typeof(Department).Name.ToLower())
                response.Data = new GenericRepository<Department>(_dbContext).CreateEntity(JsonConvert.DeserializeObject<Department>(entityJson));
            else if (entityName.ToLower() == typeof(EmployeeSkill).Name.ToLower())
                response.Data = new GenericRepository<EmployeeSkill>(_dbContext).CreateEntity(JsonConvert.DeserializeObject<EmployeeSkill>(entityJson));
            else
                response.Data = WebConstants.InvalidEntity;

            return Json(response);
        }

        /// <summary>
        /// Controller Action method to perform entity updation/modification.
        /// </summary>
        /// <param name="entityJson">entity JSON</param>
        /// <param name="entityName">entity name</param>
        /// <returns>json result of entity update operation</returns>
        [HttpPut]
        public JsonResult UpdateEntity(string entityJson, string entityName)
        {
            var response = new SampleResponse { };

            if (entityName.ToLower() == typeof(Employee).Name.ToLower())
                response.Data = new GenericRepository<Employee>(_dbContext).UpdateEntity(JsonConvert.DeserializeObject<Employee>(entityJson));
            else if (entityName.ToLower() == typeof(Skill).Name.ToLower())
                response.Data = new GenericRepository<Skill>(_dbContext).UpdateEntity(JsonConvert.DeserializeObject<Skill>(entityJson));
            else if (entityName.ToLower() == typeof(Department).Name.ToLower())
                response.Data = new GenericRepository<Department>(_dbContext).UpdateEntity(JsonConvert.DeserializeObject<Department>(entityJson));
            else if (entityName.ToLower() == typeof(EmployeeSkill).Name.ToLower())
                response.Data = new GenericRepository<EmployeeSkill>(_dbContext).UpdateEntity(JsonConvert.DeserializeObject<EmployeeSkill>(entityJson));
            else
                response.Data = WebConstants.InvalidEntity;

            return Json(response);
        }


        /// <summary>
        /// Controller Action method to perform entity deletion.
        /// </summary>
        /// <param name="entityJson">entity JSON</param>
        /// <param name="entityName">entity name</param>
        /// <returns>json result of entity delete operation</returns>
        [HttpDelete]
        public JsonResult DeleteEntity(string entityJson, string entityName)
        {
            var response = new SampleResponse { };

            if (entityName.ToLower() == typeof(Employee).Name.ToLower())
                response.Data = new GenericRepository<Employee>(_dbContext).DeleteEntity(JsonConvert.DeserializeObject<Employee>(entityJson));
            else if (entityName.ToLower() == typeof(Skill).Name.ToLower())
                response.Data = new GenericRepository<Skill>(_dbContext).DeleteEntity(JsonConvert.DeserializeObject<Skill>(entityJson));
            else if (entityName.ToLower() == typeof(Department).Name.ToLower())
                response.Data = new GenericRepository<Department>(_dbContext).DeleteEntity(JsonConvert.DeserializeObject<Department>(entityJson));
            else if (entityName.ToLower() == typeof(EmployeeSkill).Name.ToLower())
                response.Data = new GenericRepository<EmployeeSkill>(_dbContext).DeleteEntity(JsonConvert.DeserializeObject<EmployeeSkill>(entityJson));
            else
                response.Data = WebConstants.InvalidEntity;

            return Json(response);
        }

        /// <summary>
        /// Controller Action Method for Privacy view
        /// </summary>
        /// <returns>privacy view action result</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Controller Action Method for Error View
        /// </summary>
        /// <returns>error view action result</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}