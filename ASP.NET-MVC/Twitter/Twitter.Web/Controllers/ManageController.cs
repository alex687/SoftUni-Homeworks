namespace Twitter.Web.Controllers
{
    #region

    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    using Twitter.Web.Models;

    #endregion

    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager signInManager;

        private ApplicationUserManager userManager;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this.signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }

            private set
            {
                this.signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this.userManager = value;
            }
        }

        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage = message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed." 
                                       : message == ManageMessageId.Error ? "An error has occurred."
                                       : message == ManageMessageId.ChangeEmailSuccess ? "Your email was changed."
                                       : string.Empty;

            var userId = this.User.Identity.GetUserId();
            var model = new IndexViewModel
                            {
                                HasPassword = this.HasPassword(), 
                                PhoneNumber = await this.UserManager.GetPhoneNumberAsync(userId), 
                                TwoFactor = await this.UserManager.GetTwoFactorEnabledAsync(userId), 
                                Logins = await this.UserManager.GetLoginsAsync(userId), 
                                BrowserRemembered =
                                    await
                                    this.AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
                            };
            return this.View(model);
        }

        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return this.View();
        }

        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result =
                await
                this.UserManager.ChangePasswordAsync(
                    this.User.Identity.GetUserId(), 
                    model.OldPassword, 
                    model.NewPassword);
            if (result.Succeeded)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.SignInManager.SignInAsync(user, false, false);
                }

                return this.RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }

            this.AddErrors(result);
            return this.View(model);
        }

        // GET: /Manage/ChangeEmail
        public ActionResult ChangeEmail()
        {
            return this.View();
        }

        // POST: /Manage/ChangeEmail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeEmail(ChangeEmailViewModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            var isValidPassword = await this.UserManager.CheckPasswordAsync(user, model.Pasword);
            if (isValidPassword)
            {
                user.Email = model.NewEmail;
                var result = await this.UserManager.SetEmailAsync(user.Id, model.NewEmail);
                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index", new { Message = ManageMessageId.ChangeEmailSuccess });
                }

                this.AddErrors(result);
                return this.View(model);
            }

            this.ModelState.AddModelError(string.Empty, "Invalid password");
            return this.View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.userManager != null)
            {
                this.userManager.Dispose();
                this.userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error);
            }
        }

        private bool HasPassword()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }

            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess, 

            SetPasswordSuccess, 

            Error, 

            ChangeEmailSuccess
        }

        #endregion
    }
}