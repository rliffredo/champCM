# champCM
A sensible static site generator that runs on Windows and uses Razor templates and CommonMark markdown, 
based on [champ](https://github.com/lukevenediger/champ).  
Built so you can focus more time on writing content and less on fiddling with markup.

Features include:
* Intuitive pathing system
* Uses Razor template syntax for layouts
* Uses CommonMark (Markdown) markup
* Supports reusable components
* Callbacks to resolve URLS for subdirectories
* Automatic conversion of .less files
* Automatic file regeneration via the --watch option
* Can be used as a library in your project with SiteBuilder.ProcessPageNode()

## What's New
* Implemented CommonMark.Net for markdown parsing

## What's Different
* [MarkdownSharp](https://github.com/MortenHoustonLudvigsen/CommonMarkSharp) parsing library has been replace with [CommonMark.Net](https://github.com/Knagis/CommonMark.NET)

## Download champCM
The tool is packaged as a single .exe file. Download the latest release of champ.exe from here: [champCM v1.0]()

## Getting Started & Examples
Using champCM is exactly the same as champ. Have a look at the 
[Getting Started info there](https://github.com/lukevenediger/champ#getting-started) for more.

You can find a host of examples, with source and live demo, at the [champ-examples](https://github.com/lukevenediger/champ-examples/) project.

## Project Info

### Why champCM? (as opposed to champ)
I, too, really love the idea of pre-generated content pages as a way to make building a site much simpler. 
After a lot of investigation of other generators such as [Jekyll](http://github.com/mojombo/jekyll) and [Metalsmith](www.metalsmith.io) 
left me confused, I discovered champ. It suits my needs quite well, except it would stuff up my Markdown just a bit too often.
So I decided I'd fix that by changing how it parses Markdown. 

### What's Next?
* Add automatic conversion of .sass files

## About the Codebase

**System Requirements**
* .Net Runtime 4.5.1

**Licence**: MIT

Maintainers:
* champ: [Luke Venediger](http://lukevenediger.github.io/): [lukev@lukev.net](mailto:lukev@lukev.net)
* champCM: [Nitemice](http://nitemice.net/): [webmaster@nitemice.net](mailto:webmaster@nitemice.net)
