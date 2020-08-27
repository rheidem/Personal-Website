<!-- TITLE -->
# My Personal Website
You can find it [here](ryanheidema.azurewebsites.net)!



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
* [Framework & Packages](#framework-and-packages)
  * [MailKit](#mailkit)
  * [Home Page](#home-page)
* [Contact](#contact)


<!-- ABOUT THE PROJECT -->
## About The Project

This project is a personal website for myself giving users a quick synopsis of who I am, some projects I've worked on, my interests, and how they can contact me. It was written using ASP.NET Core and is currently being hosted on Azure as a free app service. One major obstacle I have encountered and am in the process of overcoming is this version of the website's code here on GitHub contains a working implementation of my C# Boggle Solver, but I have yet to get that working with Azure and a limited free web server. However, on Azure there are CI/CD pipelines to make new releases of my software relatively painless, and although this is a bit overkill for just my personal website, it is nice to see those changes automatically. 

I have many ways I would like to improve on this website from style, new projects to add and corresponding interactivity, and maybe even to rewrite this using a different framework. 

<!-- GETTING STARTED -->
## Framework and Packages

As of now, this website uses the ASP.NET Core framework and the corresponding C#, HTML, CSS (Bootstrap), and JavaScript.

### Mailkit

Something I wanted to add to this website was an easy way for users to contact me and I did this using the Nuget package MailKit. After reading the specs and setting up a shell Gmail account (for my own security), the email works, so check it out!


### Home Page

I also wanted to add some type of parallax background or animated home page to the website, so I did this as well. When you go on the site, you can see the home page has an animated star background with three different layers of different-sized stars. This was accomplished with the help of many YouTube videos, a C++ random pixel generator for up to 4K displays and a lot of tweaking.

Although this works, there is room for improvement to scale up this implementation for any size screen and I would like to explore this further in the future.


<!-- CONTACT -->
## Contact

Ryan Heidema - [@ryan-heidema](https://www.linkedin.com/in/ryan-heidema/) - rheidem@umich.edu

Project Link: [https://github.com/rheidem/Personal-Website](https://github.com/rheidem/Personal-Website)
