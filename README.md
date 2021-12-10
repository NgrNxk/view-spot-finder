# ViewSpotFinder

Find view spots in a JSON file.

## Build

As this project is using [serverless] and C#/.netcore3.1, you should have
both installed and configured. Then you can call:

(for Windows)
```bat
build.cmd
```

(for Linux)
```sh
build.sh
```

## Run

Once the project is built (hopefully successfully), you can run it with
`serverless` like that (in Windows, PowerShell):

```PS
serverless invoke local -f viewspots -d '{\"filename\": \"mesh.json\", \"viewPointCount\": 5}'
```

This also implies that you have docker up and running on your machine.

There were three files included in the assignment; the names you can choose
from are:

- mesh.json
- mesh_x_sin_cos_10000.json
- mesh_x_sin_cos_20000.json

For your convenience I have added the following batch file for
windows users:

```bat
.\run.cmd mesh.json 5
```

# TODO

- tidy up the artifact: right now, it's packaging the unit tests (libraries)
  into the zip. If this were to ever go into production, this would need to
  change.

# Notes

## serverless

I tried to set it up locally (with `serverless offline`), but unfortunately,
it says:

```
offline: Warning: found unsupported runtime 'dotnetcore3.1' for function 'viewspots'
offline: Failure: Unsupported runtime
Error: Unsupported runtime
    at HandlerRunner._loadRunner (C:\Repos\view-spot-finder\node_modules\serverless-offline\dist\lambda\handler-runner\HandlerRunner.js:169:11)
    at HandlerRunner.run (C:\Repos\view-spot-finder\node_modules\serverless-offline\dist\lambda\handler-runner\HandlerRunner.js:207:72)
    at LambdaFunction.runHandler (C:\Repos\view-spot-finder\node_modules\serverless-offline\dist\lambda\LambdaFunction.js:368:92)
    at async hapiHandler (C:\Repos\view-spot-finder\node_modules\serverless-offline\dist\events\http\HttpServer.js:702:18)
    at async exports.Manager.execute (C:\Repos\view-spot-finder\node_modules\@hapi\hapi\lib\toolkit.js:60:28)
    at async Object.internals.handler (C:\Repos\view-spot-finder\node_modules\@hapi\hapi\lib\handler.js:46:20)
    at async exports.execute (C:\Repos\view-spot-finder\node_modules\@hapi\hapi\lib\handler.js:31:20)
    at async Request._lifecycle (C:\Repos\view-spot-finder\node_modules\@hapi\hapi\lib\request.js:371:32)
    at async Request._execute (C:\Repos\view-spot-finder\node_modules\@hapi\hapi\lib\request.js:281:9)
```

It seems this is a [known issue](https://github.com/dherault/serverless-offline/issues/876).

## Assignment

After the initial hurdles with setting up a new project with [serverless]
contained, the real struggle was to get the runtime requirements. My initial
(rather naïve implementation) exceeded the runtime requirements by many
times. After I constructed a new data structure -- which is better suited
for the task -- from the supplied one, the runtime dropped significantly.

My unit tests are working fine and manual examinations of the returned
values seem to undermine that I'm on the right track. But the amount of data
points -- and the structure of the file(s) -- makes it very hard to know for
sure.

## Bugs

If you find any bugs, please open an issue -- or even better: submit a PR!

[serverless]: https://www.serverless.com

