## Pushing SDL Web Notifications to Slack
The project is an SDL Web event-system class library which pushes notifications from the Content Manager via event-system hooks to webhooks setup in a custom Slack application. The example shown pushes a simple notification when a page has been published, but it would be easy to extend it to support all kinds of interesting use cases, including.

* Pushing workflow notifications (reminders, workflow completion)
* Log tridion actions (publish, localize, delete etc) in custom Slack channels


### Creating a Slack app
Getting started with Slack is super easy. Head on over to [https://api.slack.com/apps](https://api.slack.com/apps) to create your Slack application which will be the "bot" that appears in the Slack channel posting the messages. You'll be prompted to login / create an account; if you've never created a Slack account create a personal workspace, and register an account. A Slack workspace is a private environment controlled by you representing your organization, so I recommend creating a personal Slack workspace for development. 

Once you have your Slack application setup, it's easy to enable webhooks.

* Go to your application & click "Basic Information"
* Click Incoming Webhooks & enable it.
* Create a new webhook and select the channel.
* Grab the webhook URL.

![Enabling slack webhooks](http://whobrokethebuild.me/wp-content/uploads/enable-webhook.gif)

[Learn more about Slack workspaces here.](https://get.slack.help/hc/en-us/articles/115004071768-What-is-Slack-)


### Adding your Webhook URL to the project & building
With the project pulled down to your local environment, open **Events.cs** and update the constant **SLACK_WEBHOOK_URL** with your Webhook URL. 

Build the project and deploy the DLL. [Read more about deploying an Event-System DLL in Web 8.5](https://docs.sdl.com/LiveContent/content/en-US/SDL%20Web-v5/GUID-AB4FBF5F-7C3B-4804-9E7F-FBBF5514A596#docid=GUID-87B291DD-99C5-4124-BDAE-B49182072ABA&filename=GUID-6363D3C7-0604-49DF-AF3D-86A1AC446CBB.xml&query=&scope=&tid=&resource=&inner_id=&addHistory=true&toc=false&eventType=lcContent.loadDocGUID-87B291DD-99C5-4124-BDAE-B49182072ABA)

When pages are published, you'll see the following in the Slack Channel you selected when creating the webhook in your slack app.

![Slack Bot](http://whobrokethebuild.me/wp-content/uploads/sdl-web-bot.png)

### Project Details
The project uses two Nuget libraries:

* ILMerge (v1.0.5)
* Newtonsoft.Json (v11.0.2)

ILMerge is a build task package which bundles up any dependent DLLs which are copied to the build folder. The event-system DLL is eventually deployed directly to the Content Manager, and therefore we need to bring along any dependencies.
