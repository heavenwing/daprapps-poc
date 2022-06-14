param(
   [string] $Name
)
docker build ../src -f "$Name.Dockerfile" -t "daprapps-poc-$Name"