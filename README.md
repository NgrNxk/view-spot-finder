# ViewSpotFinder

Find view spots in a JSON file.

## build

As this project is using [serverless] you can call

Windows:
```bat
build.cmd
```

Linux:
```sh
build.sh
```

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

[serverless]: https://www.serverless.com
