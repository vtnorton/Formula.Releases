# 📰 The project (Formula.Releases)

This solution is separated in two projects:
* Formula.Releases.Az: An Azure Function, triggered by a HTML GET that return a list of releases based on the .md files. It includes a link to visualize the changelog.
* Formula.Releases.Visualizer: A React application that once you passed the name of the release in the route (like: localhost/release/v1.0.0) it shows the content of the .md file.

USAGE: It is used for users on the app [Formula - Universal Code Editor](https://www.microsoft.com/en-us/p/formula-universal-code-editor/9nblggh4wb6b) (version > 4) to view its release notes.


## 👨🏻‍💻 How to run it

### ⚡ Azure Function
For the Azure Function (Formula.Releases.Az), I recommend develop it with vscode or Visual Studio.

You may need to adjust the `BaseUri` at `local.settings.json` to your host, where the visualizer is set to start.

### ⚛ React application

Once on the Formula.Releases.Visualizer directory, just need to run the following commands:

```
npm install
npm start
```

## 🔮 Roadmap

I'm sharing with you some of my plans to move forward with this project, right now the priorities comes like this:

* Architecture: Even though this project is a solution for architectural problems related to the application, it still needs improvements. The .md files needs to be copied every time a new commit is made, as well it lives in the same repository. Any ideias on how to structure the project would be nice.

* Launch the release notes: The ideia here is to make a automatically post on the website [wordpress] everytime a new .md file is added or edited. _*This is from a internal backlog and a new repository/project will be created to make this happen, but would love suggestions*_

* Independency: Would love to make more stuff parameterizable so it can be used in other projects outside [vtnorton](https://vtnorton.com)

* Dark mode: this is a dependency from the [heartthrob project](https://github.com/vtnorton/heartthrob), once it have the dark mode then Formula.Releases should receive one as well.

* Docker: The project needs docker, and that says it all!

* YAML: would love to create the build process with yml.

Constributors of all kinds from the community are welcome, but especially those that support the efforts above.


## ⭐Contribution reward

For each contribution you get a key for [Formula - Universal Code Editor](https://www.microsoft.com/en-us/p/formula-universal-code-editor/9nblggh4wb6b), I will try my best to send to you once a contribution is set but if I forget to send you, just tell me!

For issues, it will only be valid once an issue is closed or resolved. 😉

## 📃 License

Copyright (c) vtnorton. All rights reserved.

Licensed under the [MIT License](https://github.com/vtnorton/Formula.Releases/blob/master/LICENSE).
