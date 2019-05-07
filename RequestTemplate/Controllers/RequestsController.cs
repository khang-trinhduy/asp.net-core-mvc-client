using System;
using System.Collections.Generic;
using System.IO;
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
        public int MyProperty { get; set; }
        public List<Campaign> campaigns;
        public List<Contact> contacts;

        public RequestsController(RequestContext context, IConfiguration configuration)
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://" + Configuration["url"] + ":88/api/v1/requests");
            _context = context;
            Configuration = configuration;
            StreamReader rd = new StreamReader("campaign.json");
            List<Campaign> campaigns = JsonConvert.DeserializeObject<List<Campaign>>(rd.ReadToEnd());
            StreamReader rd1 = new StreamReader("contact.json");
            List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(rd1.ReadToEnd());
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

        [HttpPost]
        public IActionResult StartCampaign(int id, string campaign, Trigger t)
        {
            var camp = campaigns.FirstOrDefault(c => c.Name.Equals(campaign));
            
            if (camp is null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult CreateTask()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync("http://" + Configuration["url"] + ":88/api/v1/requests/tasks?role=hr");
            List<Request> requests = JsonConvert.DeserializeObject<List<Request>>(content);
            return View(requests);
        }

        [HttpPost]
        public IActionResult Dashboard(Request r) {
            return View();
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
        public async Task<IActionResult> doSomething(int id, bool istree, bool trigger, SubmitActionViewModel model)
        {
            if (model is null)
            {
                return Json("Lỗi: sai cấu trúc dữ liệu");
            }
            var client = new HttpClient();
            try
            {
                if (istree) {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("http://" + Configuration["url"] + ":88/api/v1/requests/submitnodeaction/" + id.ToString(), content);
                    if (result.IsSuccessStatusCode)
                    {
                        return Json("Thao tác thành công, click \"Ok\" để load lại quy trình");
                    }
                    return Json("Lỗi: không tìm thấy máy chủ");
                }
                else {
                    if (trigger) {
                        model.data = new List<DataCreateModel> {
                            new DataCreateModel {
                                CampaignName = "Campaign ",
                                IsRunning = false,
                                DataType = DataType.Campaign
                            }
                        };
                        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                        var result = await client.PutAsync("http://" + Configuration["url"] +
                            ":88/api/v1/requests/submitaction/" + id.ToString() + "?trigger=true", content);
                        if (result.IsSuccessStatusCode)
                        {
                            return Json("Thao tác thành công, click \"Ok\" để load lại quy trình");
                        }
                        return Json(model);
                    }
                    else {
                        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                        var result = await client.PutAsync("http://" + Configuration["url"] +
                            ":88/api/v1/requests/submitaction/" + id.ToString() + "?trigger=false", content);
                        if (result.IsSuccessStatusCode)
                        {
                            return Json("Thao tác thành công, click \"Ok\" để load lại quy trình");
                        }
                        return Json("Lỗi: không tìm thấy máy chủ");

                    }
                }
                
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
                            Reason = activity.Reason,
                            CampaignName = activity.CampaignName,
                            IsRunning = activity.IsRunning
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
            var trigger = new Trigger {
                Consequence = new Consequence {
                    Method = "AddContact",
                    Name = "Campaign"
                },
                Events = new List<Event> {
                    new Event {
                        Conditions = new List<Condition> {
                            new Condition {
                                Operator = "GreaterOrEqual",
                                Param = "Age",
                                Threshold = "18",
                                Type = "Integer"
                            }
                        },
                        Name = "Must be 18 or above to enter this campaign"
                    }
                }
            };
            foreach (var rule in model.Process.Rules)
            {
                var new_rule = new TransitionRule
                {
                    Action = new_process.Actions.FirstOrDefault(a => a.Name == rule.Action),
                    CurrentState = new_process.States.FirstOrDefault(s => s.Name == rule.CurrentState),
                    NextState = new_process.States.FirstOrDefault(s => s.Name == rule.NextState)
                };
                if (new_rule.CurrentState.Activities[0].ActivityType == ActivityType.Campaign) {
                    new_rule.Trigger = trigger;
                }
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
            return Json(new_request);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTree(RequestViewModel model)
        {
            if (model is null)
            {
                return Json("Lỗi: sai cấu hình dữ liệu");
            }
            Process new_process = new Process
            {
                Name = "test",
                Actions = new List<Models.Action>(),
                Nodes = new List<Node>(),
                Activities = new List<Activity>(),
                Roles = new List<Role>(),
                Rules = new List<TransitionRule>()

            };
            if (model.Process.Nodes is null)
            {
                return Json("Lỗi: sai cấu trúc dữ liệu");
            }
            foreach (var node in model.Process.Nodes)
            {
                Node new_node = new Node
                {
                    Name = node.Name,
                    Activities = new List<Activity>(),
                    Description = node.Description,
                    Level = node.Level,
                    Roles = new List<Role>(),
                    Actions = node.Actions,
                    Childs = new List<Node>()
                };
                if (node.Activities != null)
                {
                    foreach (var activity in node.Activities)
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
                            Reason = activity.Reason,
                            CampaignName = activity.CampaignName,
                            IsRunning = activity.IsRunning
                        };
                        if (activity.Roles != null)
                        {
                            foreach (var role in activity.Roles)
                            {
                                Role temp = new Role { Name = role.Name };
                                new_activity.Roles.Add(temp);
                                new_process.Roles.Add(temp);
                            }
                            new_node.Activities.Add(new_activity);

                        }
                        new_process.Activities.Add(new_activity);

                    }
                    new_process.Nodes.Add(new_node);
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
                    CurrentNode = new_process.Nodes.FirstOrDefault(s => s.Name == rule.CurrentNode),
                    NextNode = new_process.Nodes.FirstOrDefault(s => s.Name == rule.NextNode)
                };
                new_process.Rules.Add(new_rule);
            }
            Models.Request new_request = new Request
            {
                CurrentNode = new_process.Nodes.FirstOrDefault(n => n.Level == 0),
                Data = null,
                Histories = null,
                Process = new_process,
                Tasks = null,
                Title = model.Title,
                UserName = "test user"
            };
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new_request), Encoding.UTF8, "application/json");
            var result = await client.PostAsync("http://" + Configuration["url"] + ":88/api/v1/requests/tree/", content);
            if (!result.IsSuccessStatusCode)
            {
                return Json("Lỗi: không tìm thấy máy chủ");
            }
            return Json(new_request);
        }
    }
}
