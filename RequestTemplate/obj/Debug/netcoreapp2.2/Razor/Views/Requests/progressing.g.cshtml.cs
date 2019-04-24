#pragma checksum "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\Requests\progressing.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc15a98e689e72ebbaed8dcfd11636c6f455a45d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Requests_progressing), @"mvc.1.0.view", @"/Views/Requests/progressing.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Requests/progressing.cshtml", typeof(AspNetCore.Views_Requests_progressing))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\_ViewImports.cshtml"
using RequestTemplate;

#line default
#line hidden
#line 2 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\_ViewImports.cshtml"
using RequestTemplate.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc15a98e689e72ebbaed8dcfd11636c6f455a45d", @"/Views/Requests/progressing.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fda2e95e24e3ea526a4b43c49a0fd099761cada", @"/Views/_ViewImports.cshtml")]
    public class Views_Requests_progressing : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RequestTemplate.Models.Request>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\Requests\progressing.cshtml"
  
    Model.Process.States = Model.Process.States.OrderBy(s => s.Id).ToList();
    Model.Process.Activities = Model.Process.Activities.OrderBy(a => a.Id).ToList();

#line default
#line hidden
            BeginContext(210, 84, true);
            WriteLiteral("\r\n<div class=\"process-header\">\r\n    <div id=\"header\">\r\n        <h3 id=\'model-title\'>");
            EndContext();
            BeginContext(295, 11, false);
#line 9 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\Requests\progressing.cshtml"
                        Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(306, 2774, true);
            WriteLiteral(@"</h3>
    </div>
    <div class=""process-deadline"">

    </div>
    <div class=""gamify-area"">

    </div>
</div>
<hr/>
<div onclick="""" class=""progress-timeline"">
    
</div>

<div id=""content"">
    <ul class=""timeline"">  
    </ul>
</div>

<style>
    .progress-state > p > span {
        font-size: x-small;
    }
    .email-container{
        box-shadow: 2px 2px 2px 10px rgba(#333, 0.2);
        display: grid;
        background: white;
    }
    .fas, .fab, .far{
        margin-right: 10px;

    }
    .fab{
        margin-right: 5px;
    }
    .send{
        text-align: right;
        width: 50%;
        float:right;
        color:#3dacef;
    }
    .progress-state{
        font-size: 1.2em !important;
        font-family: 'Raleway', sans-serif;
        text-align: left;
        position: relative;
        letter-spacing: 1.5px;
        font-weight: 100;
        border-bottom: 1px solid #777;
        margin-bottom: 0px;
        padding: 12px;
    }
    .pro");
            WriteLiteral(@"gress-state>p {
       margin-bottom: 0;
    }

    .progress-state > label {
        font-weight: bold;
        font-size: 1.4em;
    }
    #content {
        margin-top: 50px;
        text-align: center;
    }

    .timeline {
        border-left: 0.25em solid #4298c3;
        background: white;
        margin: 2em auto;
        line-height: 1.2;
        padding: 1em;
        padding-left: 3em;
        list-style: none;
        text-align: left;
        margin-left: 10em;
        margin-right: 3em;
        border-radius: 0.5em;
        min-width: 22em;
        box-shadow: 5px 8px 6px 0px #e4e1ea;
    }

    .event {
        min-width: 20em;
        width: 100%;
        vertical-align: middle;
        box-sizing: border-box;
        position: relative;
    }

    .timeline .event:before,
    .timeline .event:after {
        position: absolute;
        display: block;
        top: 1em;
    }

    .timeline .event:before {
    left: -15em;
    color: black;
    co");
            WriteLiteral(@"ntent: attr(data-date);
    text-align: right;
    font-weight: 100;
    font-size: 0.9em;
    min-width: 9em;
    }

    .timeline .event:after {
        box-shadow: 0 0 0 0.2em #4298c3;
        left: -3.5em;
        background: #313534;
        border-radius: 50%;
        height: 0.75em;
        width: 0.75em;
        content: """";
    }

    

    .activities {
        <!-- display: inline-block; -->
        font-weight: bold;
        vertical-align: bottom;
        <!-- line-height: 8px; -->
        <!-- float: right; -->
    }

    .activities li {
        display: inline-block;
    }
    a:hover {
        cursor: pointer;
    }
</style>

<script>
    var process = JSON.parse('");
            EndContext();
            BeginContext(3081, 39, false);
#line 144 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\Requests\progressing.cshtml"
                         Write(Html.Raw(Json.Serialize(Model.Process)));

#line default
#line hidden
            EndContext();
            BeginContext(3120, 141, true);
            WriteLiteral("\');\r\n    var states = process.states;\r\n    var nodes = process.nodes;\r\n    var activities = process.activities;\r\n    var tasks = JSON.parse(\'");
            EndContext();
            BeginContext(3262, 37, false);
#line 148 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\Requests\progressing.cshtml"
                       Write(Html.Raw(Json.Serialize(Model.Tasks)));

#line default
#line hidden
            EndContext();
            BeginContext(3299, 35, true);
            WriteLiteral("\');\r\n    var request = JSON.parse(\'");
            EndContext();
            BeginContext(3335, 31, false);
#line 149 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\Requests\progressing.cshtml"
                         Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
            EndContext();
            BeginContext(3366, 676, true);
            WriteLiteral(@"');
    var random_name = ['Nguyễn Thị A', 'Trần Văn B', 'Nguyễn Duy C', 'Lê Văn D', 'Phạm Tấn F', 'Dương Thị G', 'Trương Ngọc H'];
    function slide(param) {
        $(param).next().slideToggle();
        
    };

    function CheckWhetherRequestIsCompleted(request)
    {
        var is_not_really_completed = false;
        request.tasks.forEach(task => {
            if (!task.isDone) {
                is_not_really_completed = true;
            }
        });
        return is_not_really_completed;
    }

    function complete_task(id, action) {
        tasks.forEach(task => {
            if (task.activity.id == id) {
                var url = '");
            EndContext();
            BeginContext(4043, 38, false);
#line 170 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\Requests\progressing.cshtml"
                      Write(Url.Action("completetask", "requests"));

#line default
#line hidden
            EndContext();
            BeginContext(4081, 1977, true);
            WriteLiteral(@"';
                data = {""taskid"": task.id, ""isdone"": false, ""requestid"": request.id, ""autoadvance"": ""true""};
                // console.log(data);
                $.ajax({
                    type: ""post"",
                    url: url,
                    data: data,
                    header: {
                        ""content-type"": ""application/json""
                    },
                    success: function (response) {
                        console.log(response);
                    },
                    error: function (){
                        console.log(""error"");
                    }
                });
            }
        });
    }

    function call_something(id,state,activity,action) {
        tasks.forEach(task => {
            if (task.activity.id == id) {
                var isreallynotapproved = false;
                if(action == 'deny')
                {
                    isreallynotapproved = true;
                }
                var core_data ");
            WriteLiteral(@"= {""datatype"": ""TalentLeave"", ""absentname"": $('#activity-abse' + id.toString()).text(), ""approvername"": $('#activity-appr' + id.toString()).val(), ""dayoff"": $('#activity-dayo' + id.toString()).text(), ""reason"": $('#activity-reas' + id.toString()).text(), ""isdone"": true, ""isreallynotapproved"": isreallynotapproved};
                var extra = {""datatype"": ""Comment"", ""messages"": $('#activity-data' + id.toString()).val(), ""emoji"": """", ""topic"": ""TL_AC""};
                var activity_data = []
                if (core_data.approvername != undefined && core_data.absentname != '') {
                    activity_data.push(core_data);
                }
                if (extra.messages != '') {
                    activity_data.push(extra);
                }
                var wont_do = true;
                if(activity_data != null)
                {
                    wont_do = false;
                }
                var url = '");
            EndContext();
            BeginContext(6059, 37, false);
#line 213 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\Requests\progressing.cshtml"
                      Write(Url.Action("dosomething", "requests"));

#line default
#line hidden
            EndContext();
            BeginContext(6096, 2052, true);
            WriteLiteral(@"' + '?id=' + request.id.toString() + '&istree=false';
                data = {""source"": state, ""role"": $('#activity-role' + id.toString()).val(), ""action"": action, ""activity"": activity, ""approver"": $('#activity-appr' + id.toString()).val(), ""data"": activity_data, ""doactivity"": wont_do};
                console.log(data);
                $.ajax({
                    type: ""post"",
                    url: url,
                    data: data,
                    header: {
                        ""content-type"": ""application/json""
                    },
                    success: function (response) {
                        console.log(response);
                        alert(response);
                    },
                    error: function (){
                        alert('Bạn không có quyền thực hiện tác vụ này');
                    }
                });
            }
        });
    }

    function node_call_something(id,node,activity,action) {
        tasks.forEach(task => {
 ");
            WriteLiteral(@"           if (task.activity.id == id) {
                
                var core_data = {""datatype"": ""TalentLeave"", ""absentname"": $('#activity-abse' + id.toString()).text(), ""approvername"": $('#activity-appr' + id.toString()).val(), ""dayoff"": $('#activity-dayo' + id.toString()).text(), ""reason"": $('#activity-reas' + id.toString()).text(), ""isdone"": true, ""isreallynotapproved"": true};
                var extra = {""datatype"": ""Comment"", ""messages"": $('#activity-data' + id.toString()).val(), ""emoji"": """", ""topic"": ""TL_AC""};
                var activity_data = []
                if (core_data.approvername != undefined && core_data.absentname != '') {
                    activity_data.push(core_data);
                }
                if (extra.messages != '') {
                    activity_data.push(extra);
                }
                var wont_do = true;
                if(activity_data != null)
                {
                    wont_do = false;
                }
                var url");
            WriteLiteral(" = \'");
            EndContext();
            BeginContext(8149, 37, false);
#line 253 "C:\Users\trinh\source\repos\RequestTemplate\RequestTemplate\Views\Requests\progressing.cshtml"
                      Write(Url.Action("dosomething", "requests"));

#line default
#line hidden
            EndContext();
            BeginContext(8186, 15005, true);
            WriteLiteral(@"' + '?id=' + request.id.toString() + '&istree=true';
                data = {""source"": node, ""role"": $('#activity-role' + id.toString()).val(), ""action"": action, ""activity"": activity, ""approver"": $('#activity-appr' + id.toString()).val(), ""data"": activity_data, ""doactivity"": wont_do};
                console.log(data);
                $.ajax({
                    type: ""post"",
                    url: url,
                    data: data,
                    header: {
                        ""content-type"": ""application/json""
                    },
                    success: function (response) {
                        console.log(response);
                        alert(response);
                    },
                    error: function (){
                        alert('Bạn không có quyền thực hiện tác vụ này');
                    }
                });
            }
        });
    }

    function get_random_name() {
        var randomnumber = Math.floor(Math.random() * (random_n");
            WriteLiteral(@"ame.length - 1 - 0 + 1)) + 0;
        return random_name[randomnumber];
    }

    function absent_template(activity, state) {
        var elem = 
        '<div class=""absent-container"">' +
            '<div class=""absent-contents"">' +
                '<div><span style=""display: inline"">Tên nhân viên: </span><p style=""display:inline"" id=""activity-abse' + activity.id + '"">' + activity.absentName + '</p></div>' +
                '<div><span style=""display: inline"">Ngày xin nghỉ: </span><p style=""display:inline"" id=""activity-dayo' + activity.id + '"">' + activity.dayOff + '</p></div>' +
                '<div><span style=""display: inline"">Lý do: </span><p style=""display:inline"" id=""activity-reas' + activity.id + '"">' + activity.reason + '</p></div>' +
                '<input hidden value=""' + get_random_name() + '"" class=""form-control"" type=""text"" id=""activity-appr' + activity.id + '"" placeholder=""Người thẩm định"" />' +
                '<input hidden value=""hr"" class=""form-control"" type=""text"" id=""acti");
            WriteLiteral(@"vity-role' + activity.id + '"" placeholder=""Thuộc bộ phận"" />' +
                '<div><a style=""display:block"" onclick=""slider(' + activity.id + ')"">Thêm nhận xét</a></div>' +
                '<input class=""form-control"" type=""text"" id=""activity-data' + activity.id + '"" placeholder=""Message"" />' +
                '<button class=""btn btn-success"" onclick=""call_something('+ activity.id +',\''+state.trim()+ '\',\'' + activity.name.trim() + '\',\'approve\')"" title="""">Chấp nhận</button>' +
                '<button class=""btn btn-danger"" onclick=""call_something(' + activity.id +',\'' + state.trim() + '\',\'' + activity.name.trim() + '\',\'deny\')"" title="""">Từ chối</button>' +
            '</div>' +
        '</div>';
        return elem;
    }

    function slider(id){
        $(""#activity-data"" + id.toString()).slideToggle();
    }

    function comment_data(activity) {
        var elem = 
        '<div class=""comment-container"">' +
            '<div class=""comment-content"">' +
                '<i");
            WriteLiteral(@"nput id=""comment-contents' + activity.id + '""/>' +
            '</div>' +
            '<div class=""comment-handler"">' +
                '<i class=""far fa-grin"" title=""Emojis"" onclick=""addEmoji(' + id +')""></i>' +
                '<i class=""far fa-paper-plane"" title=""Gửi"" onclick=""addComment(' + id +')""></i>' +
            '</div>'+
        '</div>';
    }

    function email_template(activity) {
        var elem = 
        '<div class=""email-container"">' +
            '<div class=""email-header"">' +
                '<label class=""control-label"" id=""lto' + activity.id + '"">To: </label>  <input class=""form-control"" id=""to' + activity.id +'"" type=""text"" placeholder="""" />' +
                '<a class=""cbb"">Cbb/Bb</a>' +
                '<div id=""additional""><label class=""control-label"" class=""to"">Cbb: </label>  <input class=""form-control"" id=""Cbb' + activity.id +'"" type=""text"" placeholder="""" /></div>' +
                '<label class=""control-label"" class=""to"">Bb: </label>  <input class=""form-contro");
            WriteLiteral(@"l"" id=""Bb' + activity.id +'"" type=""text"" placeholder="""" />' +
                '<label class=""control-label"" id=""subject"">Subject: </label><input class=""form-control"" id=""subject' + activity.id +'"" type=""text"" placeholder="""" />' +
            '</div>' +

            '<div class=""email-body"">' +
                '<label class=""control-label"" id=""email-content""></label><textarea class=""form-control"" rows=""5"" id=""contents' + activity.id +'""></textarea>' +
            '</div>' +

            '<div class=""email-attachment"">' +
                '<label>Attachment</label>' +
            '</div>' +
            '<div class=""email-action"">' +
                '<i class=""fas fa-paperclip"" title=""Đính kèm""></i>' +
                '<i class=""far fa-image"" title=""Ảnh""></i>' +
                '<i class=""far fa-laugh"" title=""Emoji""></i>' +
                '<i class=""fas fa-link"" title=""Link""></i>' +
                '<div class=""send""><i class=""fab fa-telegram-plane"" title=""Gửi""></i></div>' +
            '</div>'");
            WriteLiteral(@" +
        '</div>';
        return elem;
    }

    function generic(activity, state) {
        var btn = 'Hoàn tất';
        var elem = 
        '<div class=""generic-container"">' +
            '<div class=""activity-header"">' +
                '<p hidden id=""activity-title' + activity.id + '"">Công việc (nhiệm vụ): ' + '<span>' + activity.name + '</span>' + '</p>';
                if (activity.description != null) {
                    elem += '<p id=""activity-desc' + activity.id + '"">Mô tả (hướng dẫn): ' + activity.description + '</p>';
                }
                if (activity.duration > 0) {
                    elem += '<p id=""activity-desc' + activity.id + '"">Thời gian: ' + activity.duration + ' (giờ)</p>';
                }
                elem +=
                '<input hidden value=""' + get_random_name() + '"" class=""form-control"" type=""text"" id=""activity-appr' + activity.id + '"" placeholder=""Người thẩm định"" />' +
                '<input hidden value=""other"" class=""form-control""");
            WriteLiteral(@" type=""text"" id=""activity-role' + activity.id + '"" placeholder=""Thuộc bộ phận"" />' +
                '<div><a style=""display:block"" onclick=""slider(' + activity.id + ')"">Thêm nhận xét</a></div>' +
                '<input class=""form-control"" type=""text"" id=""activity-data' + activity.id + '"" placeholder=""Message"" />' ;
                if(request.data != null)
                {
                    elem += '<div class=""activity-data"">';
                    request.data.forEach(data => {
                        if(data.dataType == 6)
                        {
                            if(data.isReallyNotApproved == false)
                            {
                                elem += '<div><p>Yêu cầu được chấp nhận bởi (' + data.approverName + ')</p></div>';
                            }
                            else {
                                elem += '<div><p>Yêu cầu bị từ chối bởi (' + data.approverName + ')</p></div>';

                            }
                         ");
            WriteLiteral(@"   btn = 'Xác nhận';
                        }
                        else if (data.dataType == 5)
                        {
                            elem += '<div><p>' + get_random_name() +': ' + data.messages + '</p></div>';
                        }
                    });
                    elem += '</div>';
                }
                elem += '<button class=""btn btn-success"" onclick=""call_something(' + activity.id +',\'' + state.trim() + '\',\'' + activity.name.trim() + '\',\'approve\')"">Chấp nhận</button>' +
                '<button class=""btn btn-danger"" onclick=""call_something(' + activity.id +',\'' + state.trim() + '\',\'' + activity.name.trim() + '\',\'deny\')"">Từ chối</button>'
            '</div>' +
        '</div>';
        return elem;
    }
    function node_generic(activity, node, actions) {
        var btn = 'Hoàn tất';
        var elem = 
        '<div class=""generic-container"">' +
            '<div class=""activity-header"">' +
                '<p hidden id=""act");
            WriteLiteral(@"ivity-title' + activity.id + '"">Công việc (nhiệm vụ): ' + '<span>' + activity.name + '</span>' + '</p>';
                if (activity.description != null) {
                    elem += '<p id=""activity-desc' + activity.id + '"">Mô tả (hướng dẫn): ' + activity.description + '</p>';
                }
                if (activity.duration > 0) {
                    elem += '<p id=""activity-desc' + activity.id + '"">Thời gian: ' + activity.duration + ' (giờ)</p>';
                }
                elem +=
                '<input hidden value=""' + get_random_name() + '"" class=""form-control"" type=""text"" id=""activity-appr' + activity.id + '"" placeholder=""Người thẩm định"" />' +
                '<input hidden value=""other"" class=""form-control"" type=""text"" id=""activity-role' + activity.id + '"" placeholder=""Thuộc bộ phận"" />' +
                '<div><a style=""display:block"" onclick=""slider(' + activity.id + ')"">Thêm nhận xét</a></div>' +
                '<input class=""form-control"" type=""text"" id=""activity-data");
            WriteLiteral(@"' + activity.id + '"" placeholder=""Message"" />' ;
                if(request.data != null)
                {
                    elem += '<div class=""activity-data"">';
                    request.data.forEach(data => {
                        if(data.dataType == 6)
                        {
                            if(data.isReallyNotApproved == false)
                            {
                                elem += '<div><p>Yêu cầu được chấp nhận bởi (' + data.approverName + ')</p></div>';
                            }
                            else {
                                elem += '<div><p>Yêu cầu bị từ chối bởi (' + data.approverName + ')</p></div>';

                            }
                            btn = 'Xác nhận';
                        }
                        else if (data.dataType == 5)
                        {
                            elem += '<div><p>' + get_random_name() +': ' + data.messages + '</p></div>';
                        }
          ");
            WriteLiteral(@"          });
                    elem += '</div>';
                }
                actions.forEach(action => {
                    elem += '<button class=""btn btn-success"" onclick=""node_call_something(' + activity.id +',\'' + node.trim() + '\',\'' + activity.name.trim() + '\',\'' + action + '\')"">' + action + '</button>';
                });
                elem +=
            '</div>' +
        '</div>';
        return elem;
    }

    $(function () {
        var cpl = true;
        request.tasks.forEach(task => {
            if(task.isDone == false) {
                cpl = false;
                return false;
            }
        });
        if(cpl) {
            $('#model-title').text(request.title + ' (đã hoàn thành)');
        }
        if (states.length > 0) {
            console.log(""jump into state"");
            states.forEach(state => {
                var elem = '<li id=""fader"" class=""event"" data-date=""' + state.eta +'"">' +
                '<div class=""progress-state""");
            WriteLiteral(@" onclick=""slide(this)"">';
                if (state.id == request.currentState.id) {
                    elem += '<p id=""progress-title' + state.id + '"">' + state.name + ' <span>(trạng thái hiện tại)</span></p>';
                }
                else {
                    elem += '<p id=""progress-title' + state.id + '"">' + state.name + '</p>';
                }
                elem +=
                '</div>' +
                '<div class=""progress-activities"">' +
                    '<div class=""activities"">';
                        state.activities.forEach(activity => {
                            switch (activity.activityType) {
                                case 3:
                                    elem += generic(activity, state.name);
                                    break;
                                case 0:
                                    elem += email_template(activity);
                                    break;
                                case 1:
           ");
            WriteLiteral(@"                         elem += '<label class=""control-label"">' + activity.name + '</label>';
                                    break;
                                case 2:
                                    
                                    break;
                                case 4:
                                    elem += absent_template(activity, state.name);
                                    break;
                            
                                default:
                                    elem += '<label class=""control-label"">' + activity.name + '</label>';
                                    break;
                            }
                        });
                    elem += '</div>' +
                '</div>' +
                '</li>';
                $('.timeline').append(elem);         
                $('.absent-contents > input').slideToggle();
            });

        }
        else if (nodes.length > 0) {
            nodes.forEach(node");
            WriteLiteral(@" => {
                var actions = [];
                node.actions.forEach(action => {
                    actions.push(action.name);
                });
                var elem = '<li id=""fader"" class=""event"" data-date="""">' +
                '<div class=""progress-state"" onclick=""slide(this)"">';
                if (node.id == request.currentNode.id) {
                    elem += '<p id=""progress-title' + node.id + '"">' + node.name +' <span>(trạng thái hiện tại)</span></p>';
                }
                else {
                    elem += '<p id=""progress-title' + node.id + '"">' + node.name + '</p>';
                }
                elem += 
                '</div>' +
                '<div class=""progress-activities"">' + 
                    '<div class=""activities"">';
                        node.activities.forEach(activity => {
                            switch (activity.activityType) {
                                case 3:
                                    elem += node_gener");
            WriteLiteral(@"ic(activity, node.name, actions);
                                    break;
                            
                                default:
                                    elem += '<label class=""control-label"">' + activity.name + '</label>';
                                    break;
                            }
                        });
                    elem += '</div>' +
                '</div>' +
                '</li>';
                $('.timeline').append(elem);
                $('.absent-contents > input').slideToggle();
            });
        }
        $('.progress-state').nextAll().slideToggle();
    });
</script>

");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RequestTemplate.Models.Request> Html { get; private set; }
    }
}
#pragma warning restore 1591
