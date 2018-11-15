using System;
using Tridion.ContentManager.Extensibility;
using Tridion.ContentManager.Extensibility.Events;
using Tridion.ContentManager.CommunicationManagement;

namespace Slack.Events
{
    [TcmExtension("SlackEvents")]
    public class Events : TcmExtension
    {
        // TODO : Update this URL with the webhook in your slack application.
        private const string SLACK_WEBHOOK_URL = "https://hooks.slack.com/services/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";

        /// <summary>
        /// Default constructor to subscribe all of the events.
        /// </summary>
        public Events()
        {
            Subscribe();
        }

        public void Subscribe()
        {
            EventSystem.Subscribe<Page, SetPublishStateEventArgs>(OnPublish, EventPhases.TransactionCommitted);
        }

        /// <summary>
        /// On publish of a page, post that the page has been been in slack.
        /// </summary>
        private void OnPublish(Page page, SetPublishStateEventArgs e, EventPhases phase)
        {
            SlackClient client = new SlackClient(SLACK_WEBHOOK_URL);

            string status = e.IsPublished ? "published" : "unpublished";
            client.PostMessage(text: "Page '" + page.Title + "' was " + status + " to " + e.Target.Title + " at " + DateTime.Now);
        }


    }
}
