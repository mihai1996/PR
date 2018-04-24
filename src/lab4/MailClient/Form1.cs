using S22.Imap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    public partial class Form1 : Form
    {
        static Form1 f;

        public Form1()
        {
            InitializeComponent();
            f = this;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
           var emailText = emailTextBox.Text;
           var bodyText = bodyTextBox.Text;
           var passwordText = passwordTextBox.Text;
           var subjectText = subjectTextBox.Text;
           var recipientText = recipientTextBox.Text;

            Task.Run(() =>
            {

                using (SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587))
                {
                    mailer.Credentials = new NetworkCredential(emailText, passwordText);
                    MailMessage message = new MailMessage(emailText, recipientText);
                    message.Subject = subjectText;
                    message.Body = bodyText;

                    mailer.EnableSsl = true;
                    mailer.Send(message);
                }
            });

            recipientTextBox.Text = null;
            subjectTextBox.Text = null;
            bodyTextBox.Text = null;

        }

        private void receiveButton_Click(object sender, EventArgs e)
        {
            StartReceive();
        }

        private void StartReceive()
        {
            Task.Run(() =>
            {
                using (ImapClient client = new ImapClient("imap.gmail.com", 993, 
                    emailTextBox.Text, passwordTextBox.Text, AuthMethod.Login, true))
                {
                    if (client.Supports("IDLE") == false)
                    {
                        MessageBox.Show("Server does not support IMAP IDLE");
                        return;
                    }
                    client.NewMessage += new EventHandler<IdleMessageEventArgs>(OnNewMessage);
                    while (true) ;
                }
            });
        }

        static void OnNewMessage(object sender, IdleMessageEventArgs e)
        {
            MessageBox.Show("You have a new message");
            var m = e.Client.GetMessage(e.MessageUID, FetchOptions.Normal);

            f.Invoke((MethodInvoker)delegate
            {
                f.receiveTextBox.AppendText("From: " + m.From + "\n" +
                                            "Subject: " + m.Subject + "\n" +
                                            "Body" + m.Body + "\n");
            });
        }
    }
}
