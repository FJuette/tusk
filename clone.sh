#!/bin/bash
NEWNAME='Riki'
rm -Rf ./../$NEWNAME
cp -rf ./../tusk ./../$NEWNAME
cd ./../$NEWNAME
rm -Rf .git
rm -Rf ./src/Tusk.Common/obj
rm -Rf ./src/Tusk.Api/obj
rm -Rf ./src/Tusk.Api/bin
rm -Rf ./src/Tusk.Persistence/obj
rm -Rf ./src/Tusk.Persistence/bin
rm -Rf ./src/Tusk.Domain/obj
rm -Rf ./src/Tusk.Domain/bin
rm -Rf ./src/Tusk.Application/obj
rm -Rf ./src/Tusk.Application/bin
rm -Rf ./src/Tusk.Infrastructure/obj
find . -type d -name '*Tusk*' -print0 | xargs -0 -n1 bash -c 'mv "$0" "${0/Tusk/'$NEWNAME}'"';
find . -type f -name '*Tusk*' -print0 | xargs -0 -n1 bash -c 'mv "$0" "${0/Tusk/'$NEWNAME}'"'
find . -type f -name '*' -exec sed -i "" 's/Tusk/'$NEWNAME'/g' {} +