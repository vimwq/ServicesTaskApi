#pragma warning disable 1591
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyServicesTasksController : ControllerBase
    {

        private readonly ILogger<MyServicesTasksController> _logger;

        public MyServicesTasksController(ILogger<MyServicesTasksController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Добавление задачи
        /// </summary>
        /// <remarks>
        /// id - номер задачи
        /// <p>description - описание задачи</p>
        /// <p>type - тип задачи: рабочая(true) или личная(flase)</p>
        /// <p>date - дата завершения задачи (ММ.ДД.ГГГГ)</p>
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<MyServicesTasks>> PostTodoItem(int id, string description, bool type, DateTime date)
        {
            var re = new MyServicesTasks
            {
                Id = id,
                Description = description,
                Type = type,
                Date = date
            };

            using (var context = new MyServicesTasksContext())
            {
                context.ServicesTasks.Add(re);
                await context.SaveChangesAsync();

                return (re);
            }
        }
        /// <summary>
        /// Поиск задачи
        /// </summary>
        /// <remarks>
        /// id - номер задачи, которую необходимо найти
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<MyServicesTasks>> Get(int id)
        {
            using (var context = new MyServicesTasksContext())
            {
                var res = await  context.ServicesTasks.FindAsync(id);

                if (res == null)
                    return NotFound();

                return res;
            }
        }
        /// <summary>
        /// Удaление задачи
        /// </summary>
        /// <remarks>
        /// id - номер задачи, которую необходимо удалить
        /// </remarks> 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            using (var context = new MyServicesTasksContext())
            {
                var res = await context.ServicesTasks.FindAsync(id);
                if (res == null)
                    return NotFound();

                context.ServicesTasks.Remove(res);
                await context.SaveChangesAsync();

                return NoContent();
            }
        }
        /// <summary>
        /// Изменение типа задачи
        /// </summary>
        /// <remarks>
        /// <p>id - номер задачи, которую необходимо изменить</p>
        /// <p>type - тип задачи: рабочая(true) или личная(flase)</p>
        /// </remarks>
        [HttpPut("{type}")]
        public async Task<ActionResult<MyServicesTasks>> PutType(int id, bool type)
        {
            using (var context = new MyServicesTasksContext())
            {
                var myServicesTasks = await context.ServicesTasks.FindAsync(id);

                if (myServicesTasks == null)
                    return BadRequest();

                myServicesTasks.Type = type;


                context.Entry(myServicesTasks).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return (myServicesTasks);
            }
        }
        /// <summary>
        /// Изменение всей задачи
        /// </summary>
        /// <remarks>
        /// <p>id - номер задачи, которую необходимо изменить</p>
        /// <p>description - описание задачи</p>
        /// <p>type - тип задачи: рабочая(true) или личная(flase)</p>
        /// <p>date - дата завершения задачи (ММ.ДД.ГГГГ)</p>
        /// </remarks>
        [HttpPut]
        public async Task<ActionResult<MyServicesTasks>> Putall(int id, string description, bool type, DateTime date)
        {
            using (var context = new MyServicesTasksContext())
            {
                var myServicesTasks = await context.ServicesTasks.FindAsync(id);

                if (myServicesTasks == null)
                    return BadRequest();

                myServicesTasks.Description = description;
                myServicesTasks.Date = date;
                myServicesTasks.Type = type;


                context.Entry(myServicesTasks).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return (myServicesTasks);
            }
        }
    }
}
#pragma warning restore 1591