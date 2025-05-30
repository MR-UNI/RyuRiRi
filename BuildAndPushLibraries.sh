function pub {
  dotnet publish -c release
}

function package {
  cd src/$1
  pub
  mv bin/Release/$1.1.0.0.nupkg ../../pkgs/$1.1.0.0.nupkg
  cd ../../
}

rm -rf pkgs
mkdir pkgs

package ARMeilleure
package Ryujinx.Memory

dotnet nuget push pkgs/*.nupkg --source RyubingPkgs