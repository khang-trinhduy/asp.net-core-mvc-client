using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RequestTemplate.Models;
using RequestTemplate.Models.CompleteTaskModel;
using RequestTemplate.Models.SubmitActionViewModel;

namespace RequestTemplate.Controllers
{
    public class RequestsController : Controller
    {
        private readonly RequestContext _context;
        public IConfiguration Configuration { get; }

        public RequestsController(RequestContext context, IConfiguration configuration)
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://" + Configuration["url"] + ":88/api/v1/requests");
            _context = context;
            Configuration = configuration;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var url = "http://" + Configuration["url"] + ":88/api/v1/requests/";
            var content = await client.GetStringAsync(url);
            List<Request> data = JsonConvert.DeserializeObject<List<Request>>(content);
            List<SelectListItem> flows = new List<SelectListItem>();
            foreach (var flow in data)
            {
                flows.Add(new SelectListItem
                {
                    Value = flow.Id.ToString(),
                    Text = flow.Title
                });
            }
            ViewBag.flows = flows;
            return View(data);
        }



        [HttpGet]
        public async Task<IActionResult> ChangeRequest(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var client = new HttpClient();
            var content = await client.GetStringAsync("http://" + Configuration["url"] + ":88/api/v1/requests/" + id.ToString());
            var request = JsonConvert.DeserializeObject<Request>(content);
            return PartialView("progressing", request);
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync("http://" + Configuration["url"] + ":88/api/v1/requests/" + id.ToString());
            var request = JsonConvert.DeserializeObject<Request>(content);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteTask(CompleteTaskModel model)
        {
            if (model is null)
            {
                return Json("Lỗi: sai cấu hình");
            }
            var task = new Models.Task
            {
                Id = model.TaskId,
                IsDone = model.IsDone
            };
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
            var result = await client.PutAsync("http://" + Configuration["url"] + ":88/api/v1/requests/" + model.RequestId.ToString() + "?autoadvance=" + model.AutoAdvance, content);

            if (result.IsSuccessStatusCode)
            {
                return Json("Thao tác thành công");
            }
            return Json("Lỗi: không tìm thấy máy chủ");
        }

        [HttpPost]
        public async Task<IActionResult> doSomething(int id, SubmitActionViewModel model)
        {
            if (model is null)
            {
                return Json("Lỗi: sai cấu trúc dữ liệu");
            }
            var client = new HttpClient();
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var result = await client.PutAsync("http://" + Configuration["url"] + ":88/api/v1/requests/submitaction/" + id.ToString(), content);

                if (result.IsSuccessStatusCode)
                {
                    return Json("Thao tác thành công, click \"Ok\" để load lại quy trình");
                }
                return Json("Lỗi: không tìm thấy máy chủ");
            }
            catch (System.Exception)
            {
                return Json("Lỗi: không tìm thấy máy chủ");
                throw;
            }

        }

        public IActionResult GeneralPartial()
        {
            return PartialView("state-create");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestViewModel model)
        {
            if (model is null)
            {
                return Json("Lỗi: sai cấu hình dữ liệu");
            }
            Process new_process = new Process
            {
                Name = "test",
                Actions = new List<Models.Action>(),
                States = new List<State>(),
                Activities = new List<Activity>(),
                Roles = new List<Role>(),
                Rules = new List<TransitionRule>()

            };
            if (model.Process.States is null)
            {
                return Json("Lỗi: sai cấu trúc dữ liệu");
            }
            foreach (var state in model.Process.States)
            {
                State new_state = new State
                {
                    Name = state.Name,
                    Activities = new List<Activity>(),
                    Description = "",
                    StateType = state.StateType,
                    Roles = new List<Role>(),
                    ETA = state.ETA
                };
                if (state.Activities != null)
                {
                    foreach (var activity in state.Activities)
                    {
                        Activity new_activity = new Activity
                        {
                            ActivityType = activity.ActivityType,
                            Name = activity.Name,
                            Description = activity.Description,
                            Roles = new List<Role>(),
                            IsRequired = true,
                            Duration = activity.Duration,
                            Data = new List<Data>(),
                            AbsentName = activity.AbsentName,
                            ApproverName = activity.ApproverName,
                            DayOff = activity.DayOff,
                            IsReallyNotApproved = activity.IsReallyNotApproved,
                            Reason = activity.Reason
                        };
                        if (activity.Roles != null)
                        {
                            foreach (var role in activity.Roles)
                            {
                                Role temp = new Role { Name = role.Name };
                                new_activity.Roles.Add(temp);
                                new_process.Roles.Add(temp);
                            }
                            new_state.Activities.Add(new_activity);

                        }
                        new_process.Activities.Add(new_activity);

                    }
                    new_process.States.Add(new_state);
                }

            }
            if (model.Process.Rules is null)
            {
                return Json("Lỗi: sai cấu trúc dữ liệu");
            }
            foreach (var action in model.Process.Actions)
            {
                var new_action = new Models.Action
                {
                    Name = action.Name,
                    Description = action.Description
                };
                new_process.Actions.Add(new_action);
            }
            foreach (var rule in model.Process.Rules)
            {
                var new_rule = new TransitionRule
                {
                    Action = new_process.Actions.FirstOrDefault(a => a.Name == rule.Action),
                    CurrentState = new_process.States.FirstOrDefault(s => s.Name == rule.CurrentState),
                    NextState = new_process.States.FirstOrDefault(s => s.Name == rule.NextState)
                };
                new_process.Rules.Add(new_rule);
            }
            Models.Request new_request = new Request
            {
                CurrentState = new_process.States.First(),
                Data = null,
                Histories = null,
                Process = new_process,
                Tasks = null,
                Title = model.Title,
                UserName = "test user"
            };
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new_request), Encoding.UTF8, "application/json");
            var result = await client.PostAsync("http://" + Configuration["url"] + ":88/api/v1/requests/", content);
            if (!result.IsSuccessStatusCode)
            {
                return Json("Lỗi: không tìm thấy máy chủ");
            }
            return Json("Yêu cầu đã được tạo thành công");
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Name,Kind,FlowId,RequesterId,Contents,File0,File1,File2,File3,File4,StartDate,EndDate,CustomerName,Phone,Email,Product, ApplicantId")] Request request)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         HttpClient client = new HttpClient();
        //         var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        //         await client.PostAsync("http://10.3.242.44:88/api/v1/requests/", content);

        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(request);
        // }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new HttpClient();
            var request = JsonConvert.DeserializeObject<Models.Request>(await client.GetStringAsync("http://" + Configuration["url"] + ":88/api/v1/requests/" + id.ToString()));
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Kind,FlowId,RequesterId,Contents,File0,File1,File2,File3,File4,StartDate,EndDate, ApplicantId,CustomerName,Phone,Email,Product")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var client = new HttpClient();
                string json = JsonConvert.SerializeObject(request);
                var result = await client.PutAsync(new Uri("http://" + Configuration["url"] + ":88/api/v1/requests/" + id.ToString()), new StringContent(json, Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpClient cl = new HttpClient();
            var request = JsonConvert.DeserializeObject<Models.Request>(await cl.GetStringAsync("http://" + Configuration["url"] + ":88/api/v1/requests/" + id.ToString()));

            if (request is null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            var client = new HttpClient();
            var result = await client.DeleteAsync("http://" + Configuration["url"] + ":88/api/v1/requests/" + id.ToString());
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
