using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RequestTemplate.Models;

namespace RequestTemplate.Controllers
{
    public class WorkFlowsController : Controller
    {
        
        public WorkFlowsController()
        {
            
        }

        // GET: WorkFlows
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var flows = JsonConvert.DeserializeObject<PaginatedItemsViewModel<WorkFlow>>(await client.GetStringAsync(new Uri("Http://10.3.249.101:88/api/v1/WorkFlows")));
            return View(flows.Data);
        }

        // GET: WorkFlows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new HttpClient();
            var workFlow = JsonConvert.DeserializeObject<WorkFlow>(await client.GetStringAsync(new Uri("http://10.3.249.101:88/api/v1/workflows/" + id.ToString())));
            
            if (workFlow == null)
            {
                return NotFound();
            }

            return View(workFlow);
        }

        // GET: WorkFlows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkFlows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RequestId,Start,End,CurrentStage,Stage1,Name1,Task1,Assignee1,Owner1,File1,Stage2,Name2,Task2,Assignee2,Owner2,File2,Stage3,Name3,Task3,Assignee3,Owner3,File3,Stage4,Name4,Task4,Assignee4,Owner4,File4,Stage5,Name5,Task5,Assignee5,Owner5,File5")] WorkFlow workFlow)
        {
            if (ModelState.IsValid)
            {
                var client = new HttpClient();
                var result = await client.PostAsync(new Uri("http://10.3.249.101:88/api/v1/workflows"), new StringContent(JsonConvert.SerializeObject(workFlow), Encoding.UTF8, "application/json"));
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(workFlow);
        }

        // GET: WorkFlows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpClient client = new HttpClient();
            var workFlow = client.GetStringAsync(new Uri("http://10.3.249.101:88/api/v1/workflows/" + id.ToString()));
            if (workFlow == null)
            {
                return NotFound();
            }
            return View(workFlow);
        }

        // POST: WorkFlows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RequestId,Start,End,CurrentStage,Stage1,Name1,Task1,Assignee1,Owner1,File1,Stage2,Name2,Task2,Assignee2,Owner2,File2,Stage3,Name3,Task3,Assignee3,Owner3,File3,Stage4,Name4,Task4,Assignee4,Owner4,File4,Stage5,Name5,Task5,Assignee5,Owner5,File5")] WorkFlow workFlow)
        {
            if (id != workFlow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var client = new HttpClient();
                var result = client.PutAsync(new Uri("http://10.3.249.101:88/api/v1/workflows/" + id.ToString()), new StringContent(JsonConvert.SerializeObject(workFlow), Encoding.UTF8, "application/json"));
                if (result.IsCompletedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(workFlow);
        }

        // GET: WorkFlows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = new HttpClient();
            var workFlow = client.GetStringAsync(new Uri("http://10.3.249.101:88/api/v1/workflows/" + id.ToString()));
            if (workFlow == null)
            {
                return NotFound();
            }
            return View(workFlow);
        }

        // POST: WorkFlows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = new HttpClient();
            var result = await client.DeleteAsync(new Uri("http://10.3.249.101:88/api/v1/workflows/" + id.ToString()));
            return RedirectToAction(nameof(Index));
        }

    }
}
