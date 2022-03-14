# TechnoLogica Angular Common

## main
Application main created with the following command:
```powershell
ng n main --createApplication=false --minimal=true --prefix=tl --routing=false --skipTests=true --style=scss
```

## common
Additional library created in the projects folder:
```powershell
ng g library tl-common --prefix=tl
```
Adding new component:
```powershell
ng g c <componet-name>  --project tl-common
```