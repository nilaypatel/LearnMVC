using System.Web.Mvc;
using MVCWeb.UI.Models.UserDetail;
using System.Linq;
using MyApplication.Framework;

namespace MVCWeb.UI.Controllers
{
    public class UserDetailController : ControllerBase
    {
        public ActionResult Index()
        {
            return Display(new Index());
        }

        public ActionResult List(string username)
        {
            var users = new[]
            {
                new User {Id = 1, FirstName = "Fname1", LastName = "Lname1", UserName = "Uname1"},
                new User {Id = 2, FirstName = "Fname2", LastName = "Lname2", UserName = "Uname2"},
                new User {Id = 3, FirstName = "Fname3", LastName = "Lname3", UserName = "Uname3"},
                new User {Id = 4, FirstName = "Fname4", LastName = "Lname4", UserName = "Uname4"},
                new User {Id = 5, FirstName = "Fname5", LastName = "Lname5", UserName = "Uname5"},
                new User {Id = 6, FirstName = "Fname6", LastName = "Lname6", UserName = "Uname6"},
            };

            Grid.GridInfo.PagingInfo = new PagingInfo
            {
                PageNumber = 1,
                PageSize = 5,
                TotalRecords = 6
            };


            if (username != string.Empty)
            {
                users = users.Where(u => u.UserName == username).ToArray();
            }

            var model = new List()
            {
                Users = users
            };

            return Display(model);
        }

        public ActionResult Edit()
        {
            return Editor(new Edit());
        }


        [HttpPost]
        public ActionResult Edit(Edit editModel)
        {
            //ServerMessages.SetMessage(TempData, "This is message");
            //return CloseDialogAndRedirect(Url.Action<UserDetailController>(a => a.Index()));

            ServerMessages.SetError(TempData, "This is error");

            return Editor(new Edit());
        }
    }
}
