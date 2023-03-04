# FSBank.V1



## Code Generation

```
path/to/ClangSharpPInvokeGenerator.exe @args.rsp
```

## XML Regex

```
Find:
[ \t]*([A-Z_0-9]+),?\s*\/\*\s*([A-Za-z. 0-9_:\-,\(\)\/]+)\s\*\/

Replace:
\t<member name="NameOfEnum.$1">\n\t\t<summary>\n\t\t\t$2\n\t\t</summary>\n\t</member>`
```

## Credits

FMOD Studio, copyright © Firelight Technologies Pty, Ltd., 1994-2016.