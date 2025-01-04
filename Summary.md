#  Integration with Kubiya platform

# My integration experience

My experience integrating with the Kubiya platform was quite interesting and smooth.

Despite the lack of information shared in the Take-Home Test document, which I believe was intentional, I was able to find the information I needed as I progressed through the experiment.

# Approach

I initially decided to gain a bit more knowledge of the platform by searching for documentation online.

I found this documentation repository, where I was able to understand a bit more about the concepts (teammate, runner, tools and tasks). I also understood that there are a few options to interact with the platform, such as via the web, CLI and mainly via slack bot.

https://docs.kubiya.ai/docs/getting-started/get-started

# Application used

I decided to use the code from one of the components of a personal app, called YouTubeBlink. This is my experimental GenAI app used to automatically create video summaries of YouTube channels and help me keep track of my favorite content. The full description of the solution can be found in the article below.

https://medium.com/@felipecembranelli/youtubeblink-an-openai-video-summary-generator-37ab541c9493

SCREENSHOT

# GitHub workflow

I created a new workflow to build in a docker container and push to the docker registry (DockerHub). To do this, I configured the DockerHub credentials using GitHub secrets.

LINK

After setting up a new branch and simulating the test failure, I verified that my Kubiya use case had created a webhook in my repository and that information was flowing to the Kubiya platform.

SCREENSHOT

# Note

I noticed that I was getting some errors in Slack, likely related to permission limitations on the Kubi access token for my repository. Since the task required a public repository, as soon as I set my repository to public, Kubi started collecting information correctly. Further investigation would be needed to properly set up the access token and troubleshoot the issue.



