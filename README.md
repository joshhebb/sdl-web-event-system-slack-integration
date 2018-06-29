## Pushing SDL Web Notifications to Slack
The project is an SDL Web event-system class library project which pushes notifications from the Content Manager via event-system hooks to webhooks setup in a personal Slack app.

A few examples:
* Push workflow notifications
* Log tridion actions (publish, delete etc) in custom Slack channels

### Creating a Slack app
Getting started with Slack is super easy. Head on over to [https://api.slack.com/apps](https://api.slack.com/apps) to create your Slack application which will be the "bot" that appears in the Slack channel posting the messages. You'll be prompted to login / create an account; if you've never created a Slack account create a personal workspace, and register an account. 

I recommend creating a personal Slack workspace for development. 

[Learn more about Slack workspaces here.](https://get.slack.help/hc/en-us/articles/115004071768-What-is-Slack-)


### Project Details
The project uses two Nuget libraries:

* ILMerge (v1.0.5)
* Newtonsoft.Json (v11.0.2)

ILMerge is a build task package which bundles up any dependent DLLs which are copied to the build folder. The event-system DLL is eventually deployed directly to the Content Manager, and therefore we need to bring along any dependencies.