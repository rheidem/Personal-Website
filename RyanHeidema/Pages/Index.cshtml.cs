using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace RyanHeidema.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string EmailName { get; set; }

        [BindProperty]
        public string FromAddress { get; set; }

        [BindProperty]
        public string EmailSubject { get; set; }

        [BindProperty]
        public string EmailBody { get; set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost() 
        {
            if(String.IsNullOrEmpty(EmailName) || String.IsNullOrEmpty(FromAddress) ||
               String.IsNullOrEmpty(EmailSubject) || String.IsNullOrEmpty(EmailBody))
            {
                return Page();
            }
            else
            {
                Email email = new Email(EmailName, FromAddress, EmailSubject, EmailBody);
                email.SendEmail();
                return Page();
            }
        }
    }
}
