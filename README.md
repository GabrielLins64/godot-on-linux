<center>
  <img src="Assets/icon.svg"/>
  <h1>Godot Engine on Linux</h1>
</center>

Welcome to the Godot on **Linux** Repository! Our goal here is to provide clear and concise instructions for installing and utilizing Godot on the Linux environment. Additionally, we are committed to maintaining the Godot 4.1 Documentation examples working and ensuring they remain up-to-date with C# and follow best coding practices, utilizing the latest .NET 6.0 framework and VSCode.

---
<h2>Index</h2>

- [About Godot Engine](#about-godot-engine)
- [Installation](#installation)
- [References](#references)

---

## About Godot Engine

Godot Engine is an open source project developed by a community of volunteers.

## Installation

1. Download the Latest Godot Engine 4.1.1 - .NET (with C# support) [here](https://godotengine.org/download/linux/).

2. Install the [latest stable .NET SDK](https://dotnet.microsoft.com/en-us/download) version (we're using the version 6.0 on this repository).

3. Inside Godot Engine, configure VSCode as .NET Editor in **`Editor → Editor Settings`**, then **`Dotnet → Editor → External Editor to Visual Studio Code`**

4. Install the following vscode extensions:

- [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)

- [.NET Install Tool for Extension Authors](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscode-dotnet-runtime)

- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

- [C# Tools for Godot](https://marketplace.visualstudio.com/items?itemName=neikeq.godot-csharp-vscode)

5. Install Mono (open source implementation of Microsoft's .NET Framework) from [here](https://www.mono-project.com/download/stable/#download-lin).

*If you got the following error after installing mono: "*N: Skipping acquire of configured file 'main/binary-i386/Packages' as repository 'https://download.mono-project.com/repo/ubuntu stable-focal InRelease' doesn't support architecture 'i386'*", simply edit the mono sources list file:

```shell
sudo vim /etc/apt/sources.list.d/mono-official-stable.list
```

And change the following line:

```shell
deb [signed-by=/usr/share/keyrings/mono-official-archive-keyring.gpg] ...
```

to:

```shell
deb [arch=amd64 signed-by=/usr/share/keyrings/mono-official-archive-keyring.gpg] ...
```

6. When inside your Godot project, always use the following files inside the `.vscode` directory (remember to configure the **`<path_to_your_godot_executable>`**):

`tasks.json`
```json
{
	"version": "2.0.0",
	"tasks": [
		{
			"label": "build",
			"command": "dotnet",
			"type": "process",
			"args": [
				"build"
			],
			"problemMatcher": "$msCompile",
			"presentation": {
				"echo": true,
				"reveal": "silent",
				"focus": false,
				"panel": "shared",
				"showReuseMessage": true,
				"clear": false
			}
		}
	]
}
```

`launch.json`
```json
{
	"version": "0.2.0",
	"configurations": [
		{
			"name": "GDScript Godot",
			"type": "coreclr",
			"request": "launch",
			"preLaunchTask": "build",
			"program": "<path_to_your_godot_executable>",
			"args": [],
			"cwd": "${workspaceFolder}",
			"stopAtEntry": false
		}
	]
}

```

## References

[1] [Godot Docs](https://docs.godotengine.org/en/stable/index.html)
