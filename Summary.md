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

![youtubeblink](https://github.com/user-attachments/assets/d53e5669-5146-47b9-9507-0cba4227d708)


# GitHub workflow

I created a new workflow to build in a docker container and push to the docker registry (DockerHub). To do this, I configured the DockerHub credentials using GitHub secrets.

After setting up a new branch and simulating the test failure, I verified that my Kubiya use case had created a webhook in my repository and that information was flowing to the Kubiya platform.

![webhook_github](https://github.com/user-attachments/assets/8c3d4ba2-763d-4c62-850a-61dae39a20f2)

# Notes

- I noticed that I was getting some errors in Slack, likely related to permission limitations on the Kubi access token for my repository. Since the task required a public repository, as soon as I set my repository to public, Kubi started collecting information correctly. Further investigation would be needed to properly set up the access token and troubleshoot the issue.

- The documentation provided during the Use Case configuration was useful, especially the Configure Settings section:

![config](https://github.com/user-attachments/assets/9b98103a-84e1-403b-ae39-c965196f0686)

- Some differences between the online documentation and the web platform UI caused a bit of confusion, but nothing too critical:

  
![documentatin_difference](https://github.com/user-attachments/assets/67e3157d-f065-44de-962b-82c07c1728cb)

![documentatin_difference3](https://github.com/user-attachments/assets/45de095e-3388-4d0b-b006-6eb8c975a188)


# Conclusion

My integration experiment with the Kubiya platform showed me its significant potential for organizations that aim to implement self-service DevOps practices. The integration process with the tool, combined with its interaction options (web, CLI and Slack bot), makes it an attractive choice for automating repetitive DevOps tasks.

I believe that the tool has the potential to help companies at different levels of self-service DevOps maturity: from companies without any automation infrastructure, using pre-built use cases, to companies that already have advanced maturity. I had the opportunity to work on a project for a large company where we created an infrastructure provisioning platform for development teams using Terraform. One of the challenges in implementing the tool was the friction in its adoption, due to the learning curve and difficulty in providing comprehensive documentation for developers. I think Kubi would be the missing piece for the success of this platform, providing an intelligent layer of abstraction on top of the set of terraform libraries created.
